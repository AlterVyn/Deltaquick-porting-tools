Où trouver des mods

Une fois qu’un mod a été ajouté au catalogue de mods de DeltaQuick, vous pouvez le trouver directement dans l’onglet Mods de l’application.

photos/mods_tab.png

Parcourez les modifications disponibles directement dans DeltaQuick et découvrez de nouveaux contenus à installer.

Sélectionnez un mod dans la liste et suivez les instructions de l’application pour l’installer.

[!NOTE]
Les mods doivent être ajoutés au catalogue officiel avant d’apparaître dans cet onglet.



# Guide de portage DeltaQuick

> **Idiomas / Langues:** [English](README.md) | [Español](README.es.md) | [Português (Brasil)](README.pt-BR.md) | Français

<p align="center">
  <strong>Portez, empaquetez et partagez des modifications de Deltarune pour Android.</strong><br>
  Un guide pratique sur la structure des fichiers de DeltaQuick, la prise en charge de GameChange et la distribution des mods.
</p>

<p align="center">
  <a href="https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share">Get DeltaQuick</a>
  &nbsp; • &nbsp;
  <a href="https://github.com/BookerRues9/Deltaquick-porting-tools">Porting Tools</a>
  &nbsp; • &nbsp;
  <a href="https://github.com/UnderminersTeam/UndertaleModTool">UndertaleModTool</a>
</p>

Ce guide explique comment porter des modifications vers **DeltaQuick**, le launcher Android de Deltarune. Il présente la structure interne des fichiers, l’implémentation de `game_change_android()`, l’empaquetage des mods et leur distribution via l’onglet Mods de l’application.

> [!IMPORTANT]
> **Guide mis à jour le 25 octobre 2026**
>
> Ce guide s’applique à **DeltaQuick 1.3.20 et aux versions ultérieures**. Les versions précédentes ne sont pas compatibles avec la structure de fichiers mise à jour décrite ici.
>
> La nouvelle structure a été conçue pour améliorer l’organisation, simplifier l’installation des mods et faciliter la prise en charge des futurs chapitres et modifications.

> [!NOTE]
> Cette mise à jour corrige également plusieurs problèmes liés à l’installation des mods.

> [!CAUTION]
> **Conditions de compatibilité**
>
> Ce guide s’adresse aux utilisateurs avancés qui connaissent déjà la modification des fichiers du jeu Deltarune.
>
> - Vous devez utiliser DeltaQuick 1.3.20 ou une version ultérieure.
> - Vous devez configurer le jeu avant d’installer ou de tester des mods.
> - Le mod doit utiliser des fichiers de jeu Deltarune compatibles.
> - Ce guide ne prend pas en charge les versions démo ni celles du programme d’enquête.

> [!IMPORTANT]
> Ce guide sera mis à jour à mesure que de nouveaux chapitres et de nouvelles fonctionnalités seront disponibles.
>
> En cas de plantage ou d’autre problème, consultez le [guide de résolution des plantages](./crash%20fixes/README.md).

> [!TIP]
> Vous souhaitez ajouter des **succès Google Play Games** à votre mod ?
>
> Suivez le [guide de configuration de Google Play Games](./play%20games/README.md).

---

## Sommaire

