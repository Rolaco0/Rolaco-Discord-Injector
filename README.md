# Rolaco Discord Injector

<div align="center">
  <img src="https://img.shields.io/badge/Version-2.0.0-blue?style=for-the-badge" alt="Version">
  <img src="https://img.shields.io/badge/Platform-Windows-00adee?style=for-the-badge" alt="Platform">
  <img src="https://img.shields.io/badge/Discord-Stable%20%7C%20PTB%20%7C%20Canary-5865F2?style=for-the-badge" alt="Discord">
</div>

<p align="center">
  <b>A Windows tool to inject and manage the Rolaco Completer script in Discord</b>
</p>

---

## 📋 Overview

Rolaco Discord Injector is a Windows Forms application that allows you to inject the **Rolaco Completer** script into Discord with a simple interface, providing control over injection, removal, and status monitoring.

---

## ✨ Features

### 🚀 User Interface
- Modern UI with clean color gradients  
- Draggable window  
- Minimize to system tray  
- Live status and progress indicators  

### 💉 Injection System
- Automatic injection of Rolaco Completer  
- Supports Discord Stable, PTB, and Canary  
- Automatic backup of original files  
- Discord auto-restart after injection  

### 🧹 Safe Removal
- Complete removal of injected script  
- Restore original files from backup  
- Cleanup of temporary `rolaco.js` files  

### 🔍 Scan & Monitoring
- Detect Discord running state (open / closed)  
- Detect existing injection  
- Scan a specific Discord version only  

---

## 🎯 Rolaco Completer Features

After injection, you get a full quest automation panel inside Discord.

### ⚡ Smart System
- Auto-accept new quests  
- Auto-start accepted quests  
- Quest queue management  
- Up to 3 quests processed simultaneously  

### 📊 Quest Interface
- Active quests with progress percentage  
- Total rewards counter  
- Animated status indicators  
- Notifications on quest completion  

### 🔄 Advanced Simulation
- Game running simulation  
- Stream simulation  
- Voice channel activity simulation  
- Periodic progress updates  

---

## 🎮 Supported Quest Types

- ✅ WATCH_VIDEO  
- ✅ PLAY_ON_DESKTOP  
- ✅ STREAM_ON_DESKTOP  
- ✅ PLAY_ACTIVITY  

---

## 📥 Download

<p align="center">
  <a href="https://github.com/yourusername/DiscordInjector/releases">
    <img src="https://img.shields.io/badge/Download-Latest_Release-brightgreen?style=for-the-badge&logo=github" alt="Download">
  </a>
</p>

---

## 🚀 Usage Guide

### Installation
1. Download the latest release  
2. Extract the archive  
3. Run `DiscordInjector.exe`  

### Automatic Injection
1. Select your Discord version from the dropdown  
2. Make sure Discord is closed (the tool can close it automatically)  
3. Click **Inject**  
4. Wait for completion (Discord will restart automatically)  
5. Inside Discord, press **INS** to show the Rolaco panel  

### Removal
1. Select the same Discord version  
2. Click **Remove**  
3. Discord will close, remove the injection, and restart  

### Scan
- Click **Scan** to check for existing injection  
- Status indicator shows Discord state in real time  

---

## 🔧 Manual Injection

If the tool does not work, you can inject manually:

<p align="center">
  <a href="https://gist.githubusercontent.com/Rolaco0/a131d6aeb8ffdddfe92624988b9c93ef/raw/f67012daa26ade3d6041b6f8dbb13e226254c0ec/Quest.txt" target="_blank">
    <img src="https://img.shields.io/badge/Copy%20the%20script-Quest.txt-5865F2?style=for-the-badge&logo=javascript" alt="1. Copy the script">
  </a>
</p>

2. Open Discord and press `Ctrl + Shift + I`  
3. Go to the **Console** tab  
4. Paste the code and press **Enter**  
5. Rolaco interface will appear automatically  

---

## ⚙️ Requirements

- OS: Windows 10 / 11 (64-bit)  
- .NET: .NET 6.0 or newer  
- Discord: Stable, PTB, or Canary  

---

## ⚠️ Important Notes

- Use at your own risk  
- The tool does **not** modify `core.asar`  
- Automatic backup of `index.js` is created  
- Close Discord before injection for best results  

---

## 📞 Support

- Report issues via **GitHub Issues**

---

## 📜 License

This project is licensed under the **MIT License**

---

<p align="center">
  <b>© 2024 Rolaco Discord Injector</b><br>
  <sub>Made for learning and experimentation</sub>
</p>

---

⭐ If you like the project, consider giving it a star on GitHub.
