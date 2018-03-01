[Files]
Source: "BalancaSolutionSetup.xml"; DestDir: "{app}"
Source: "Input\BalancaOlvebra.exe"; DestDir: "{app}"
Source: "Input\AtuaVer.exe"; DestDir: "{app}"
Source: "Input\balanca.db"; DestDir: "{app}"; Flags: onlyifdoesntexist
Source: "Input\*.dll"; DestDir: "{app}"
Source: "Input\*.config"; DestDir: "{app}"

[Setup]
AppName=Balanca Olvebra
AppVersion=Balanca Olvebra
DirExistsWarning=no
PrivilegesRequired=lowest
DefaultGroupName=Olvebra\Balanca
AppID=BalancaOlvebra
UninstallDisplayIcon={app}\Balanca.exe
UninstallDisplayName=Balanca Olvebra
DefaultDirName={localappdata}\Olvebra\BalancaOlvebra
DisableProgramGroupPage=yes
UpdateUninstallLogAppName=false
UsePreviousGroup=false
DisableDirPage=yes
AppMutex=BalancaOlvebra
VersionInfoProductName=Balanca Olvebra
OutputBaseFilename=BalancaSolutionSetup
VersionInfoVersion=1.0.0.0
VersionInfoProductVersion=1.0.0.26
VersionInfoCompany=Olvebra Industrial SA
ShowLanguageDialog=no
MinVersion=4.1.1998,5.01.2600
AlwaysUsePersonalGroup=true
VersionInfoDescription=Balanca Solution Olvebra

[Icons]
Name: "{group}\Balanca Olvebra"; Filename: "{app}\BalancaOlvebra.exe"; WorkingDir: "{app}"; IconFilename: "{app}\BalancaOlvebra.exe"
Name: "{group}\{cm:UninstallProgram,Balanca Solution Olvebra}"; Filename: "{uninstallexe}"
Name: "{group}\Atualizar o programa"; Filename: "{app}\AtuaVer.exe"; WorkingDir: "{app}"; IconFilename: "{app}\AtuaVer.exe"; Parameters: "-stub -f BalancaOlvebraSetup.xml"
Name: "{commondesktop}\Balanca Olvebra"; Filename: "{app}\BalancaOlvebra.exe"; Tasks: desktopicon

[Languages]
Name: ptbr; MessagesFile: compiler:Languages\BrazilianPortuguese.isl

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

