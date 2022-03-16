Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

start powershell { choco install git -y }

start powershell { choco install dotnet -y }

start powershell { mkdir 'C:\Projects\SetupProject\'; cd 'C:\Projects\SetupProject\'; git clone 'https://github.com/RMSteenwijk/MDSS.SetupWinPc.git' }

start powershell { cd 'C:\Projects\SetupProject\MDSS.SetupWinPc\DownloadNewTerminal'; dotnet run }