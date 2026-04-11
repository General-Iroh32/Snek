# Windows VM test plan

Snek Studio can be cross-built on macOS or Linux, but WPF rendering and interaction must be checked on Windows. Use Windows 10 22H2 or Windows 11 on an x64 VM with at least 4 GB RAM.

## 1. Prepare the VM

Install either Visual Studio with the **.NET desktop development** workload or the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). Then verify PowerShell can see it:

```powershell
dotnet --info
dotnet --list-runtimes
```

The SDK is required to build and test. The smaller .NET 10 Desktop Runtime is enough when testing only the published application.

## 2. Build from source

Until the branch is pushed, copy the repository folder to the VM as a ZIP. Afterwards it can be cloned and checked out normally.

```powershell
cd C:\work\Snek
dotnet restore Snek.sln
dotnet format Snek.sln --verify-no-changes --no-restore
dotnet build Snek.sln --configuration Release --no-restore
dotnet run --project Snek.Tests\Snek.Tests.csproj --configuration Release --no-build -- -noLogo
dotnet run --project Snek\Snek.csproj --configuration Release
```

Alternatively, download the `Snek-win-x64-<commit>` artifact from a successful GitHub Actions run, extract it, and start `Snek.exe`.

## 3. UI smoke test

Check these items at both 100% and 150% Windows display scaling:

- The main window opens with a dark native title bar, Visual Studio-like blue accent, sidebar, status bar, and no clipped text.
- Resize, maximize, minimize, Alt+Tab, and keyboard Tab navigation work.
- `Ctrl+N` opens graph creation and `Ctrl+O` opens the file picker.
- Each navigation entry displays the correct Start, POS, or About page.
- Empty POS lists show helpful placeholder text rather than a blank area.

## 4. Graph workflow

1. Create each of the six graph types. Selection, double-click, Enter, and Escape must work.
2. Paste `12,5; -4; 0; 99.25` into the data editor. Four values must be accepted.
3. Enter `abc`. The inline error must appear and **Graph erstellen** must be disabled.
4. Use **Beispieldaten**, **Leeren**, and `Ctrl+Enter`.
5. Use **Werte bearbeiten** and verify the existing values are preserved in the editor.
6. Save with `Ctrl+S`, return home, reopen the `.snek` file, and compare the graph.
7. Export with `Ctrl+Shift+S`; open the resulting PNG and verify it is not blank or cropped.

## 5. Persistence and POS

- Select a contributor, a work item, and a time entry. The total must update and the UI must remain responsive.
- Close and reopen Snek. The database should remain at `%LOCALAPPDATA%\Snek\snek.db`.
- Back up that file, delete only the test VM copy, and restart once to verify migrations and seed data create a fresh database.
- Run the app a second time and confirm startup does not duplicate seed data.

## 6. Snake

- Steer with arrow keys and WASD; immediate reverse direction must be blocked.
- Pause and resume with Space.
- Eat a red item and verify the score increases by 10.
- Hit a wall, verify the Game Over overlay, then restart with `R`.
- Close with Escape and verify the main Snek Studio window stays open.

## 7. Report a UI problem

Capture a screenshot and record:

- Windows version and display scaling;
- exact action and expected/actual behavior;
- whether the app came from source or a CI artifact;
- the commit from `git rev-parse --short HEAD`.

For crashes, also check **Event Viewer → Windows Logs → Application** and include the `.NET Runtime` or `Application Error` entry.
