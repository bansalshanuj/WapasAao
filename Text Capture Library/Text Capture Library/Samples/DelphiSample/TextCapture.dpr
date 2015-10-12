program TextCapture;

uses
  Forms,
  Main in 'Main.pas' {FrmMain},
  ActiveWindow in 'ActiveWindow.pas' {FrmActiveWindow};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFrmMain, FrmMain);
  Application.CreateForm(TFrmActiveWindow, FrmActiveWindow);
  Application.Run;
end.
