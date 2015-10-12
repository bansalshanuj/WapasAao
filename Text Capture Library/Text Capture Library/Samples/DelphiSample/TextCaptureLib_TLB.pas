unit TextCaptureLib_TLB;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// PASTLWTR : 1.2
// File generated on 7/24/2008 6:07:43 PM from Type Library described below.

// ************************************************************************  //
// Type Lib: D:\D7\_TextCaptureLib.tlb (1)
// LIBID: {E1A617E2-976F-4B6E-8E74-2CDEDD14C7E9}
// LCID: 0
// Helpfile: 
// HelpString: TextCaptureLib 1.0 Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\WINDOWS\system32\stdole2.tlb)
// ************************************************************************ //
// *************************************************************************//
// NOTE:                                                                      
// Items guarded by $IFDEF_LIVE_SERVER_AT_DESIGN_TIME are used by properties  
// which return objects that may need to be explicitly created via a function 
// call prior to any access via the property. These items have been disabled  
// in order to prevent accidental use from within the object inspector. You   
// may enable them by defining LIVE_SERVER_AT_DESIGN_TIME or by selectively   
// removing them from the $IFDEF blocks. However, such items must still be    
// programmatically created via a method of the appropriate CoClass before    
// they can be used.                                                          
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}
{$VARPROPSETTER ON}
interface

uses Windows, ActiveX, Classes, Graphics, OleServer, StdVCL, Variants;
  

// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLASS_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  TextCaptureLibMajorVersion = 1;
  TextCaptureLibMinorVersion = 0;

  LIBID_TextCaptureLib: TGUID = '{E1A617E2-976F-4B6E-8E74-2CDEDD14C7E9}';

  IID_IWindow: TGUID = '{46AE537A-9886-4765-98DE-38947AA7B1D9}';
  CLASS_CInputWindow: TGUID = '{F24E46BA-66FA-4954-80BA-D6601C63D9AD}';
  IID_ITextCapture: TGUID = '{90A5CBF6-CCE2-4518-A829-220430A42690}';
  CLASS_CTextCapture: TGUID = '{9633F541-5346-460C-8B2D-43A6765AA207}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library                    
// *********************************************************************//
// Constants for enum WindowTypeEnum
type
  WindowTypeEnum = TOleEnum;
const
  WINDOWTYPE_UNKNOW = $FFFFFFFF;
  WINDOWTYPE_AUTO = $00000000;
  WINDOWTYPE_SCAN = $00000001;
  WINDOWTYPE_STATIC = $00000002;
  WINDOWTYPE_EDIT = $00000003;
  WINDOWTYPE_RICHEDIT = $00000004;
  WINDOWTYPE_LISTBOX = $00000005;
  WINDOWTYPE_COMBOBOX = $00000006;
  WINDOWTYPE_LISTVIEW = $00000007;
  WINDOWTYPE_TREEVIEW = $00000008;
  WINDOWTYPE_BUTTON = $00000009;
  WINDOWTYPE_TOOLBAR = $0000000A;
  WINDOWTYPE_STATUSBAR = $0000000B;
  WINDOWTYPE_IEXPLORE = $0000000C;
  WINDOWTYPE_DOSCONSOLE = $0000000D;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  IWindow = interface;
  IWindowDisp = dispinterface;
  ITextCapture = interface;
  ITextCaptureDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  CInputWindow = IWindow;
  CTextCapture = ITextCapture;


// *********************************************************************//
// Interface: IWindow
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {46AE537A-9886-4765-98DE-38947AA7B1D9}
// *********************************************************************//
  IWindow = interface(IDispatch)
    ['{46AE537A-9886-4765-98DE-38947AA7B1D9}']
    function Get_Handle: Integer; safecall;
    procedure Set_Handle(pVal: Integer); safecall;
    function Get_WindowType: WindowTypeEnum; safecall;
    procedure Set_WindowType(pVal: WindowTypeEnum); safecall;
    function FindWindowA(const Title: WideString): WordBool; safecall;
    function IsValidWindow: WordBool; safecall;
    function WindowFromPos(x: Integer; y: Integer): WordBool; safecall;
    function WindowFromCurrentPos: WordBool; safecall;
    function WindowFromActiveWindow: WordBool; safecall;
    property Handle: Integer read Get_Handle write Set_Handle;
    property WindowType: WindowTypeEnum read Get_WindowType write Set_WindowType;
  end;

