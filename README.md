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
