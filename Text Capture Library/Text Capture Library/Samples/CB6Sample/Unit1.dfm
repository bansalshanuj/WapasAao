object Form1: TForm1
  Left = 192
  Top = 114
  Width = 544
  Height = 375
  Caption = 'TextCatch COM Server Sample'
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
    Top = 307
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
      Left = 40
      Top = 8
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
    Height = 307
    Align = alClient
    TabOrder = 1
  end
end
