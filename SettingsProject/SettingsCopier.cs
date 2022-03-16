using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Spectre.Console;

namespace MDSS.SetupWinPC
{
    public class SettingsCopier
    {
        private readonly Dictionary<string, SettingsInfo> _settings = new Dictionary<string, SettingsInfo>()
        { 
            { "vsCodeSettings", new SettingsInfo
                {
                    TargetPath = @"{0}\Code\User\settings2.json",
                    RootTargetPath = Environment.SpecialFolder.ApplicationData,
                    OriginSettingsPath = @"ApplicationSettings\Code.json"
                }
            }
        };

        public void CopySettings()
        {
            foreach(var setting in _settings)
            {
                AnsiConsole.MarkupLine($"Copying... {setting.Key} file");
                _copySettings(setting.Value);
            }
        }

        private void _copySettings(SettingsInfo setting)
        {
            var targetPath = string.Format(setting.TargetPath, Environment.GetFolderPath(setting.RootTargetPath));

            File.WriteAllText(targetPath, File.ReadAllText(Path.GetFullPath(setting.OriginSettingsPath)));
        }


    }
}