// *********************************************************************//
// DispIntf:  IWindowDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {46AE537A-9886-4765-98DE-38947AA7B1D9}
// *********************************************************************//
  IWindowDisp = dispinterface
    ['{46AE537A-9886-4765-98DE-38947AA7B1D9}']
    property Handle: Integer dispid 1;
    property WindowType: WindowTypeEnum dispid 2;
    function FindWindowA(const Title: WideString): WordBool; dispid 3;
    function IsValidWindow: WordBool; dispid 4;
    function WindowFromPos(x: Integer; y: Integer): WordBool; dispid 5;
    function WindowFromCurrentPos: WordBool; dispid 6;
    function WindowFromActiveWindow: WordBool; dispid 7;
  end;

// *********************************************************************//
// Interface: ITextCapture
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {90A5CBF6-CCE2-4518-A829-220430A42690}
// *********************************************************************//
  ITextCapture = interface(IDispatch)
    ['{90A5CBF6-CCE2-4518-A829-220430A42690}']
    function GetText(const Window: IWindow): WideString; safecall;
    function GetTextWithScan(const Window: IWindow; Coordinate: WordBool): WideString; safecall;
    function GetHTMLText(const Window: IWindow; Source: WordBool): WideString; safecall;
    function License(const UserName: WideString; const LicenseCode: WideString): WordBool; safecall;
    procedure AboutBox; safecall;
    function Reserved1: Integer; safecall;
  end;

// *********************************************************************//
// DispIntf:  ITextCaptureDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {90A5CBF6-CCE2-4518-A829-220430A42690}
// *********************************************************************//
  ITextCaptureDisp = dispinterface
    ['{90A5CBF6-CCE2-4518-A829-220430A42690}']
    function GetText(const Window: IWindow): WideString; dispid 1;
    function GetTextWithScan(const Window: IWindow; Coordinate: WordBool): WideString; dispid 2;
    function GetHTMLText(const Window: IWindow; Source: WordBool): WideString; dispid 3;
    function License(const UserName: WideString; const LicenseCode: WideString): WordBool; dispid 4;
    procedure AboutBox; dispid 5;
    function Reserved1: Integer; dispid 6;
  end;

// *********************************************************************//
// The Class CoCInputWindow provides a Create and CreateRemote method to          
// create instances of the default interface IWindow exposed by              
// the CoClass CInputWindow. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoCInputWindow = class
    class function Create: IWindow;
    class function CreateRemote(const MachineName: string): IWindow;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TCInputWindow
