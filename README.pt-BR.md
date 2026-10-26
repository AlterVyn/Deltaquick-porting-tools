Onde encontrar mods

Depois que um mod for adicionado ao catálogo de mods do DeltaQuick, você poderá encontrá-lo diretamente na aba Mods do aplicativo.

photos/mods_tab.png

Explore as modificações disponíveis diretamente no DeltaQuick e encontre novos conteúdos para instalar.

Selecione um mod da lista e siga as instruções do aplicativo para instalá-lo.

[!NOTE]
Os mods precisam ser adicionados ao catálogo oficial para aparecerem nesta aba.



# Guia de port do DeltaQuick

> **Idiomas / Langues:** [English](README.md) | [Español](README.es.md) | Português (Brasil) | [Français](README.fr.md)

<p align="center">
  <strong>Faça o port, empacote e compartilhe modificações de Deltarune para Android.</strong><br>
  Um guia prático sobre a estrutura de arquivos do DeltaQuick, o suporte ao GameChange e a distribuição de mods.
</p>

<p align="center">
  <a href="https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share">Get DeltaQuick</a>
  &nbsp; • &nbsp;
  <a href="https://github.com/BookerRues9/Deltaquick-porting-tools">Porting Tools</a>
  &nbsp; • &nbsp;
  <a href="https://github.com/UnderminersTeam/UndertaleModTool">UndertaleModTool</a>
</p>

Este guia explica como fazer o port de modificações para o **DeltaQuick**, o launcher de Deltarune para Android. Ele aborda a estrutura interna de arquivos, a implementação de `game_change_android()`, o empacotamento de mods e a distribuição pela aba Mods do aplicativo.

> [!IMPORTANT]
> **Guia atualizado: 25 de outubro de 2026**
>
> Este guia se aplica ao **DeltaQuick 1.3.20 e versões posteriores**. As versões anteriores não são compatíveis com a estrutura de arquivos atualizada descrita aqui.
>
> A nova estrutura foi projetada para melhorar a organização, simplificar a instalação de mods e facilitar o suporte a capítulos e modificações futuras.

> [!NOTE]
> Esta atualização também corrige vários problemas relacionados à instalação de mods.

> [!CAUTION]
> **Requisitos de compatibilidade**
>
> Este guia é destinado a usuários avançados que já conhecem a modificação dos arquivos do jogo Deltarune.
>
> - É necessário usar o DeltaQuick 1.3.20 ou posterior.
> - Você precisa configurar o jogo antes de instalar ou testar mods.
> - O mod precisa usar arquivos compatíveis do jogo Deltarune.
> - Este guia não oferece suporte às versões demo nem às versões do programa de pesquisa.

> [!IMPORTANT]
> Este guia será atualizado conforme novos capítulos e recursos forem disponibilizados.
>
> Se ocorrerem travamentos ou outros problemas, consulte o [guia de correção de falhas](./crash%20fixes/README.md).

> [!TIP]
> Quer adicionar **conquistas do Google Play Games** ao seu mod?
>
> Siga o [guia de configuração do Google Play Games](./play%20games/README.md).

---

## Sumário

