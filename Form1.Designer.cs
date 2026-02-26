using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace DiscordInjector
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private WebView2 webView2;
        private Panel mainPanel;
        private Panel glassPanel;
        private ComboBox discordTypeCombo;
        private Button injectButton;
        private Button removeButton;
        private Button minimizeButton;
        private Button closeButton;
        private Label statusLabel;
        private ProgressBar progressBar;
        private Panel titleBar;
        private Label titleLabel;
        private Label versionLabel;
        private Panel navPanel;
        private Label typeLabel;
        private Button scanButton;
        private Panel contentPanel;
        private Label featuresTitle;
        private Panel infoPanel;
        private Label infoTitle;
        private Panel card1;
        private Panel card2;
        private Panel card3;
        private Panel card4;
        private Label stepLabel1;
        private Label stepLabel2;
        private Label stepLabel3;
        private Label stepLabel4;
        private Label stepLabel5;

        private Panel accentBar1;
        private Panel accentBar2;
        private Panel accentBar3;
        private Panel accentBar4;
        private Label title1;
        private Label title2;
        private Label title3;
        private Label title4;
        private Label desc1;
        private Label desc2;
        private Label desc3;
        private Label desc4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            glassPanel = new Panel();
            mainPanel = new Panel();
            titleBar = new Panel();
            titleLabel = new Label();
            versionLabel = new Label();
            minimizeButton = new Button();
            closeButton = new Button();
            navPanel = new Panel();
            typeLabel = new Label();
            discordTypeCombo = new ComboBox();
            injectButton = new Button();
            removeButton = new Button();
            scanButton = new Button();
            statusLabel = new Label();
            progressBar = new ProgressBar();
            webView2 = new WebView2();
            contentPanel = new Panel();
            featuresTitle = new Label();
            card1 = new Panel();
            accentBar1 = new Panel();
            title1 = new Label();
            desc1 = new Label();
            card2 = new Panel();
            accentBar2 = new Panel();
            title2 = new Label();
            desc2 = new Label();
            card3 = new Panel();
            accentBar3 = new Panel();
            title3 = new Label();
            desc3 = new Label();
            card4 = new Panel();
            accentBar4 = new Panel();
            title4 = new Label();
            desc4 = new Label();
            infoPanel = new Panel();
            infoTitle = new Label();
            stepLabel1 = new Label();
            stepLabel2 = new Label();
            stepLabel3 = new Label();
            stepLabel4 = new Label();
            stepLabel5 = new Label();
            titleBar.SuspendLayout();
            navPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            contentPanel.SuspendLayout();
            card1.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            card4.SuspendLayout();
            infoPanel.SuspendLayout();
            SuspendLayout();

            glassPanel.BackColor = Color.FromArgb(10, 0, 0, 0);
            glassPanel.Dock = DockStyle.Fill;
            glassPanel.Location = new Point(0, 0);
            glassPanel.Name = "glassPanel";
            glassPanel.Size = new Size(984, 661);
            glassPanel.TabIndex = 6;

            mainPanel.BackColor = Color.FromArgb(15, 15, 20);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(2);
            mainPanel.Size = new Size(984, 661);
            mainPanel.TabIndex = 5;

            titleBar.BackColor = Color.FromArgb(25, 25, 35);
            titleBar.Controls.Add(titleLabel);
            titleBar.Controls.Add(versionLabel);
            titleBar.Controls.Add(minimizeButton);
            titleBar.Controls.Add(closeButton);
            titleBar.Cursor = Cursors.SizeAll;
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(984, 60);
            titleBar.TabIndex = 4;

            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(25, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(252, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Rolaco Discord Injector";

            versionLabel.AutoSize = true;
            versionLabel.BackColor = Color.Transparent;
            versionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            versionLabel.ForeColor = Color.FromArgb(0, 200, 150);
            versionLabel.Location = new Point(276, 23);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(49, 19);
            versionLabel.TabIndex = 1;
            versionLabel.Text = "v2.0.0";

            minimizeButton.BackColor = Color.FromArgb(45, 45, 55);
            minimizeButton.Cursor = Cursors.Hand;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            minimizeButton.ForeColor = Color.White;
            minimizeButton.Location = new Point(905, 12);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(40, 35);
            minimizeButton.TabIndex = 2;
            minimizeButton.Text = "—";
            minimizeButton.UseVisualStyleBackColor = false;

            closeButton.BackColor = Color.FromArgb(200, 60, 60);
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(950, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(40, 35);
            closeButton.TabIndex = 3;
            closeButton.Text = "✕";
            closeButton.UseVisualStyleBackColor = false;

            navPanel.BackColor = Color.FromArgb(20, 20, 28);
            navPanel.Controls.Add(typeLabel);
            navPanel.Controls.Add(discordTypeCombo);
            navPanel.Controls.Add(injectButton);
            navPanel.Controls.Add(removeButton);
            navPanel.Controls.Add(scanButton);
            navPanel.Dock = DockStyle.Top;
            navPanel.Location = new Point(0, 60);
            navPanel.Name = "navPanel";
            navPanel.Padding = new Padding(30, 20, 30, 20);
            navPanel.Size = new Size(984, 100);
            navPanel.TabIndex = 3;

            typeLabel.AutoSize = true;
            typeLabel.BackColor = Color.Transparent;
            typeLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            typeLabel.ForeColor = Color.FromArgb(180, 180, 190);
            typeLabel.Location = new Point(30, 10);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(163, 20);
            typeLabel.TabIndex = 0;
            typeLabel.Text = "Select Discord Version";

            discordTypeCombo.BackColor = Color.FromArgb(35, 35, 45);
            discordTypeCombo.DrawMode = DrawMode.OwnerDrawFixed;
            discordTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            discordTypeCombo.FlatStyle = FlatStyle.Flat;
            discordTypeCombo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            discordTypeCombo.ForeColor = Color.White;
            discordTypeCombo.Items.AddRange(new object[] { "Discord", "Discord PTB", "Discord Canary" });
            discordTypeCombo.Location = new Point(30, 35);
            discordTypeCombo.Name = "discordTypeCombo";
            discordTypeCombo.Size = new Size(220, 28);
            discordTypeCombo.TabIndex = 1;

            injectButton.BackColor = Color.FromArgb(0, 170, 140);
            injectButton.Cursor = Cursors.Hand;
            injectButton.FlatAppearance.BorderSize = 0;
            injectButton.FlatStyle = FlatStyle.Flat;
            injectButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            injectButton.ForeColor = Color.White;
            injectButton.Location = new Point(280, 30);
            injectButton.Name = "injectButton";
            injectButton.Size = new Size(130, 45);
            injectButton.TabIndex = 2;
            injectButton.Text = "Inject";
            injectButton.UseVisualStyleBackColor = false;

            removeButton.BackColor = Color.FromArgb(200, 70, 70);
            removeButton.Cursor = Cursors.Hand;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            removeButton.ForeColor = Color.White;
            removeButton.Location = new Point(430, 30);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(130, 45);
            removeButton.TabIndex = 3;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = false;

            scanButton.BackColor = Color.FromArgb(70, 70, 180);
            scanButton.Cursor = Cursors.Hand;
            scanButton.FlatAppearance.BorderSize = 0;
            scanButton.FlatStyle = FlatStyle.Flat;
            scanButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            scanButton.ForeColor = Color.White;
            scanButton.Location = new Point(580, 30);
            scanButton.Name = "scanButton";
            scanButton.Size = new Size(130, 45);
            scanButton.TabIndex = 4;
            scanButton.Text = "Scan";
            scanButton.UseVisualStyleBackColor = false;

            statusLabel.BackColor = Color.FromArgb(25, 25, 35);
            statusLabel.Dock = DockStyle.Bottom;
            statusLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            statusLabel.ForeColor = Color.FromArgb(200, 200, 210);
            statusLabel.Location = new Point(0, 616);
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(25, 0, 0, 0);
            statusLabel.Size = new Size(984, 45);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "● Ready to inject";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;

            progressBar.Dock = DockStyle.Bottom;
            progressBar.Location = new Point(0, 612);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(984, 4);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 1;
            progressBar.Visible = false;

            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.White;
            webView2.Dock = DockStyle.Fill;
            webView2.Location = new Point(25, 25);
            webView2.Name = "webView2";
            webView2.Size = new Size(917, 459);
            webView2.TabIndex = 6;
            webView2.Visible = false;
            webView2.ZoomFactor = 1D;

            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(18, 18, 24);
            contentPanel.Controls.Add(featuresTitle);
            contentPanel.Controls.Add(card1);
            contentPanel.Controls.Add(card2);
            contentPanel.Controls.Add(card3);
            contentPanel.Controls.Add(card4);
            contentPanel.Controls.Add(infoPanel);
            contentPanel.Controls.Add(webView2);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 160);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(25);
            contentPanel.Size = new Size(984, 452);
            contentPanel.TabIndex = 0;

            featuresTitle.AutoSize = true;
            featuresTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            featuresTitle.ForeColor = Color.White;
            featuresTitle.Location = new Point(25, 20);
            featuresTitle.Name = "featuresTitle";
            featuresTitle.Size = new Size(126, 37);
            featuresTitle.TabIndex = 0;
            featuresTitle.Text = "Features";

            card1.BackColor = Color.FromArgb(30, 30, 40);
            card1.Controls.Add(accentBar1);
            card1.Controls.Add(title1);
            card1.Controls.Add(desc1);
            card1.Location = new Point(25, 70);
            card1.Name = "card1";
            card1.Size = new Size(210, 160);
            card1.TabIndex = 1;

            accentBar1.BackColor = Color.FromArgb(0, 200, 150);
            accentBar1.Dock = DockStyle.Top;
            accentBar1.Location = new Point(0, 0);
            accentBar1.Name = "accentBar1";
            accentBar1.Size = new Size(210, 5);
            accentBar1.TabIndex = 0;

            title1.AutoSize = true;
            title1.BackColor = Color.Transparent;
            title1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            title1.ForeColor = Color.White;
            title1.Location = new Point(35, 30);
            title1.Name = "title1";
            title1.Size = new Size(133, 25);
            title1.TabIndex = 2;
            title1.Text = "Safe Injection";

            desc1.BackColor = Color.Transparent;
            desc1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            desc1.ForeColor = Color.FromArgb(150, 150, 160);
            desc1.Location = new Point(12, 70);
            desc1.Name = "desc1";
            desc1.Size = new Size(180, 40);
            desc1.TabIndex = 3;
            desc1.Text = "Only modifies index.js, core.asar remains untouched";

            card2.BackColor = Color.FromArgb(30, 30, 40);
            card2.Controls.Add(accentBar2);
            card2.Controls.Add(title2);
            card2.Controls.Add(desc2);
            card2.Location = new Point(250, 70);
            card2.Name = "card2";
            card2.Size = new Size(210, 160);
            card2.TabIndex = 2;

            accentBar2.BackColor = Color.FromArgb(0, 150, 200);
            accentBar2.Dock = DockStyle.Top;
            accentBar2.Location = new Point(0, 0);
            accentBar2.Name = "accentBar2";
            accentBar2.Size = new Size(210, 5);
            accentBar2.TabIndex = 0;

            title2.AutoSize = true;
            title2.BackColor = Color.Transparent;
            title2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            title2.ForeColor = Color.White;
            title2.Location = new Point(30, 30);
            title2.Name = "title2";
            title2.Size = new Size(131, 25);
            title2.TabIndex = 2;
            title2.Text = "Instant Apply";

            desc2.BackColor = Color.Transparent;
            desc2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            desc2.ForeColor = Color.FromArgb(150, 150, 160);
            desc2.Location = new Point(15, 68);
            desc2.Name = "desc2";
            desc2.Size = new Size(180, 40);
            desc2.TabIndex = 3;
            desc2.Text = "Works immediately after injection";

            card3.BackColor = Color.FromArgb(30, 30, 40);
            card3.Controls.Add(accentBar3);
            card3.Controls.Add(title3);
            card3.Controls.Add(desc3);
            card3.Location = new Point(475, 70);
            card3.Name = "card3";
            card3.Size = new Size(210, 160);
            card3.TabIndex = 3;

            accentBar3.BackColor = Color.FromArgb(200, 150, 0);
            accentBar3.Dock = DockStyle.Top;
            accentBar3.Location = new Point(0, 0);
            accentBar3.Name = "accentBar3";
            accentBar3.Size = new Size(210, 5);
            accentBar3.TabIndex = 0;

            title3.AutoSize = true;
            title3.BackColor = Color.Transparent;
            title3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            title3.ForeColor = Color.White;
            title3.Location = new Point(49, 30);
            title3.Name = "title3";
            title3.Size = new Size(109, 25);
            title3.TabIndex = 2;
            title3.Text = "Modern UI";

            desc3.BackColor = Color.Transparent;
            desc3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            desc3.ForeColor = Color.FromArgb(150, 150, 160);
            desc3.Location = new Point(17, 68);
            desc3.Name = "desc3";
            desc3.Size = new Size(180, 40);
            desc3.TabIndex = 3;
            desc3.Text = "Beautiful and intuitive interface";

            card4.BackColor = Color.FromArgb(30, 30, 40);
            card4.Controls.Add(accentBar4);
            card4.Controls.Add(title4);
            card4.Controls.Add(desc4);
            card4.Location = new Point(700, 70);
            card4.Name = "card4";
            card4.Size = new Size(210, 160);
            card4.TabIndex = 4;

            accentBar4.BackColor = Color.FromArgb(200, 0, 150);
            accentBar4.Dock = DockStyle.Top;
            accentBar4.Location = new Point(0, 0);
            accentBar4.Name = "accentBar4";
            accentBar4.Size = new Size(210, 5);
            accentBar4.TabIndex = 0;

            title4.AutoSize = true;
            title4.BackColor = Color.Transparent;
            title4.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            title4.ForeColor = Color.White;
            title4.Location = new Point(35, 30);
            title4.Name = "title4";
            title4.Size = new Size(131, 25);
            title4.TabIndex = 2;
            title4.Text = "Safe Removal";

            desc4.BackColor = Color.Transparent;
            desc4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            desc4.ForeColor = Color.FromArgb(150, 150, 160);
            desc4.Location = new Point(27, 68);
            desc4.Name = "desc4";
            desc4.Size = new Size(180, 40);
            desc4.TabIndex = 3;
            desc4.Text = "Restores original files safely";

            infoPanel.BackColor = Color.FromArgb(25, 25, 35);
            infoPanel.Controls.Add(infoTitle);
            infoPanel.Controls.Add(stepLabel1);
            infoPanel.Controls.Add(stepLabel2);
            infoPanel.Controls.Add(stepLabel3);
            infoPanel.Controls.Add(stepLabel4);
            infoPanel.Controls.Add(stepLabel5);
            infoPanel.Location = new Point(25, 249);
            infoPanel.Name = "infoPanel";
            infoPanel.Padding = new Padding(20);
            infoPanel.Size = new Size(885, 260);
            infoPanel.TabIndex = 5;

            infoTitle.AutoSize = true;
            infoTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            infoTitle.ForeColor = Color.White;
            infoTitle.Location = new Point(20, 15);
            infoTitle.Name = "infoTitle";
            infoTitle.Size = new Size(143, 32);
            infoTitle.TabIndex = 0;
            infoTitle.Text = "How to use";

            stepLabel1.AutoSize = true;
            stepLabel1.BackColor = Color.Transparent;
            stepLabel1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stepLabel1.ForeColor = Color.FromArgb(200, 200, 210);
            stepLabel1.Location = new Point(30, 60);
            stepLabel1.Name = "stepLabel1";
            stepLabel1.Size = new Size(378, 20);
            stepLabel1.TabIndex = 1;
            stepLabel1.Text = "1. Select your Discord version from the dropdown menu";

            stepLabel2.AutoSize = true;
            stepLabel2.BackColor = Color.Transparent;
            stepLabel2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stepLabel2.ForeColor = Color.FromArgb(200, 200, 210);
            stepLabel2.Location = new Point(30, 90);
            stepLabel2.Name = "stepLabel2";
            stepLabel2.Size = new Size(335, 20);
            stepLabel2.TabIndex = 2;
            stepLabel2.Text = "2. Make sure Discord is closed before proceeding";

            stepLabel3.AutoSize = true;
            stepLabel3.BackColor = Color.Transparent;
            stepLabel3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stepLabel3.ForeColor = Color.FromArgb(200, 200, 210);
            stepLabel3.Location = new Point(30, 120);
            stepLabel3.Name = "stepLabel3";
            stepLabel3.Size = new Size(296, 20);
            stepLabel3.TabIndex = 3;
            stepLabel3.Text = "3. Click 'Inject' to apply the Rolaco injection";

            stepLabel4.AutoSize = true;
            stepLabel4.BackColor = Color.Transparent;
            stepLabel4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stepLabel4.ForeColor = Color.FromArgb(200, 200, 210);
            stepLabel4.Location = new Point(30, 150);
            stepLabel4.Name = "stepLabel4";
            stepLabel4.Size = new Size(429, 20);
            stepLabel4.TabIndex = 4;
            stepLabel4.Text = "4. Launch Discord and press the 'INS' key to toggle the interface";

            stepLabel5.AutoSize = true;
            stepLabel5.BackColor = Color.Transparent;
            stepLabel5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stepLabel5.ForeColor = Color.FromArgb(200, 200, 210);
            stepLabel5.Location = new Point(30, 180);
            stepLabel5.Name = "stepLabel5";
            stepLabel5.Size = new Size(417, 20);
            stepLabel5.TabIndex = 5;
            stepLabel5.Text = "5. Click 'Remove' to restore original files and remove injection";

            BackColor = Color.FromArgb(15, 15, 20);
            ClientSize = new Size(984, 661);
            Controls.Add(contentPanel);
            Controls.Add(progressBar);
            Controls.Add(statusLabel);
            Controls.Add(navPanel);
            Controls.Add(titleBar);
            Controls.Add(mainPanel);
            Controls.Add(glassPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rolaco Discord Injector";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            navPanel.ResumeLayout(false);
            navPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            card1.ResumeLayout(false);
            card1.PerformLayout();
            card2.ResumeLayout(false);
            card2.PerformLayout();
            card3.ResumeLayout(false);
            card3.PerformLayout();
            card4.ResumeLayout(false);
            card4.PerformLayout();
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}