# Uno MVVMExpress IDE wrappers

Thin Visual Studio Code and Visual Studio extensions. They install [`Plugin.Uno.MVVMExpress.Templates`](https://www.nuget.org/packages/Plugin.Uno.MVVMExpress.Templates) and run `dotnet new`. The scaffold stays in [`templates/`](../templates/).

This is not the MAUI MVVMExpress extension.

| Host | Commands |
| --- | --- |
| Visual Studio Code | **Uno MVVMExpress: Create New App**, **Uno MVVMExpress: Add Page** |
| Visual Studio 2022+ | **Tools → Uno MVVMExpress → Create New App…**, **Add Page…** |

After the template pack is installed, Visual Studio’s **File → New → Project** lists **MVVMExpress Uno App** (`ide.host.json` on the project template). **Add → New Item** lists **MVVMExpress Uno Page**.

Requires the .NET SDK on PATH. Extension version is `1.0.0`, same as Plugin.Uno.MVVMExpress.

## Install from Marketplace

Search **Plugin.Uno.MVVMExpress** (VS Code) or **Uno MVVMExpress** (Visual Studio) and install:

| Host | Marketplace |
| --- | --- |
| Visual Studio Code | [Plugin.Uno.MVVMExpress](https://marketplace.visualstudio.com/search?term=Plugin.Uno.MVVMExpress&target=VSCode&category=All%20categories&sortBy=Relevance) |
| Visual Studio 2022+ | [Uno MVVMExpress](https://marketplace.visualstudio.com/search?term=Uno%20MVVMExpress&target=VS&category=All%20categories&vsVersion=&sortBy=Relevance) |

In the editor: **Extensions** → search **Plugin.Uno.MVVMExpress** (VS Code) or **Uno MVVMExpress** (Visual Studio) → **Install**. Then **Uno MVVMExpress: Create New App** / **Add Page** (VS Code) or **Tools → Uno MVVMExpress** (Visual Studio).

## Install (sideload)

Packed installers (version `1.0.0`) are in [`dist/`](dist/):

| Host | File | Install |
| --- | --- | --- |
| Visual Studio Code | `dist/nuvyntralabs.plugin-uno-mvvmexpress-1.0.0.vsix` | `code --install-extension extensions/dist/nuvyntralabs.plugin-uno-mvvmexpress-1.0.0.vsix` |
| Visual Studio 2022+ | `dist/nuvyntralabs.UnoMVVMExpress.VisualStudio.1.0.0.vsix` | Double-click the `.vsix`, or **Extensions → Manage Extensions → Install from VSIX…** |

After Visual Studio install, the package loads in the background and installs `Plugin.Uno.MVVMExpress.Templates`, so **File → New → Project** lists **MVVMExpress Uno App**. **Tools → Uno MVVMExpress** is present after install.

Rebuild both:

```bash
./extensions/pack.sh
```

Do not publish to the Marketplace from a local clone. CI uploads VSIX artifacts after **Version alignment** succeeds. Marketplace publish is manual.

## Pipeline

Library CI (`ci.yml`) packs NuGet only. It does not build VSIX files.

The **IDE extensions** workflow (`.github/workflows/ide-extensions.yml`) packs both wrappers. It runs on `main` / tags when `extensions/` changes, or from **Actions → IDE extensions → Run workflow**. It fails unless the extension version fields match [`Directory.Build.props`](../Directory.Build.props). Check locally:

```bash
python3 .github/scripts/check-versions.py --scope extensions
```

That run uploads the `.vsix` files as Actions artifacts. There is no Marketplace PAT in the workflow.

| Artifact | Listing |
| --- | --- |
| `vscode-UnoMVVMExpress` | Visual Studio Code / Cursor — `nuvyntralabs.plugin-uno-mvvmexpress` |
| `vsix-UnoMVVMExpress` | Visual Studio 2022+ — **Uno MVVMExpress for Visual Studio** |

Open the run → **Artifacts** → download the VSIX → update the matching listing at [Marketplace manage](https://marketplace.visualstudio.com/manage). The VS Code id is `nuvyntralabs.plugin-uno-mvvmexpress` because Marketplace reserved `uno-mvvmexpress` after a deleted listing. Do not create a new Visual Studio listing after the first publish.

Bump `Directory.Build.props` `Version` and the extension version fields together (the alignment job lists every file). Do not run `vsce publish` or `VsixPublisher` from a laptop.

## Visual Studio Code

```bash
./extensions/vscode/pack.sh
```

## Visual Studio

`pack-vsix.sh` compiles the `.vsct` with Wine on macOS or `VSCT.exe` on Windows, then writes the same Marketplace VSIX layout CI uploads.

```bash
./extensions/visualstudio/pack-vsix.sh
```

## CLI (no extension)

```bash
dotnet new install Plugin.Uno.MVVMExpress.Templates
dotnet new uno-mvvmexpress -n MyApp
dotnet new uno-mvvmexpress-page -n Catalog --namespace MyApp
```

See [templates/README.md](../templates/README.md) and [getting started](../docs/getting-started.md).