// Help String      : Window Class
// Default Interface: IWindow
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TCInputWindowProperties= class;
{$ENDIF}
  TCInputWindow = class(TOleServer)
  private
    FIntf:        IWindow;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TCInputWindowProperties;
    function      GetServerProperties: TCInputWindowProperties;
{$ENDIF}
    function      GetDefaultInterface: IWindow;
  protected
    procedure InitServerData; override;
    function Get_Handle: Integer;
    procedure Set_Handle(pVal: Integer);
    function Get_WindowType: WindowTypeEnum;
    procedure Set_WindowType(pVal: WindowTypeEnum);
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IWindow);
    procedure Disconnect; override;
    function FindWindowA(const Title: WideString): WordBool;
    function IsValidWindow: WordBool;
    function WindowFromPos(x: Integer; y: Integer): WordBool;
    function WindowFromCurrentPos: WordBool;
    function WindowFromActiveWindow: WordBool;
    property DefaultInterface: IWindow read GetDefaultInterface;
    property Handle: Integer read Get_Handle write Set_Handle;
    property WindowType: WindowTypeEnum read Get_WindowType write Set_WindowType;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TCInputWindowProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TCInputWindow
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TCInputWindowProperties = class(TPersistent)
  private
    FServer:    TCInputWindow;
    function    GetDefaultInterface: IWindow;
    constructor Create(AServer: TCInputWindow);
  protected
    function Get_Handle: Integer;
    procedure Set_Handle(pVal: Integer);
    function Get_WindowType: WindowTypeEnum;
    procedure Set_WindowType(pVal: WindowTypeEnum);
  public
    property DefaultInterface: IWindow read GetDefaultInterface;
  published
    property Handle: Integer read Get_Handle write Set_Handle;
    property WindowType: WindowTypeEnum read Get_WindowType write Set_WindowType;
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoCTextCapture provides a Create and CreateRemote method to          
// create instances of the default interface ITextCapture exposed by              
// the CoClass CTextCapture. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoCTextCapture = class
    class function Create: ITextCapture;
    class function CreateRemote(const MachineName: string): ITextCapture;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TCTextCapture
// Help String      : TextCapture Class
// Default Interface: ITextCapture
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TCTextCaptureProperties= class;
{$ENDIF}
  TCTextCapture = class(TOleServer)
  private
    FIntf:        ITextCapture;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TCTextCaptureProperties;
    function      GetServerProperties: TCTextCaptureProperties;
{$ENDIF}
    function      GetDefaultInterface: ITextCapture;
  protected
    procedure InitServerData; override;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: ITextCapture);
    procedure Disconnect; override;
    function GetText(const Window: IWindow): WideString;
    function GetTextWithScan(const Window: IWindow; Coordinate: WordBool): WideString;
    function GetHTMLText(const Window: IWindow; Source: WordBool): WideString;
    function License(const UserName: WideString; const LicenseCode: WideString): WordBool;
    procedure AboutBox;
    function Reserved1: Integer;
    property DefaultInterface: ITextCapture read GetDefaultInterface;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TCTextCaptureProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TCTextCapture
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TCTextCaptureProperties = class(TPersistent)
  private
    FServer:    TCTextCapture;
    function    GetDefaultInterface: ITextCapture;
    constructor Create(AServer: TCTextCapture);
  protected
  public
    property DefaultInterface: ITextCapture read GetDefaultInterface;
  published
  end;
{$ENDIF}


procedure Register;

resourcestring
  dtlServerPage = 'ActiveX';

  dtlOcxPage = 'ActiveX';

implementation

uses ComObj;

class function CoCInputWindow.Create: IWindow;
begin
  Result := CreateComObject(CLASS_CInputWindow) as IWindow;
end;

class function CoCInputWindow.CreateRemote(const MachineName: string): IWindow;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_CInputWindow) as IWindow;
end;

procedure TCInputWindow.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{F24E46BA-66FA-4954-80BA-D6601C63D9AD}';
    IntfIID:   '{46AE537A-9886-4765-98DE-38947AA7B1D9}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TCInputWindow.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IWindow;
  end;
end;

procedure TCInputWindow.ConnectTo(svrIntf: IWindow);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TCInputWindow.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TCInputWindow.GetDefaultInterface: IWindow;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TCInputWindow.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TCInputWindowProperties.Create(Self);
{$ENDIF}
end;

destructor TCInputWindow.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TCInputWindow.GetServerProperties: TCInputWindowProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TCInputWindow.Get_Handle: Integer;
begin
    Result := DefaultInterface.Handle;
end;

procedure TCInputWindow.Set_Handle(pVal: Integer);
begin
  DefaultInterface.Set_Handle(pVal);
end;

function TCInputWindow.Get_WindowType: WindowTypeEnum;
begin
    Result := DefaultInterface.WindowType;
end;

