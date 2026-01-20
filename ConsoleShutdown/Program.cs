using System;
using System.Diagnostics;

namespace ConsoleShutdown
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   ONE-CLICK FULL SHUTDOWN UTILITY         ║");
            Console.WriteLine("║   Bypasses Fast Startup for clean reboot  ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝\n");

            Console.WriteLine("Press ENTER to initiate FULL SHUTDOWN...");
            Console.ReadLine();

            try
            {
                // Execute full shutdown command
                // /s = shutdown
                // /f = force close applications
                // /t 0 = timeout 0 seconds
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "/s /f /t 0",
                    Verb = "runas", // Request admin privileges
                    UseShellExecute = true,
                    CreateNoWindow = true
                };

                Process.Start(psi);
                Console.WriteLine("✓ Shutdown initiated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error: {ex.Message}");
                Console.WriteLine("\nMake sure to run this application as Administrator.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
