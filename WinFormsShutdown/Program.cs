using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormsShutdown
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show immediate confirmation dialog
            DialogResult result = MessageBox.Show(
                "Perform FULL SHUTDOWN now?\n\n" +
                "This will:\n" +
                "• Force close all applications\n" +
                "• Bypass Windows Fast Startup\n" +
                "• Perform complete shutdown\n\n" +
                "Continue?",
                "Full Shutdown - ASUS ROG G16",
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
