object FrmActiveWindow: TFrmActiveWindow
  Left = 192
  Top = 114
  Width = 309
  Height = 217
  Caption = 'Demo Active Window'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Shell Dlg 2'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Memo1: TMemo
    Left = 10
    Top = 11
    Width = 281
    Height = 161
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Lines.Strings = (
      'This is some sample text that will '
      'be captured by the:'
      ''
      'Text Capture Library '
      ''
      'using the WindowFromActiveWindow'
      'method.')
    ParentFont = False
    TabOrder = 0
  end
end
