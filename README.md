# Enhanced Pointer Precision Toggler

A Windows application that lives in your system tray which can be used to toggle
Windows Enhanced Pointer Precision (Mouse Acceleration) on and off via a global
hotkey.

Default hotkey is: Ctrl-F12

## Build

Builds on Visual Studio Community 2022 w/.Net 8.

This program uses GlobalHotKeys library from https://github.com/8/GlobalHotKeys
```
dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json
dotnet add package GlobalHotKeys.Windows
```

## Author:

Kris Hunt ([@sourcekris](https://github.com/sourcekris))