procedure TCInputWindow.Set_WindowType(pVal: WindowTypeEnum);
begin
  DefaultInterface.Set_WindowType(pVal);
end;

function TCInputWindow.FindWindowA(const Title: WideString): WordBool;
begin
  Result := DefaultInterface.FindWindowA(Title);
end;

function TCInputWindow.IsValidWindow: WordBool;
begin
  Result := DefaultInterface.IsValidWindow;
end;

function TCInputWindow.WindowFromPos(x: Integer; y: Integer): WordBool;
begin
  Result := DefaultInterface.WindowFromPos(x, y);
end;

function TCInputWindow.WindowFromCurrentPos: WordBool;
begin
  Result := DefaultInterface.WindowFromCurrentPos;
end;

function TCInputWindow.WindowFromActiveWindow: WordBool;
begin
  Result := DefaultInterface.WindowFromActiveWindow;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TCInputWindowProperties.Create(AServer: TCInputWindow);
begin
  inherited Create;
  FServer := AServer;
end;

function TCInputWindowProperties.GetDefaultInterface: IWindow;
begin
  Result := FServer.DefaultInterface;
end;

function TCInputWindowProperties.Get_Handle: Integer;
begin
    Result := DefaultInterface.Handle;
end;

procedure TCInputWindowProperties.Set_Handle(pVal: Integer);
begin
  DefaultInterface.Set_Handle(pVal);
end;

function TCInputWindowProperties.Get_WindowType: WindowTypeEnum;
begin
    Result := DefaultInterface.WindowType;
end;

procedure TCInputWindowProperties.Set_WindowType(pVal: WindowTypeEnum);
begin
  DefaultInterface.Set_WindowType(pVal);
end;

{$ENDIF}

class function CoCTextCapture.Create: ITextCapture;
begin
  Result := CreateComObject(CLASS_CTextCapture) as ITextCapture;
end;

class function CoCTextCapture.CreateRemote(const MachineName: string): ITextCapture;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_CTextCapture) as ITextCapture;
end;

procedure TCTextCapture.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{9633F541-5346-460C-8B2D-43A6765AA207}';
    IntfIID:   '{90A5CBF6-CCE2-4518-A829-220430A42690}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TCTextCapture.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as ITextCapture;
  end;
end;

procedure TCTextCapture.ConnectTo(svrIntf: ITextCapture);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TCTextCapture.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TCTextCapture.GetDefaultInterface: ITextCapture;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TCTextCapture.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TCTextCaptureProperties.Create(Self);
{$ENDIF}
end;

destructor TCTextCapture.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TCTextCapture.GetServerProperties: TCTextCaptureProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TCTextCapture.GetText(const Window: IWindow): WideString;
begin
  Result := DefaultInterface.GetText(Window);
end;

function TCTextCapture.GetTextWithScan(const Window: IWindow; Coordinate: WordBool): WideString;
begin
  Result := DefaultInterface.GetTextWithScan(Window, Coordinate);
end;

function TCTextCapture.GetHTMLText(const Window: IWindow; Source: WordBool): WideString;
begin
  Result := DefaultInterface.GetHTMLText(Window, Source);
end;

function TCTextCapture.License(const UserName: WideString; const LicenseCode: WideString): WordBool;
begin
  Result := DefaultInterface.License(UserName, LicenseCode);
end;

procedure TCTextCapture.AboutBox;
begin
  DefaultInterface.AboutBox;
end;

function TCTextCapture.Reserved1: Integer;
begin
  Result := DefaultInterface.Reserved1;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TCTextCaptureProperties.Create(AServer: TCTextCapture);
begin
  inherited Create;
  FServer := AServer;
end;

function TCTextCaptureProperties.GetDefaultInterface: ITextCapture;
begin
  Result := FServer.DefaultInterface;
end;

{$ENDIF}

procedure Register;
begin
  RegisterComponents(dtlServerPage, [TCInputWindow, TCTextCapture]);
end;

end.
