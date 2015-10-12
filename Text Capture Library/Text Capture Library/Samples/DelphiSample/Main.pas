unit Main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms,Dialogs, StdCtrls, ExtCtrls,
  TextCaptureLib_TLB, OleServer;

type
  TFrmMain = class(TForm)
    M_CapturedText: TMemo;
    B_ClearText: TButton;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    E_Handle: TEdit;
    B_HandleCapture: TButton;
    GroupBox2: TGroupBox;
    C_WithScan1: TCheckBox;
    B_MouseCapture: TButton;
    GroupBox3: TGroupBox;
    E_Title: TEdit;
    B_TitleCapture: TButton;
    Label2: TLabel;
    GroupBox4: TGroupBox;
    B_ActiveWindow: TButton;
    GroupBox5: TGroupBox;
    Timer1: TTimer;
    LB_MousePosition: TLabel;
    Label3: TLabel;
    E_X: TEdit;
    E_Y: TEdit;
    Label4: TLabel;
    B_MouseXY: TButton;
    C_WithScan2: TCheckBox;
    C_WithScan3: TCheckBox;
    C_WithScan4: TCheckBox;
    procedure FormCreate(Sender: TObject);
    procedure B_MouseCaptureClick(Sender: TObject);
    procedure B_ClearTextClick(Sender: TObject);
    procedure B_HandleCaptureClick(Sender: TObject);
    procedure B_TitleCaptureClick(Sender: TObject);
    procedure B_ActiveWindowClick(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure B_MouseXYClick(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    { Private declarations }    //NJN: Added
    function  WaitUntilLoaded(FileName: String; Visibility: Integer): DWORD ;
  end;

var
  FrmMain       : TFrmMain;
  CaptureWindow : TCInputWindow ;
  CaptureText   : TCTextCapture ;

implementation

uses
  ActiveWindow ;

{$R *.dfm}
{------------------------------------------------------------------------------}
{ Wait until some external application or DLL is fully loaded.                 }
function TFrmMain.WaitUntilLoaded(FileName: String; Visibility: Integer): DWORD ;
var
  zAppName    : array[0..512] of Char ;
  StartupInfo : TStartupInfo ;
  ProcessInfo : TProcessInformation ;
begin
  StrPCopy(zAppName,FileName) ;
  FillChar(StartupInfo,Sizeof(StartupInfo),#0) ;
  StartupInfo.cb          := Sizeof(StartupInfo) ;
  StartupInfo.dwFlags     := STARTF_USESHOWWINDOW ;
  StartupInfo.wShowWindow := Visibility ;
  if not CreateProcess(nil,
     zAppName,                      { pointer to command line string }
     nil,                           { pointer to process security attributes}
     nil,                           { pointer to thread security attributes }
     false,                         { handle inheritance flag }
     CREATE_NEW_CONSOLE or          { creation flags }
     NORMAL_PRIORITY_CLASS,
     nil,                           { pointer to new environment block }
     nil,                           { pointer to current directory name }
     StartupInfo,                   { pointer to STARTUPINFO }
     ProcessInfo)                   { pointer to PROCESS_INF }
  then Result := DWORD(-1)
  else begin
       WaitforSingleObject(ProcessInfo.hThread,INFINITE) ;
       GetExitCodeProcess(ProcessInfo.hProcess,Result) ;
       CloseHandle( ProcessInfo.hProcess ) ;
       CloseHandle( ProcessInfo.hThread ) ;
  end;
end;


{------------------------------------------------------------------------------}
{ Register TextCapture Library.                                                }
procedure TFrmMain.FormCreate(Sender: TObject);
var
  AppDir, DLLName, s : String ;
begin
  { Note: ExtractFilePATH ends with a '\' }
  {       ExtractFileDIR  ends without.   }
  AppDir := ExtractFileDir(Application.EXEName) ;

  { Install DLL component }
  DLLName   := AppDir + '\TextCaptureLib.dll' ;
  s := 'REGSVR32.EXE /S "' + DLLName + '"' ;
  WaitUntilLoaded(s, SW_SHOWMINIMIZED) ;

  { Create capture components }
  CaptureWindow := TCInputWindow.Create(self) ;
  CaptureText   := TCTextCapture.Create(self) ;

  { Your registration information goes here }
  if   CaptureText.License('Your Name Here', 'Your License Here')
  then Caption := Caption + ' (Registered)'
  else Caption := Caption + ' (Unregistered Demo Version)' ;
end;

{ Release capture components }
procedure TFrmMain.FormDestroy(Sender: TObject);
begin
  CaptureWindow.Free ;
  CaptureText.Free ;
end;

{------------------------------------------------------------------------------}
{ Captures text contained in a window which mouse is pointing to.              }
procedure TFrmMain.B_MouseCaptureClick(Sender: TObject);
var
  x,y : Integer ;
begin
  { Center dialog on form }
  x := (Self.Width  Div 2) + Self.Left - 136 ;
  y := (Self.Height Div 2) + Self.Top  - 50 ;
  if MessageDlgPos('3 seconds after you close this dialog'#13
                 + 'all the text contained in the window'#13
                 + 'pointed to by the mouse will be captured.',
                    mtInformation, mbYesNoCancel,
                    0, x, y) <> mrYes
  then exit ;

  { Wait 3 seconds }
  Sleep(3000) ;

  { Capture text from whatever window }
  { mouse is currently pointing to.   }
  if   CaptureWindow.WindowFromCurrentPos
  then begin
       if   C_WithScan1.Checked
       then M_CapturedText.Text := CaptureText.GetTextWithScan(
                                   CaptureWindow.DefaultInterface, False)
       else M_CapturedText.Text := CaptureText.GetText(
                                   CaptureWindow.DefaultInterface) ;
       E_Handle.Text := IntToStr(CaptureWindow.Handle) ;
  end;
end;

{------------------------------------------------------------------------------}
{ Captures text from a specific window (must supply window handle).            }
procedure TFrmMain.B_HandleCaptureClick(Sender: TObject);
begin
  { Window handle to capture text from }
  E_Handle.Text := Trim(E_Handle.Text) ;
  if   E_Handle.Text = ''
  then begin
       ShowMessage('Enter a valid Window handle.') ;
       E_Handle.SetFocus ;
       exit;
  end;

  { Set handle then capture text }
  CaptureWindow.Handle := StrToIntDef(E_Handle.Text, 0) ;

  if   CaptureWindow.IsValidWindow
  then M_CapturedText.Text := CaptureText.GetText(
                              CaptureWindow.DefaultInterface)
  else ShowMessage('Invalid window handle.') ;
end;

{------------------------------------------------------------------------------}
{ Capture text using current mouse x/y position every second.                  }
procedure TFrmMain.Timer1Timer(Sender: TObject);
var
  p : TPoint;
begin
  { Mouse current position }
  p := Mouse.CursorPos ;
  LB_MousePosition.Caption := 'Current mouse position:   X = ' + IntToStr(p.X)
                                                    + ', Y = ' + IntToStr(p.Y) ;
end;

procedure TFrmMain.B_MouseXYClick(Sender: TObject);
var
  x, y : Integer ;
begin
  { Use x/y coordinates }
  x := StrToInt(E_X.Text) ;
  y := StrToInt(E_Y.Text) ;

  { Capture text from x/y coordinates }
  if   CaptureWindow.WindowFromPos(x, y)
  then begin
       if   C_WithScan2.Checked
       then M_CapturedText.Text := CaptureText.GetTextWithScan(
                                   CaptureWindow.DefaultInterface, False)
       else M_CapturedText.Text := CaptureText.GetText(
                                   CaptureWindow.DefaultInterface) ;
       E_Handle.Text := IntToStr(CaptureWindow.Handle) ;
  end;
end;

{------------------------------------------------------------------------------}
{ Capture text from current active window.                                     }
procedure TFrmMain.B_TitleCaptureClick(Sender: TObject);
var
  Title : WideString ;
begin
  Title := E_Title.Text ;

  { Capture text from whatever window }
  { mouse is currently pointing to.   }
  if   CaptureWindow.FindWindowA(Title)
  then begin
       if   C_WithScan3.Checked
       then M_CapturedText.Text := CaptureText.GetTextWithScan(
                                   CaptureWindow.DefaultInterface, False)
       else M_CapturedText.Text := CaptureText.GetText(
                                   CaptureWindow.DefaultInterface) ;
       E_Handle.Text := IntToStr(CaptureWindow.Handle) ;
  end;
end;

{------------------------------------------------------------------------------}
{ Capture text from the current active window.                                 }
procedure TFrmMain.B_ActiveWindowClick(Sender: TObject);
begin
  FrmActiveWindow.Show ;

  if   CaptureWindow.WindowFromActiveWindow
  then begin
       if   C_WithScan4.Checked
       then M_CapturedText.Text := CaptureText.GetTextWithScan(
                                   CaptureWindow.DefaultInterface, False)
       else M_CapturedText.Text := CaptureText.GetText(
                                   CaptureWindow.DefaultInterface) ;
       E_Handle.Text := IntToStr(CaptureWindow.Handle) ;
  end;
end;

{------------------------------------------------------------------------------}
{ Clears captured text.                                                        }
procedure TFrmMain.B_ClearTextClick(Sender: TObject);
begin
  M_CapturedText.Clear ;
end;

end.
