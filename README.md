# DesignModeHelper

`DesignModeHelper` is a simple utility class for C# WinForms applications that helps determine whether your code is being executed in **design mode** (inside Visual Studio Designer) or at **runtime**.

## 🚀 Why use it?

When using external dependencies such as SQLite, you might encounter errors like:

> `SQLite.Interop.dll not found` or similar

These occur because Visual Studio tries to **instantiate your forms or controls at design-time**, triggering runtime code.

`DesignModeHelper` prevents that by detecting design mode safely.

## 🔧 Features

- Reliable design-time detection
- Works in Forms, UserControls, and Components
- Lazy-evaluated and cached for performance
- Avoids unnecessary constructor logic at design-time

## 🧪 Example Usage

```csharp
private async void MyControl_VisibleChanged(object sender, EventArgs e)
{
    if (DesignModeHelper.IsInDesignMode(this))
        return;

    await LoadDataAsync();
}
