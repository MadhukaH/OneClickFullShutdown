
# 🔴 One-Click Full Shutdown for Windows

A lightweight C# application to perform a **true full shutdown** on Windows by bypassing Fast Startup. Optimized for ASUS ROG G16 gaming laptops.

---

## 🚀 Features

✅ **Bypasses Windows Fast Startup** - Ensures a complete shutdown  
✅ **Two versions included**: Console App & WinForms GUI  
✅ **Modern power button UI** - Beautiful gradient power icon with hover effects  
✅ **Force closes applications** - No hanging processes  
✅ **Administrator privileges** - Automatic UAC elevation  
✅ **Beginner-friendly** - Clean, simple code  

---

## 📦 What's Included

```
OneClickFullShutdown/
├── ConsoleShutdown/          # Console version (terminal-based)
│   ├── Program.cs
│   ├── ConsoleShutdown.csproj
│   └── app.manifest
├── WinFormsShutdown/         # GUI version (button-based)
│   ├── Form1.cs
│   ├── Program.cs
│   ├── WinFormsShutdown.csproj
│   └── app.manifest
└── OneClickFullShutdown.sln  # Visual Studio Solution
```

---

## 🛠️ How to Build in Visual Studio

### **Method 1: Open the Solution**
1. **Open** `OneClickFullShutdown.sln` in Visual Studio
2. **Build** both projects (or choose one):
   - Right-click on the project → **Build**
   - Or press `Ctrl+Shift+B` to build the entire solution

### **Method 2: Create New Project (Manual)**
If you prefer to create from scratch:

#### **For Console App:**
1. Create new **Console App** (.NET 6.0)
2. Replace `Program.cs` with the provided code
3. Add `app.manifest` file
4. Update `.csproj` to include `<ApplicationManifest>app.manifest</ApplicationManifest>`

#### **For WinForms App:**
1. Create new **Windows Forms App** (.NET 6.0)
2. Replace `Form1.cs` and `Program.cs` with provided code
3. Add `app.manifest` file
4. Update `.csproj` to include `<ApplicationManifest>app.manifest</ApplicationManifest>`

---

## ▶️ How to Use

### **Console Version:**
1. **Run** `ConsoleShutdown.exe`
2. Press **ENTER** when prompted
3. UAC dialog will appear - click **Yes**
4. PC shuts down immediately

### **WinForms Version:**
1. **Run** `WinFormsShutdown.exe`
2. Click the **large power button icon** (or the "SHUTDOWN NOW" button)
3. Confirm in the dialog
4. UAC dialog will appear - click **Yes**
5. PC shuts down immediately

**UI Features:**
- 🎨 Modern dark theme with cyan accents
- 🔘 Large clickable gradient power button (hover to enlarge)
- 🎯 Secondary text button for alternative access
- ✅ Clean, professional gaming aesthetic

---

## 🔐 Administrator Privileges

Both apps include an `app.manifest` that requests admin rights automatically. When you run the executable, Windows will show a UAC prompt.

**Why admin is needed?**  
The `shutdown` command requires elevated privileges to force-close applications and perform system shutdown.

---

## 🎯 Command Explained

```bash
shutdown /s /f /t 0
```

- `/s` = **Shutdown** the computer
- `/f` = **Force** close all running applications
- `/t 0` = **Timeout** of 0 seconds (immediate)

This command bypasses **Fast Startup** and performs a **real full shutdown**, which is ideal for:
- Gaming laptops (like ASUS ROG G16)
- Clearing RAM completely
- Troubleshooting hardware/driver issues
- Ensuring clean reboots

---

## 📝 Code Overview

### **Console App** (`Program.cs`)
- Simple terminal interface
- Press ENTER to shutdown
- Error handling for missing admin privileges

### **WinForms App** (`Form1.cs`)
- Modern dark-themed GUI with gradient colors
- **Large clickable power button image** (200x200px with hover zoom)
- Secondary text button as backup option
- Confirmation dialog before shutdown
- Hover effects and smooth interactions
- User-friendly error messages

---

## 🎮 Optimized for ASUS ROG G16

This tool is perfect for gaming laptops where:
- **Fast Startup** can cause issues with drivers
- You need a **clean shutdown** before hardware changes
- You want to **clear RAM** completely

---

## 📄 Requirements

- **Windows 10/11**
- **.NET 6.0 Runtime** (or .NET SDK for building)
- **Administrator privileges**

---

## 🔧 Troubleshooting

**Problem:** "Access Denied" error  
**Solution:** Right-click the `.exe` → **Run as Administrator**

**Problem:** UAC prompt doesn't appear  
**Solution:** Ensure `app.manifest` is included in the project

**Problem:** "Shutdown failed"  
**Solution:** Check if you have pending updates or programs preventing shutdown

---

## 📌 Additional Notes

- **Safe to use** - Uses Windows built-in `shutdown` command
- **No registry changes** - Doesn't modify system settings
- **Portable** - Can be run from anywhere (USB drive, Desktop, etc.)

---

## 🏗️ Build Output Location

After building, your executables will be in:
```
ConsoleShutdown/bin/Debug/net6.0/ConsoleShutdown.exe
WinFormsShutdown/bin/Debug/net6.0/WinFormsShutdown.exe
```

For production builds (smaller file size):
```
ConsoleShutdown/bin/Release/net6.0/ConsoleShutdown.exe
WinFormsShutdown/bin/Release/net6.0/WinFormsShutdown.exe
```

---

## 💡 Tips

1. **Pin to Taskbar**: Right-click the `.exe` → **Pin to taskbar** for one-click access
2. **Create Shortcut**: Make a desktop shortcut with custom icon
3. **Keyboard Shortcut**: Assign a hotkey to the shortcut (e.g., `Ctrl+Alt+S`)

---

## 📜 License

Free to use and modify. No warranty provided.

---

**Enjoy your one-click full shutdown! 🚀**
=======
# OneClickFullShutdown 🚀

A simple **C# Windows tool** that performs a **true / full shutdown** with one click.  
It bypasses Windows **Fast Startup (Hybrid Shutdown)** to fully power off your laptop or PC.

This is especially useful for **gaming laptops** like **ASUS ROG G16**, where fans, RGB, or LEDs may stay ON after shutdown.

---

## 🔥 Why this tool?

Windows “Shut down” is **not a real shutdown** when Fast Startup is enabled.  
It can cause:

- Fans still spinning after shutdown
- RGB / keyboard lights staying ON
- Driver & GPU issues
- Power not fully cutting off

👉 This tool fixes that.

---

## ✅ Features

- ✔ One-click **full shutdown**
- ✔ Bypasses **Fast Startup**
- ✔ Forces all apps to close
- ✔ Turns **fan, LED, RGB fully OFF**
- ✔ Lightweight & fast
- ✔ Written in **C# (.NET)**

---

## 🧩 How it works

It uses the Windows shutdown command:

```cmd
shutdown /s /f /t 0
>>>>>>> d4875d941e5a4ac3de78620371e01ad0e9a86190