- [Prérequis](#prerequisites)
- [Comprendre le système de fichiers](#understanding-the-file-system)
- [Ajouter la prise en charge de GameChange](#adding-gamechange-support)
  - [1. Injecter l’extension](#1-inject-the-extension)
  - [2. Modifier le sélecteur de chapitres](#2-modify-the-chapter-selector)
  - [3. Modifier le script de changement de chapitre](#3-modify-the-chapter-switching-script)
- [Publier votre mod](#publishing-your-mod)
  - [1. Empaqueter le mod](#1-package-the-mod)
  - [2. Soumettre votre mod](#2-submit-your-mod)
  - [3. Installer le mod](#3-install-the-mod)
- [Dépannage](#troubleshooting)
- [Crédits](#credits)

---

## Prérequis

Avant de commencer, assurez-vous de disposer des outils suivants :

- [Deltarune — Steam Version](https://store.steampowered.com/app/1671210/DELTARUNE/) — Nécessaire pour configurer DeltaQuick et obtenir les fichiers de jeu compatibles.
- [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool) — Permet d’inspecter et de modifier les fichiers `game.droid`.
- [DeltaQuick](https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share) — Le launcher Android utilisé pour exécuter et tester vos modifications.
- [DeltaQuick Porting Tools](https://github.com/BookerRues9/Deltaquick-porting-tools/tree/main/scripts) — Contient les scripts nécessaires au processus de portage.
- **WinRAR or another ZIP utility** — Permet d’empaqueter votre modification pour la distribuer.

**Avant de continuer :** configurez DeltaQuick et vérifiez que le jeu fonctionne correctement avant d’essayer d’installer ou de tester des modifications.

---

## Comprendre le système de fichiers

Les anciennes versions de DeltaQuick utilisaient une structure de fichiers moins organisée, ce qui compliquait l’installation et la compatibilité des mods.

À partir de la version 1.3.20, la structure interne a été réorganisée pour faciliter la gestion des fichiers du jeu et l’intégration des mods et des futurs chapitres.

Vous pouvez accéder aux fichiers extraits via le **Save Manager** de DeltaQuick.

### Structure des répertoires

Les chemins suivants décrivent l’organisation prévue des répertoires. Remplacez `chapterX_windows` par le répertoire du chapitre concerné.

| Chemin | Description |
| --- | --- |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/deltarune_save_files/` | Stocke les sauvegardes et la progression de Deltarune. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/` | Répertoire racine contenant les fichiers extraits du jeu et les modifications installées. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/game.droid` | Contient le sélecteur de chapitres de base. Ce fichier doit rester dans le répertoire racine du jeu. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/chapterX_windows/` | Contient les fichiers extraits de chaque chapitre, notamment les groupes audio, la musique, les fichiers JSON, les vidéos et d’autres ressources. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/chapterX_windows/game.droid` | Contient les données principales du jeu pour le chapitre correspondant. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/mus/` | Contient le répertoire de musique global utilisé par le jeu. |

> [!IMPORTANT]
> **Ne confondez pas les deux types de fichiers `game.droid`.**
>
> - `game/game.droid` est le sélecteur de chapitres de base.
> - `game/chapterX_windows/game.droid` contient les données du jeu pour un chapitre donné.
>
> Ils ont des fonctions différentes et doivent être placés aux emplacements appropriés.

### Présentation du Save Manager

Le Save Manager permet de gérer les fichiers de jeu extraits utilisés par DeltaQuick.

<p align="center">
  <img src="./photos/savemanager.png" alt="DeltaQuick Présentation du Save Manager" width="360">
</p>

### Modifier les fichiers du jeu

Pour modifier un fichier `game.droid`, utilisez UndertaleModTool.

1. Ouvrez UndertaleModTool.
2. Sélectionnez **File > Open**.
3. Accédez au répertoire approprié.
4. Sélectionnez le fichier `game.droid` à modifier.
5. Effectuez vos modifications et enregistrez le fichier.

Assurez-vous de modifier le bon fichier : le sélecteur de chapitres à la racine ou le fichier `game.droid` d’un chapitre précis.

---

## Ajouter la prise en charge de GameChange

Cette section explique comment intégrer `game_change_android()` à votre modification.

> [!IMPORTANT]
> Avant de continuer, vérifiez la case **Disable Native GameChange (Only for Devs)** dans DeltaQuick.
>
> - **Case décochée :** ajoutez `game_change_android()` au sélecteur de chapitres et au fichier `game.droid` de chaque chapitre.
> - **Case cochée :** ajoutez `game_change_android()` uniquement aux fichiers `game.droid` des chapitres individuels.
>
> Assurez-vous de bien comprendre la configuration utilisée avant de poursuivre.

### 1. Injecter l’extension

Téléchargez d’abord le script UndertaleModTool requis :

**[Download the GameChange Extension](./scripts/game.csx)**

Une fois le script téléchargé :

1. Ouvrez UndertaleModTool.
2. Chargez le fichier `game.droid` que vous souhaitez modifier.
3. Ouvrez **Scripts > Run Other Script**.
4. Sélectionnez le script téléchargé.
5. Confirmez l’opération et attendez la fin du script.

L’extension devrait maintenant être injectée dans le fichier de jeu sélectionné.

<p align="center">
  <img src="./photos/inyect.png" alt="UndertaleModTool Extension Injection" width="420">
</p>

*Capture suggérée : montrez l’exécution du script dans UndertaleModTool.*

### 2. Modifier le sélecteur de chapitres

Ouvrez dans UndertaleModTool le fichier `game.droid` du sélecteur de chapitres.

Recherchez le script suivant :

`obj_CHAPTER_SELECT_Create_0`

Repérez la section qui bascule entre les systèmes d’exploitation et ajoutez le cas Android comme indiqué ci-dessous.

Remplacez le bloc de sélection du système d’exploitation concerné par cette implémentation :

```gml
switch (os_type)
{
    case os_windows:
        game_change("/chapter" + chapstring + "_windows", "-game data.win" + parameters);
        break;

    case os_ps4:
        game_change("", "-game /app0/games/chapter" + chapstring + "_ps4/game.win" + parameters);
        break;

    case os_ps5:
        game_change("", "-game /app0/games/chapter" + chapstring + "_ps5/game.win" + parameters);
        break;

    case os_macosx:
        game_change("chapter" + chapstring + "_mac", parameters);
        break;

    case os_android:
        game_change_android("chapter" + chapstring + "_windows");
        break;
}
```

Le cas Android utilise `game_change_android()` pour basculer vers le répertoire du chapitre sélectionné dans DeltaQuick.

> [!NOTE]
> Conservez les cas propres aux autres plateformes. L’implémentation Android ajoute la prise en charge d’Android sans supprimer le comportement existant des autres plateformes.

### 3. Modifier le script de changement de chapitre

Pour chaque chapitre, ouvrez le fichier `game.droid` correspondant et recherchez le script global :

`gml_GlobalScript_scr_chapterswitch`

Remplacez l’implémentation existante de `scr_chapterswitch` par le code suivant :

```gml
function scr_chapterswitch(arg0 = 0)
{
    var parameters = get_chapter_switch_parameters();

    if (arg0 == 0)
    {
        if (scr_is_switch_os())
        {
            game_change("rom:/", parameters);
        }
        else
        {
            switch (os_type)
            {
                case os_windows:
                    game_change("/../", "-game data.win" + parameters);
                    break;

                case os_ps4:
                    game_change("", "-game /app0/games/game.win" + parameters);
                    break;

                case os_ps5:
                    game_change("", "-game /app0/games/game.win" + parameters);
                    break;

                case os_macosx:
                    game_change("..", parameters);
                    break;

                case os_android:
                    game_change_android("");
                    break;
            }
        }
    }
    else
    {
        var chapstring = string(arg0);

        show_debug_message("Attempting to launch Chapter " + string(arg0));

        if (scr_is_switch_os())
        {
            game_change("rom:/chapter" + chapstring + "_switch/", parameters);
        }
        else
        {
            switch (os_type)
            {
                case os_windows:
                    game_change("/../chapter" + chapstring + "_windows", "-game data.win" + parameters);
                    break;

                case os_ps4:
                    game_change("", "-game /app0/games/chapter" + chapstring + "_ps4/game.win" + parameters);
                    break;

                case os_ps5:
                    game_change("", "-game /app0/games/chapter" + chapstring + "_ps5/game.win" + parameters);
                    break;

                case os_macosx:
                    game_change("../chapter" + chapstring + "_mac", parameters);
                    break;

                case os_android:
                    game_change_android("chapter" + chapstring + "_windows");
                    break;
            }
        }
    }
}
```

Appliquez ces modifications à chaque chapitre que vous souhaitez prendre en charge.

> [!IMPORTANT]
> Vérifiez que l’extension a été injectée dans tous les fichiers `game.droid` nécessaires. Sinon, les appels à `game_change_android()` peuvent échouer lorsque le jeu tente de changer de chapitre.

---

## Publier votre mod

Une fois votre modification implémentée et soigneusement testée, vous pouvez l’empaqueter pour la distribuer via DeltaQuick.

### 1. Empaqueter le mod

Préparez les fichiers qui seront inclus dans l’archive de votre mod.

Sélectionnez les fichiers et répertoires suivants :

- `game.droid`
- `chapter1_windows/`
- `chapter2_windows/`
- `chapter3_windows/`
- `chapter4_windows/`
- `chapter5_windows/`

Compressez les éléments sélectionnés dans une archive ZIP nommée :

`mymod.zip`

Vous pouvez utiliser WinRAR, 7-Zip ou tout autre utilitaire ZIP.

**Important :** l’archive doit contenir les fichiers et répertoires directement à sa racine, sans les placer dans un dossier supplémentaire.

Structure attendue de l’archive :

```text
mymod.zip
├── game.droid
├── chapter1_windows/
│   └── game.droid
├── chapter2_windows/
│   └── game.droid
├── chapter3_windows/
│   └── game.droid
├── chapter4_windows/
│   └── game.droid
└── chapter5_windows/
    └── game.droid
```

Les répertoires des chapitres doivent également contenir les ressources nécessaires à votre modification, comme l’audio, les fichiers JSON et les vidéos.

N’incluez que les chapitres et fichiers réellement pris en charge par votre mod. Si votre modification nécessite une version précise du jeu de base ou des fichiers supplémentaires, indiquez clairement ces exigences.

<p align="center">
  <img src="./photos/mod_zip_structure.png" alt="Example Mod ZIP Structure" width="420">
</p>

### 2. Soumettre votre mod

Pour que votre modification apparaisse dans l’onglet **Mods** de DeltaQuick, vous devez ajouter une entrée dans le fichier JSON du catalogue de mods du dépôt et soumettre une pull request.

**Repository:** [DeltaQuick Porting Tools](https://github.com/BookerRues9/Deltaquick-porting-tools)

Suivez ces étapes :

1. Forkez le dépôt sur GitHub.
2. Repérez le fichier JSON utilisé pour enregistrer les mods dans le dépôt.
3. Ajoutez une entrée pour votre modification en respectant le format et les champs requis des entrées existantes.
4. Indiquez l’URL de téléchargement correcte ainsi que les autres métadonnées requises par le catalogue.
5. Commitez et poussez vos modifications vers votre fork.
6. Ouvrez une pull request vers le dépôt d’origine.
7. Attendez que les modifications soient examinées et fusionnées.

**[Open the mod catalog (`mods.json`)](https://github.com/BookerRues9/Deltaquick-porting-tools/blob/main/mods.json)**

**[Example mod download](https://gamejolt.com/games/android-deltranslate-project/1086889)**

> [!NOTE]
> Respectez exactement le schéma JSON existant. Les champs requis et le format de l’URL de téléchargement dépendent de l’implémentation actuelle du catalogue.
>
> Une pull request ne garantit pas une intégration immédiate. Votre contribution devra peut-être être examinée avant d’apparaître dans DeltaQuick.

### 3. Installer le mod

Une fois l’archive ZIP prête, vous pouvez l’installer directement depuis DeltaQuick.

1. Ouvrez DeltaQuick.
2. Accédez à l’interface de sélection de fichiers ou d’installation de mods.
3. Appuyez sur **Select Folder**.
4. Choisissez **Select ZIP File**.
5. Recherchez et sélectionnez `mymod.zip`.
6. Attendez la fin de l’installation.
7. Lancez le jeu et testez votre modification.

<p align="center">
  <img src="./photos/zip_installation.png" alt="DeltaQuick ZIP Installation" width="360">
</p>


> [!WARNING]
> **Configurez le jeu avant d’installer le mod.**
>
> Le jeu de base doit déjà être configuré dans DeltaQuick. Installer un mod avant la configuration initiale peut provoquer des erreurs d’installation ou empêcher le lancement correct du jeu.

---

## Dépannage

Si votre mod ne fonctionne pas comme prévu, vérifiez les points suivants :

- **Version de DeltaQuick incorrecte :** vérifiez que vous utilisez la version 1.3.20 ou ultérieure.
- **Structure d’archive incorrecte :** vérifiez que `game.droid` et les répertoires des chapitres se trouvent à la racine du ZIP.
- **Fichiers de chapitre manquants :** vérifiez que tous les répertoires et ressources nécessaires sont inclus.
- **Extension GameChange manquante :** vérifiez que l’extension a été injectée dans les fichiers `game.droid` appropriés.
- **Sélecteur de chapitres incorrect :** vérifiez le cas Android dans `obj_CHAPTER_SELECT_Create_0`.
- **Script de changement de chapitre incorrect :** vérifiez l’implémentation de `gml_GlobalScript_scr_chapterswitch`.
- **Jeu non configuré :** terminez la configuration initiale avant d’installer votre modification.
- **Ressources manquantes :** assurez-vous que la modification inclut tous les fichiers supplémentaires nécessaires.

Pour plus de détails, consultez le [guide de résolution des plantages](./crash%20fixes/README.md).

---

## Ressources supplémentaires

- [DeltaQuick on Google Play](https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share)
- [DeltaQuick Porting Tools Repository](https://github.com/BookerRues9/Deltaquick-porting-tools)
- [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool)
- [Crash Fixes Guide](./crash%20fixes/README.md)
- [Google Play Games Setup Guide](./play%20games/README.md)

---

## Crédits

- **Toby Fox** — Créateur de Deltarune et Undertale.
- **Angela Puzzle** — Portage Android de Deltarune (2021–2026).
- **ateskit** — Deltarune pour Android (2025–2026).
- **Booker** — Launcher DeltaQuick pour Android et outils de portage.
- **mattiw** — Commandes tactiles de base.
- **jockeholm** — Portage Android d’Undertale (2018).
- **grossley** — UndertaleModTool.
- **Google and YoYo Games** — Outils de développement Android et GameMaker Studio.

---

*DeltaQuick Porting Tools — faciliter le modding de Deltarune sur Android.*
