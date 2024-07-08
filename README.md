# Enhanced Pointer Precision Toggler

A Windows application that lives in your system tray which can be used to toggle
Windows Enhanced Pointer Precision (Mouse Acceleration) on and off via a global
hotkey.

## Hotkey Configuration

The default hotkey is Ctrl-F12 but can be changed in the UI. Simply select the
desired modifier (e.g. Control, Alt, Shift, etc) and key. The key names are
prefixed with "VK_" but to use F11 for example simply select "VK_F11".

## Build

Builds on Visual Studio Community 2022 w/.Net 8.

This program uses GlobalHotKeys library from https://github.com/8/GlobalHotKeys
```
dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json
dotnet add package GlobalHotKeys.Windows
```

## Author:

Kris Hunt ([@sourcekris](https://github.com/sourcekris))
