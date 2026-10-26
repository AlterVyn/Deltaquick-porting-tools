Dónde encontrar mods

Una vez que un mod se haya añadido al catálogo de mods de DeltaQuick, podrás encontrarlo directamente en la pestaña Mods de la aplicación.

photos/mods_tab.png

Explora las modificaciones disponibles directamente desde DeltaQuick y descubre contenido nuevo para instalar.

Selecciona un mod de la lista y sigue las instrucciones de la aplicación para instalarlo.

[!NOTE]
Los mods deben añadirse al catálogo oficial antes de aparecer en esta pestaña.



# Guía de adaptación de DeltaQuick

> **Idiomas / Langues:** [English](README.md) | Español | [Português (Brasil)](README.pt-BR.md) | [Français](README.fr.md)

<p align="center">
  <strong>Adapta, empaqueta y comparte modificaciones de Deltarune para Android.</strong><br>
  Una guía práctica sobre la estructura de archivos de DeltaQuick, la compatibilidad con GameChange y la distribución de mods.
</p>

<p align="center">
  <a href="https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share">Get DeltaQuick</a>
  &nbsp; • &nbsp;
  <a href="https://github.com/BookerRues9/Deltaquick-porting-tools">Porting Tools</a>
  &nbsp; • &nbsp;
  <a href="https://github.com/UnderminersTeam/UndertaleModTool">UndertaleModTool</a>
</p>

Esta guía explica cómo adaptar modificaciones para **DeltaQuick**, el launcher de Deltarune para Android. Abarca la estructura interna de archivos, la implementación de `game_change_android()`, el empaquetado de mods y su distribución mediante la pestaña Mods de la aplicación.

> [!IMPORTANT]
> **Guía actualizada: 25 de octubre de 2026**
>
> Esta guía se aplica a **DeltaQuick 1.3.20 y versiones posteriores**. Las versiones anteriores no son compatibles con la estructura de archivos actualizada que se describe aquí.
>
> La nueva estructura se diseñó para mejorar la organización, simplificar la instalación de mods y facilitar la compatibilidad con futuros capítulos y modificaciones.

> [!NOTE]
> Esta actualización también corrige varios problemas relacionados con la instalación de mods.

> [!CAUTION]
> **Requisitos de compatibilidad**
>
> Esta guía está dirigida a usuarios avanzados que estén familiarizados con la modificación de los archivos del juego Deltarune.
>
> - Debes usar DeltaQuick 1.3.20 o posterior.
> - Debes configurar el juego antes de instalar o probar mods.
> - El mod debe utilizar archivos de juego de Deltarune compatibles.
> - Esta guía no es compatible con las versiones demo ni con las versiones del programa de encuestas.

> [!IMPORTANT]
> Esta guía se actualizará a medida que estén disponibles nuevos capítulos y funciones.
>
> Si encuentras cierres inesperados u otros problemas, consulta la [guía de solución de fallos](./crash%20fixes/README.md).

> [!TIP]
> ¿Quieres añadir **logros de Google Play Games** a tu mod?
>
> Sigue la [guía de configuración de Google Play Games](./play%20games/README.md).

---

## Tabla de contenido

