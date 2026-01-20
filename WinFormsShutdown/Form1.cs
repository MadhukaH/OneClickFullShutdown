using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsShutdown
{
    public partial class Form1 : Form
    {
        private PictureBox powerButton;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Full Shutdown Utility";
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Size = new Size(500, 550);

            // Set custom icon from PNG
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "power_button.png");
                if (File.Exists(iconPath))
                {
                    using (var img = Image.FromFile(iconPath))
                    {
                        var bitmap = new Bitmap(img, new Size(256, 256));
                        IntPtr hIcon = bitmap.GetHicon();
                        this.Icon = Icon.FromHandle(hIcon);
                    }
                }
            }
            catch
{
                // If icon loading fails, continue with default icon
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Title Label
            Label titleLabel = new Label
            {
                Text = "FULL SHUTDOWN",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 200, 200),
                AutoSize = true,
                Location = new Point(100, 30)
            };

            // Subtitle Label
            Label subtitleLabel = new Label
            {
                Text = "Bypasses Fast Startup for complete shutdown",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(200, 200, 200),
                AutoSize = true,
                Location = new Point(80, 75)
            };

            // Power Button Image (Clickable)
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "power_button.png");
            powerButton = new PictureBox
            {
                Size = new Size(200, 200),
                Location = new Point(150, 130),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand
            };

            // Load image if exists, otherwise show placeholder
            if (File.Exists(imagePath))
            {
                powerButton.Image = Image.FromFile(imagePath);
            }
            else
            {
                // Fallback: Create a simple power icon programmatically
                powerButton.BackColor = Color.FromArgb(60, 60, 60);
            }

            // Add click event
            powerButton.Click += PowerButton_Click;

            // Add hover effects
            powerButton.MouseEnter += (s, e) =>
            {
                powerButton.Size = new Size(210, 210);
                powerButton.Location = new Point(145, 125);
            };
            powerButton.MouseLeave += (s, e) =>
            {
                powerButton.Size = new Size(200, 200);
                powerButton.Location = new Point(150, 130);
            };

            // Click instruction
            Label clickLabel = new Label
            {
                Text = "Click the power button to shutdown",
                Font = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                Location = new Point(120, 350)
            };

            // Info Label
            Label infoLabel = new Label
            {
                Text = "⚡ ASUS ROG G16 Optimized\n🔒 Requires Administrator Privileges",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(150, 150, 150),
                AutoSize = true,
                Location = new Point(120, 395),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Text Button (Secondary option)
            Button shutdownButton = new Button
            {
                Text = "SHUTDOWN NOW",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(250, 50),
                Location = new Point(125, 450),
                BackColor = Color.FromArgb(40, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            shutdownButton.FlatAppearance.BorderSize = 0;
            shutdownButton.Click += ShutdownButton_Click;

            // Add hover effect to text button
            shutdownButton.MouseEnter += (s, e) => shutdownButton.BackColor = Color.FromArgb(60, 200, 200);
            shutdownButton.MouseLeave += (s, e) => shutdownButton.BackColor = Color.FromArgb(40, 160, 160);

            // Add controls to form
            this.Controls.Add(titleLabel);
            this.Controls.Add(subtitleLabel);
            this.Controls.Add(powerButton);
            this.Controls.Add(clickLabel);
            this.Controls.Add(infoLabel);
            this.Controls.Add(shutdownButton);

            this.ResumeLayout(false);
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            PerformShutdown();
        }

        private void ShutdownButton_Click(object sender, EventArgs e)
        {
            PerformShutdown();
        }

        private void PerformShutdown()
        {
            // Confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to perform a FULL SHUTDOWN?\n\n" +
                "This will:\n" +
                "• Force close all applications\n" +
                "• Bypass Windows Fast Startup\n" +
                "• Perform a complete shutdown\n\n" +
                "Continue?",
                "Confirm Full Shutdown",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Execute full shutdown command
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "shutdown",
                        Arguments = "/s /f /t 0",
                        Verb = "runas", // Request admin privileges
                        UseShellExecute = true,
                        CreateNoWindow = true
                    };

                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error initiating shutdown:\n\n{ex.Message}\n\n" +
                        "Please ensure this application is run as Administrator.",
                        "Shutdown Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
