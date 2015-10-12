object FrmMain: TFrmMain
  Left = 412
  Top = 218
  Width = 643
  Height = 524
  Caption = 'My Text Capture Library'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  DesignSize = (
    635
    490)
  PixelsPerInch = 96
  TextHeight = 13
  object M_CapturedText: TMemo
    Left = 267
    Top = 17
    Width = 359
    Height = 458
    Anchors = [akLeft, akTop, akRight, akBottom]
    ScrollBars = ssBoth
    TabOrder = 6
  end
  object B_ClearText: TButton
    Left = 11
    Top = 451
    Width = 247
    Height = 25
    Caption = 'Clear Text'
    TabOrder = 5
    OnClick = B_ClearTextClick
  end
  object GroupBox1: TGroupBox
    Left = 11
    Top = 86
    Width = 247
    Height = 59
    Caption = ' Capture Text using Window Handle '
    TabOrder = 1
    object Label1: TLabel
      Left = 8
      Top = 26
      Width = 49
      Height = 13
      Caption = 'Handle -->'
    end
    object E_Handle: TEdit
      Left = 59
      Top = 23
      Width = 73
      Height = 21
      TabOrder = 0
    end
    object B_HandleCapture: TButton
      Left = 139
      Top = 21
      Width = 97
      Height = 25
      Caption = 'Handle Capture'
      TabOrder = 1
      OnClick = B_HandleCaptureClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 11
    Top = 13
    Width = 247
    Height = 59
    Caption = ' Capture Text using Mouse Current Position '
    TabOrder = 0
    object C_WithScan1: TCheckBox
      Left = 59
      Top = 25
      Width = 77
      Height = 17
      Caption = 'With Scan :'
      TabOrder = 0
    end
    object B_MouseCapture: TButton
      Left = 139
      Top = 21
      Width = 97
      Height = 25
      Caption = 'Mouse Capture'
      TabOrder = 1
      OnClick = B_MouseCaptureClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 11
    Top = 279
    Width = 247
    Height = 89
    Caption = ' Text Capture using Window Title '
    TabOrder = 3
    object Label2: TLabel
      Left = 11
      Top = 25
      Width = 35
      Height = 13
      Caption = 'Title -->'
    end
    object E_Title: TEdit
      Left = 50
      Top = 22
      Width = 185
      Height = 21
      TabOrder = 0
      Text = 'Untitled - Notepad'
    end
    object B_TitleCapture: TButton
      Left = 97
      Top = 51
      Width = 134
      Height = 25
      Caption = 'Title Capture'
      TabOrder = 2
      OnClick = B_TitleCaptureClick
    end
    object C_WithScan3: TCheckBox
      Left = 16
      Top = 55
      Width = 77
      Height = 17
      Caption = 'With Scan :'
      TabOrder = 1
    end
  end
  object GroupBox4: TGroupBox
    Left = 11
    Top = 382
    Width = 247
    Height = 59
    Caption = ' Capture Text from Active Window '
    TabOrder = 4
    object B_ActiveWindow: TButton
      Left = 97
      Top = 21
      Width = 134
      Height = 25
      Caption = 'Active Window Capture'
      TabOrder = 1
      OnClick = B_ActiveWindowClick
    end
    object C_WithScan4: TCheckBox
      Left = 16
      Top = 25
      Width = 77
      Height = 17
      Caption = 'With Scan :'
      TabOrder = 0
    end
  end
  object GroupBox5: TGroupBox
    Left = 11
    Top = 159
    Width = 247
    Height = 105
    Caption = ' Capture Text from Mouse X-Y Position '
    TabOrder = 2
    object LB_MousePosition: TLabel
      Left = 11
      Top = 19
      Width = 72
      Height = 13
      Caption = 'Mouse Position'
    end
    object Label3: TLabel
      Left = 11
      Top = 41
      Width = 38
      Height = 13
      Caption = 'Enter X:'
    end
    object Label4: TLabel
      Left = 119
      Top = 41
      Width = 38
      Height = 13
      Caption = 'Enter Y:'
    end
    object E_X: TEdit
      Left = 55
      Top = 38
      Width = 51
      Height = 21
      TabOrder = 0
    end
    object E_Y: TEdit
      Left = 163
      Top = 38
      Width = 51
      Height = 21
      TabOrder = 1
    end
    object B_MouseXY: TButton
      Left = 97
      Top = 67
      Width = 134
      Height = 25
      Caption = 'Mouse X-Y Capture'
      TabOrder = 3
      OnClick = B_MouseXYClick
    end
    object C_WithScan2: TCheckBox
      Left = 16
      Top = 71
      Width = 77
      Height = 17
      Caption = 'With Scan :'
      TabOrder = 2
    end
  end
  object Timer1: TTimer
    OnTimer = Timer1Timer
    Left = 287
    Top = 34
  end
end
