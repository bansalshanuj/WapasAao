unit ActiveWindow;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TFrmActiveWindow = class(TForm)
    Memo1: TMemo;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FrmActiveWindow: TFrmActiveWindow;

implementation

{$R *.dfm}

end.
