object Form1: TForm1
  Left = 192
  Top = 114
  Caption = 'TextCatch COM Server Sample'
  ClientHeight = 341
  ClientWidth = 536
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 300
    Width = 536
    Height = 41
    Align = alBottom
    TabOrder = 0
    object btnCapture: TButton
      Left = 408
      Top = 8
      Width = 75
      Height = 25
      Caption = 'Capture it!'
      TabOrder = 0
      OnClick = btnCaptureClick
    end
    object btnAbout: TButton
      Left = 16
      Top = 6
      Width = 153
      Height = 25
      Caption = 'About Text Capture Library'
      TabOrder = 1
      OnClick = btnAboutClick
    end
  end
  object Memo1: TMemo
    Left = 0
    Top = 0
    Width = 536
    Height = 300
    Align = alClient
    TabOrder = 1
  end
end