- [Requisitos previos](#prerequisites)
- [Comprender el sistema de archivos](#understanding-the-file-system)
- [Añadir compatibilidad con GameChange](#adding-gamechange-support)
  - [1. Inyectar la extensión](#1-inject-the-extension)
  - [2. Modificar el selector de capítulos](#2-modify-the-chapter-selector)
  - [3. Modificar el script de cambio de capítulo](#3-modify-the-chapter-switching-script)
- [Publicar tu mod](#publishing-your-mod)
  - [1. Empaquetar el mod](#1-package-the-mod)
  - [2. Enviar tu mod](#2-submit-your-mod)
  - [3. Instalar el mod](#3-install-the-mod)
- [Solución de problemas](#troubleshooting)
- [Créditos](#credits)

---

## Requisitos previos

Antes de empezar, asegúrate de tener las siguientes herramientas:

- [Deltarune — Steam Version](https://store.steampowered.com/app/1671210/DELTARUNE/) — Necesario para configurar DeltaQuick y obtener archivos de juego compatibles.
- [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool) — Se utiliza para inspeccionar y modificar archivos `game.droid`.
- [DeltaQuick](https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share) — El launcher de Android que se utiliza para ejecutar y probar tus modificaciones.
- [DeltaQuick Porting Tools](https://github.com/BookerRues9/Deltaquick-porting-tools/tree/main/scripts) — Contiene los scripts necesarios para el proceso de adaptación.
- **WinRAR or another ZIP utility** — Se utiliza para empaquetar tu modificación para distribuirla.

**Antes de continuar:** configura DeltaQuick y comprueba que el juego funcione correctamente antes de intentar instalar o probar modificaciones.

---

## Comprender el sistema de archivos

Las versiones anteriores de DeltaQuick utilizaban una estructura de archivos menos organizada, lo que dificultaba la instalación y la compatibilidad de los mods.

A partir de la versión 1.3.20, se reorganizó la estructura interna para facilitar la administración de los archivos del juego y la integración de mods y futuros capítulos.

Puedes acceder a los archivos extraídos mediante el **Administrador de partidas guardadas (Save Manager)** de DeltaQuick.

### Estructura de directorios

Las siguientes rutas describen la estructura de directorios prevista. Sustituye `chapterX_windows` por el directorio del capítulo correspondiente.

| Ruta | Descripción |
| --- | --- |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/deltarune_save_files/` | Almacena las partidas guardadas y el progreso de Deltarune. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/` | Directorio raíz que contiene los archivos extraídos del juego y las modificaciones instaladas. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/game.droid` | Contiene el selector base de capítulos. Este archivo debe permanecer en el directorio raíz del juego. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/chapterX_windows/` | Contiene los archivos extraídos de cada capítulo, incluidos grupos de audio, música, archivos JSON, vídeos y otros recursos. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/chapterX_windows/game.droid` | Contiene los datos principales del juego para el capítulo correspondiente. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/mus/` | Contiene el directorio de música global que utiliza el juego. |

> [!IMPORTANT]
> **No confundas los dos tipos de archivos `game.droid`.**
>
> - `game/game.droid` es el selector base de capítulos.
> - `game/chapterX_windows/game.droid` contiene los datos del juego de un capítulo individual.
>
> Ambos tienen funciones diferentes y deben colocarse en las ubicaciones correctas.

### Descripción del Save Manager

El Save Manager permite administrar los archivos extraídos del juego que utiliza DeltaQuick.

<p align="center">
  <img src="./photos/savemanager.png" alt="DeltaQuick Descripción del Save Manager" width="360">
</p>

### Editar archivos del juego

Para modificar un archivo `game.droid`, utiliza UndertaleModTool.

1. Abre UndertaleModTool.
2. Selecciona **File > Open**.
3. Ve al directorio correspondiente.
4. Selecciona el archivo `game.droid` que quieras modificar.
5. Realiza los cambios y guarda el archivo modificado.

Asegúrate de editar el archivo correcto: el selector de capítulos de la raíz o el archivo `game.droid` de un capítulo individual.

---

## Añadir compatibilidad con GameChange

Esta sección explica cómo integrar `game_change_android()` en tu modificación.

> [!IMPORTANT]
> Antes de continuar, revisa la casilla **Disable Native GameChange (Only for Devs)** en DeltaQuick.
>
> - **Casilla desactivada:** añade `game_change_android()` al selector de capítulos y al archivo `game.droid` de cada capítulo.
> - **Casilla activada:** añade `game_change_android()` únicamente a los archivos `game.droid` de cada capítulo.
>
> Asegúrate de entender qué configuración estás utilizando antes de continuar.

### 1. Inyectar la extensión

Primero, descarga el script necesario para UndertaleModTool:

**[Download the GameChange Extension](./scripts/game.csx)**

Después de descargar el script:

1. Abre UndertaleModTool.
2. Carga el archivo `game.droid` que quieras modificar.
3. Ve a **Scripts > Run Other Script**.
4. Selecciona el script descargado.
5. Confirma la operación y espera a que termine el script.

La extensión ya debería estar inyectada en el archivo de juego seleccionado.

<p align="center">
  <img src="./photos/inyect.png" alt="UndertaleModTool Extension Injection" width="420">
</p>

*Captura sugerida: muestra la ejecución del script en UndertaleModTool.*

### 2. Modificar el selector de capítulos

Abre en UndertaleModTool el archivo `game.droid` del selector de capítulos.

Localiza el siguiente script:

`obj_CHAPTER_SELECT_Create_0`

Busca la sección que cambia entre sistemas operativos y añade el caso de Android como se muestra a continuación.

Sustituye el bloque correspondiente al cambio de sistema operativo por esta implementación:

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

El caso de Android utiliza `game_change_android()` para cambiar al directorio del capítulo seleccionado dentro de DeltaQuick.

> [!NOTE]
> Mantén intactos los casos específicos de las demás plataformas. La implementación de Android añade compatibilidad sin eliminar el comportamiento existente en otras plataformas.

### 3. Modificar el script de cambio de capítulo

Para cada capítulo, abre el archivo `game.droid` correspondiente y localiza el script global:

`gml_GlobalScript_scr_chapterswitch`

Sustituye la implementación existente de `scr_chapterswitch` por el siguiente código:

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

Aplica los cambios a cada capítulo que quieras admitir.

> [!IMPORTANT]
> Asegúrate de haber inyectado la extensión en todos los archivos `game.droid` necesarios. De lo contrario, las llamadas a `game_change_android()` podrían fallar al cambiar de capítulo.

---

## Publicar tu mod

Cuando hayas implementado y probado exhaustivamente tu modificación, podrás empaquetarla para distribuirla mediante DeltaQuick.

### 1. Empaquetar el mod

Prepara los archivos que incluirás en el archivo comprimido del mod.

Selecciona los siguientes archivos y directorios:

- `game.droid`
- `chapter1_windows/`
- `chapter2_windows/`
- `chapter3_windows/`
- `chapter4_windows/`
- `chapter5_windows/`

Comprime los archivos seleccionados en un archivo ZIP llamado:

`mymod.zip`

Puedes usar WinRAR, 7-Zip o cualquier otra herramienta para crear archivos ZIP.

**Importante:** el archivo debe contener los archivos y directorios directamente en su raíz, sin incluirlos dentro de una carpeta contenedora adicional.

Estructura esperada del archivo:

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

Los directorios de cada capítulo también deben incluir los recursos adicionales que requiera tu modificación, como audio, archivos JSON y vídeos.

Incluye únicamente los capítulos y archivos compatibles con tu mod. Si la modificación requiere una versión concreta del juego base o archivos adicionales, documenta claramente esos requisitos.

<p align="center">
  <img src="./photos/mod_zip_structure.png" alt="Example Mod ZIP Structure" width="420">
</p>

### 2. Enviar tu mod

Para que tu modificación aparezca en la pestaña **Mods** de DeltaQuick, debes añadir una entrada al archivo JSON del catálogo de mods del repositorio y enviar un pull request.

**Repository:** [DeltaQuick Porting Tools](https://github.com/BookerRues9/Deltaquick-porting-tools)

Sigue estos pasos:

1. Crea un fork del repositorio en GitHub.
2. Localiza el archivo JSON utilizado para registrar mods en el repositorio.
3. Añade una entrada para tu modificación siguiendo los campos obligatorios y el formato de las entradas existentes.
4. Incluye la URL de descarga correcta y los metadatos que requiera el catálogo.
5. Haz commit y push de los cambios a tu fork.
6. Abre un pull request hacia el repositorio original.
7. Espera a que revisen e integren los cambios.

**[Open the mod catalog (`mods.json`)](https://github.com/BookerRues9/Deltaquick-porting-tools/blob/main/mods.json)**

**[Example mod download](https://gamejolt.com/games/android-deltranslate-project/1086889)**

> [!NOTE]
> Sigue exactamente el esquema JSON existente. Los campos obligatorios y el formato de la URL de descarga dependen de la implementación actual del catálogo.
>
> Enviar un pull request no garantiza que se incluya de inmediato. Es posible que revisen tu contribución antes de que aparezca en DeltaQuick.

### 3. Instalar el mod

Cuando el archivo ZIP esté listo, podrás instalarlo directamente desde DeltaQuick.

1. Abre DeltaQuick.
2. Ve a la interfaz de selección de archivos o instalación de mods.
3. Pulsa **Select Folder**.
4. Elige **Select ZIP File**.
5. Busca y selecciona `mymod.zip`.
6. Espera a que termine la instalación.
7. Inicia el juego y prueba tu modificación.

<p align="center">
  <img src="./photos/zip_installation.png" alt="DeltaQuick ZIP Installation" width="360">
</p>


> [!WARNING]
> **Configura el juego antes de instalar el mod.**
>
> El juego base debe estar configurado en DeltaQuick. Instalar un mod antes de completar la configuración inicial puede provocar errores de instalación o impedir que el juego se inicie correctamente.

---

## Solución de problemas

Si tu mod no funciona como esperas, comprueba lo siguiente:

- **Versión incorrecta de DeltaQuick:** confirma que utilizas la versión 1.3.20 o posterior.
- **Estructura incorrecta del archivo:** asegúrate de que `game.droid` y los directorios de capítulos estén en la raíz del ZIP.
- **Faltan archivos de capítulos:** comprueba que se incluyan todos los directorios y recursos necesarios.
- **Falta la extensión GameChange:** confirma que la extensión esté inyectada en los archivos `game.droid` correspondientes.
- **Selector de capítulos incorrecto:** verifica el caso de Android en `obj_CHAPTER_SELECT_Create_0`.
- **Script de cambio de capítulo incorrecto:** verifica la implementación de `gml_GlobalScript_scr_chapterswitch`.
- **Juego sin configurar:** completa la configuración inicial antes de instalar la modificación.
- **Faltan recursos:** asegúrate de que la modificación incluya todos los archivos adicionales que necesita.

Para obtener instrucciones más detalladas, consulta la [guía de solución de fallos](./crash%20fixes/README.md).

---

## Recursos adicionales

- [DeltaQuick on Google Play](https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share)
- [DeltaQuick Porting Tools Repository](https://github.com/BookerRues9/Deltaquick-porting-tools)
- [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool)
- [Crash Fixes Guide](./crash%20fixes/README.md)
- [Google Play Games Setup Guide](./play%20games/README.md)

---

## Créditos

- **Toby Fox** — Creador de Deltarune y Undertale.
- **Angela Puzzle** — Port de Deltarune para Android (2021–2026).
- **ateskit** — Deltarune para Android (2025–2026).
- **Booker** — Launcher DeltaQuick para Android y herramientas de adaptación.
- **mattiw** — Controles táctiles base.
- **jockeholm** — Port de Undertale para Android (2018).
- **grossley** — UndertaleModTool.
- **Google and YoYo Games** — Herramientas de desarrollo para Android y GameMaker Studio.

---

*DeltaQuick Porting Tools — haciendo más fácil modificar Deltarune en Android.*
