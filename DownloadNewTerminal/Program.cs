using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DownloadNewTerminal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "RMSteenwijk");
            var textResult = await httpClient.GetStringAsync("https://api.github.com/repos/microsoft/terminal/releases/latest");
            var getCorrectAsset = JObject.Parse(textResult);

            foreach(var release in getCorrectAsset["assets"])
            {
                var name = release["name"].ToObject<string>();
                if(name.EndsWith("msixbundle"))
                {
                    var downloadUrl = release["browser_download_url"].ToObject<string>();
                    Console.WriteLine($"Most recent release {downloadUrl}");
                    
                    var terminalPackage = await httpClient.GetByteArrayAsync(downloadUrl);
                    await File.WriteAllBytesAsync("newTerminal.msixbundle", terminalPackage);
                }
            }
            RunFile("newTerminal.msixbundle");

        }

        private static int RunFile(string name)
        {
            var fullPath = Path.GetFullPath("newTerminal.msixbundle");
            Console.WriteLine(fullPath);

            ProcessStartInfo psi = new ProcessStartInfo("Powershell.exe", 
            $"newTerminalInstall.ps1 -PackagePath " + fullPath);
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                if (process.HasExited)
                    return process.ExitCode;
            }
            return 1;
        }
    }
}
