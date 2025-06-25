# CustomBottomsheet for .NET MAUI

This project provides a reusable `CustomBottomsheet` class that makes **bottom sheets on Android look and behave more like iOS**, creating a unified and polished user experience across platforms.

---

## What It Solves

Bottom Sheets on Android now behave like they do on iOS:

-  **Dimmed background** for better focus
-  **Proper cleanup** of active bottom sheets
-  **Cancelable by tapping outside**
-  **Only one bottom sheet active at a time**

---

## How It Works

The `CustomBottomsheet` class extends `The49.Maui.BottomSheet` and:

- Automatically adjusts the `MainPage.Opacity` when shown/dismissed on Android
- Handles sheet cleanup to avoid stacking multiple sheets
- Provides a consistent API for use in your views and view models
