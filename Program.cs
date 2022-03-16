using System;
using System.Text;
using System.Threading;
using Spectre.Console;

namespace MDSS.SetupWinPC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Some Spinner and Emoij don't work without the lower
            System.Console.OutputEncoding = Encoding.UTF8;

            AnsiConsole.MarkupLine(":construction: Setting up Applications :construction:");
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Aesthetic)
                .Start("Working...", ctx => 
                {
                    AnsiConsole.MarkupLine(":construction: Copying settings :construction:");
                    new SettingsCopier().CopySettings();            
                    Thread.Sleep(1000 * 10);
                });
        }
    }
}