- [Pré-requisitos](#prerequisites)
- [Entendendo o sistema de arquivos](#understanding-the-file-system)
- [Adicionando suporte ao GameChange](#adding-gamechange-support)
  - [1. Injetar a extensão](#1-inject-the-extension)
  - [2. Modificar o seletor de capítulos](#2-modify-the-chapter-selector)
  - [3. Modificar o script de troca de capítulo](#3-modify-the-chapter-switching-script)
- [Publicando seu mod](#publishing-your-mod)
  - [1. Empacotar o mod](#1-package-the-mod)
  - [2. Enviar seu mod](#2-submit-your-mod)
  - [3. Instalar o mod](#3-install-the-mod)
- [Solução de problemas](#troubleshooting)
- [Créditos](#credits)

---

## Pré-requisitos

Antes de começar, confira se você tem as seguintes ferramentas:

- [Deltarune — Steam Version](https://store.steampowered.com/app/1671210/DELTARUNE/) — Necessário para configurar o DeltaQuick e obter arquivos de jogo compatíveis.
- [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool) — Usado para inspecionar e modificar arquivos `game.droid`.
- [DeltaQuick](https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share) — O launcher Android usado para executar e testar suas modificações.
- [DeltaQuick Porting Tools](https://github.com/BookerRues9/Deltaquick-porting-tools/tree/main/scripts) — Contém os scripts necessários para o processo de port.
- **WinRAR or another ZIP utility** — Usado para empacotar sua modificação para distribuição.

**Antes de continuar:** configure o DeltaQuick e confirme que o jogo funciona corretamente antes de tentar instalar ou testar modificações.

---

## Entendendo o sistema de arquivos

As versões anteriores do DeltaQuick usavam uma estrutura de arquivos menos organizada, dificultando a instalação e a compatibilidade dos mods.

A partir da versão 1.3.20, a estrutura interna foi reorganizada para facilitar o gerenciamento dos arquivos do jogo e a integração de mods e capítulos futuros.

Você pode acessar os arquivos extraídos pelo **Save Manager** do DeltaQuick.

### Estrutura de diretórios

Os caminhos a seguir descrevem a estrutura de diretórios prevista. Substitua `chapterX_windows` pelo diretório do capítulo correspondente.

| Caminho | Descrição |
| --- | --- |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/deltarune_save_files/` | Armazena os arquivos de salvamento e o progresso de Deltarune. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/` | Diretório raiz que contém os arquivos extraídos do jogo e as modificações instaladas. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/game.droid` | Contém o seletor base de capítulos. Esse arquivo deve permanecer no diretório raiz do jogo. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/chapterX_windows/` | Contém os arquivos extraídos de cada capítulo, incluindo grupos de áudio, músicas, arquivos JSON, vídeos e outros recursos. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/chapterX_windows/game.droid` | Contém os dados principais do jogo para o capítulo correspondente. |
| `/data/user/0/com.bookerpuzzle.deltaquick/files/game/mus/` | Contém o diretório global de músicas usado pelo jogo. |

> [!IMPORTANT]
> **Não confunda os dois tipos de arquivo `game.droid`.**
>
> - `game/game.droid` é o seletor base de capítulos.
> - `game/chapterX_windows/game.droid` contém os dados do jogo de um capítulo específico.
>
> Eles têm funções diferentes e precisam ficar nos locais corretos.

### Visão geral do Save Manager

O Save Manager permite gerenciar os arquivos extraídos do jogo usados pelo DeltaQuick.

<p align="center">
  <img src="./photos/savemanager.png" alt="DeltaQuick Visão geral do Save Manager" width="360">
</p>

### Editando arquivos do jogo

Para modificar um arquivo `game.droid`, use o UndertaleModTool.

1. Abra o UndertaleModTool.
2. Selecione **File > Open**.
3. Navegue até o diretório apropriado.
4. Selecione o arquivo `game.droid` que deseja modificar.
5. Faça as alterações e salve o arquivo modificado.

Confira se está editando o arquivo correto: o seletor de capítulos na raiz ou o arquivo `game.droid` de um capítulo específico.

---

## Adicionando suporte ao GameChange

Esta seção explica como integrar `game_change_android()` à sua modificação.

> [!IMPORTANT]
> Antes de continuar, marque ou desmarque a caixa **Disable Native GameChange (Only for Devs)** no DeltaQuick conforme a configuração desejada.
>
> - **Caixa desmarcada:** adicione `game_change_android()` ao seletor de capítulos e ao `game.droid` de cada capítulo.
> - **Caixa marcada:** adicione `game_change_android()` somente aos arquivos `game.droid` dos capítulos individuais.
>
> Confirme qual configuração está usando antes de continuar.

### 1. Injetar a extensão

Primeiro, baixe o script necessário do UndertaleModTool:

**[Download the GameChange Extension](./scripts/game.csx)**

Depois de baixar o script:

1. Abra o UndertaleModTool.
2. Carregue o arquivo `game.droid` que deseja modificar.
3. Acesse **Scripts > Run Other Script**.
4. Selecione o script baixado.
5. Confirme a operação e aguarde o término do script.

A extensão deverá estar injetada no arquivo de jogo selecionado.

<p align="center">
  <img src="./photos/inyect.png" alt="UndertaleModTool Extension Injection" width="420">
</p>

*Captura sugerida: mostre a execução do script no UndertaleModTool.*

### 2. Modificar o seletor de capítulos

Abra no UndertaleModTool o arquivo `game.droid` do seletor de capítulos.

Localize o seguinte script:

`obj_CHAPTER_SELECT_Create_0`

Encontre a seção que alterna entre sistemas operacionais e adicione o caso do Android como mostrado abaixo.

Substitua o bloco correspondente à troca de sistema operacional por esta implementação:

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

O caso do Android usa `game_change_android()` para alternar para o diretório do capítulo selecionado dentro do DeltaQuick.

> [!NOTE]
> Mantenha intactos os casos específicos das outras plataformas. A implementação Android adiciona suporte sem remover o comportamento existente nas demais plataformas.

### 3. Modificar o script de troca de capítulo

Para cada capítulo, abra o arquivo `game.droid` correspondente e localize o script global:

`gml_GlobalScript_scr_chapterswitch`

Substitua a implementação existente de `scr_chapterswitch` pelo código a seguir:

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

Aplique as alterações a cada capítulo que deseja oferecer suporte.

> [!IMPORTANT]
> Confirme que a extensão foi injetada em todos os arquivos `game.droid` necessários. Caso contrário, as chamadas a `game_change_android()` podem falhar quando o jogo tentar trocar de capítulo.

---

## Publicando seu mod

Depois de implementar e testar sua modificação cuidadosamente, você poderá empacotá-la para distribuição pelo DeltaQuick.

### 1. Empacotar o mod

Prepare os arquivos que serão incluídos no pacote do mod.

Selecione os seguintes arquivos e diretórios:

- `game.droid`
- `chapter1_windows/`
- `chapter2_windows/`
- `chapter3_windows/`
- `chapter4_windows/`
- `chapter5_windows/`

Comprima os arquivos selecionados em um arquivo ZIP chamado:

`mymod.zip`

Você pode usar WinRAR, 7-Zip ou outro utilitário ZIP.

**Importante:** o arquivo deve conter os arquivos e diretórios diretamente na raiz, sem colocá-los dentro de uma pasta extra.

Estrutura esperada do arquivo:

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

Os diretórios dos capítulos também devem incluir os recursos adicionais exigidos pela modificação, como áudio, arquivos JSON e vídeos.

Inclua apenas os capítulos e arquivos compatíveis com seu mod. Se a modificação exigir uma versão específica do jogo base ou arquivos adicionais, documente esses requisitos claramente.

<p align="center">
  <img src="./photos/mod_zip_structure.png" alt="Example Mod ZIP Structure" width="420">
</p>

### 2. Enviar seu mod

Para que sua modificação apareça na aba **Mods** do DeltaQuick, você precisa adicionar uma entrada ao arquivo JSON do catálogo de mods do repositório e enviar um pull request.

**Repository:** [DeltaQuick Porting Tools](https://github.com/BookerRues9/Deltaquick-porting-tools)

Siga estas etapas:

1. Crie um fork do repositório no GitHub.
2. Localize o arquivo JSON usado para registrar mods no repositório.
3. Adicione uma entrada para sua modificação seguindo o formato e os campos obrigatórios das entradas existentes.
4. Informe a URL correta para download e os demais metadados exigidos pelo catálogo.
5. Faça commit e push das alterações para seu fork.
6. Abra um pull request para o repositório original.
7. Aguarde a revisão e a integração das alterações.

**[Open the mod catalog (`mods.json`)](https://github.com/BookerRues9/Deltaquick-porting-tools/blob/main/mods.json)**

**[Example mod download](https://gamejolt.com/games/android-deltranslate-project/1086889)**

> [!NOTE]
> Siga exatamente o esquema JSON existente. Os campos obrigatórios e o formato da URL de download dependem da implementação atual do catálogo.
>
> Enviar um pull request não garante inclusão imediata. Sua contribuição pode precisar de revisão antes de aparecer no DeltaQuick.

### 3. Instalar o mod

Quando o arquivo ZIP estiver pronto, você poderá instalá-lo diretamente pelo DeltaQuick.

1. Abra o DeltaQuick.
2. Acesse a interface de seleção de arquivos ou instalação de mods.
3. Toque em **Select Folder**.
4. Escolha **Select ZIP File**.
5. Localize e selecione `mymod.zip`.
6. Aguarde o fim da instalação.
7. Inicie o jogo e teste sua modificação.

<p align="center">
  <img src="./photos/zip_installation.png" alt="DeltaQuick ZIP Installation" width="360">
</p>


> [!WARNING]
> **Configure o jogo antes de instalar o mod.**
>
> O jogo base já precisa estar configurado no DeltaQuick. Instalar um mod antes de concluir a configuração inicial pode causar erros ou impedir que o jogo seja iniciado corretamente.

---

## Solução de problemas

Se seu mod não funcionar como esperado, verifique o seguinte:

- **Versão incorreta do DeltaQuick:** confirme se está usando a versão 1.3.20 ou posterior.
- **Estrutura incorreta do pacote:** confira se `game.droid` e os diretórios dos capítulos estão na raiz do ZIP.
- **Arquivos de capítulo ausentes:** verifique se todos os diretórios e recursos necessários estão incluídos.
- **Extensão GameChange ausente:** confirme se a extensão foi injetada nos arquivos `game.droid` apropriados.
- **Seletor de capítulos incorreto:** verifique o caso Android em `obj_CHAPTER_SELECT_Create_0`.
- **Script de troca de capítulo incorreto:** verifique a implementação de `gml_GlobalScript_scr_chapterswitch`.
- **Jogo não configurado:** conclua a configuração inicial antes de instalar a modificação.
- **Recursos ausentes:** confira se a modificação inclui todos os arquivos adicionais necessários.

Para instruções mais detalhadas, consulte o [guia de correção de falhas](./crash%20fixes/README.md).

---

## Recursos adicionais

- [DeltaQuick on Google Play](https://play.google.com/store/apps/details?id=com.bookerpuzzle.deltaquick&pcampaignid=web_share)
- [DeltaQuick Porting Tools Repository](https://github.com/BookerRues9/Deltaquick-porting-tools)
- [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool)
- [Crash Fixes Guide](./crash%20fixes/README.md)
- [Google Play Games Setup Guide](./play%20games/README.md)

---

## Créditos

- **Toby Fox** — Criador de Deltarune e Undertale.
- **Angela Puzzle** — Port de Deltarune para Android (2021–2026).
- **ateskit** — Deltarune para Android (2025–2026).
- **Booker** — Launcher DeltaQuick para Android e ferramentas de port.
- **mattiw** — Controles de toque básicos.
- **jockeholm** — Port de Undertale para Android (2018).
- **grossley** — UndertaleModTool.
- **Google and YoYo Games** — Ferramentas de desenvolvimento Android e GameMaker Studio.

---

*DeltaQuick Porting Tools — facilitando a criação de mods de Deltarune no Android.*
