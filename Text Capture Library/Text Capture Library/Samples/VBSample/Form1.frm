VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3750
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7140
   LinkTopic       =   "Form1"
   ScaleHeight     =   3750
   ScaleWidth      =   7140
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton GetTextBtn 
      Caption         =   "Capture it!"
      Height          =   375
      Left            =   4560
      TabIndex        =   2
      Top             =   3120
      Width           =   1335
   End
   Begin VB.TextBox HwndText 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   2052
         SubFormatType   =   1
      EndProperty
      Height          =   375
      Left            =   1800
      TabIndex        =   1
      Top             =   3120
      Width           =   2295
   End
   Begin VB.TextBox OutputText 
      Height          =   2655
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   120
      Width           =   6975
   End
   Begin VB.Label Label1 
      Caption         =   "Handle of window"
      Height          =   375
      Left            =   240
      TabIndex        =   3
      Top             =   3120
      Width           =   1695
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

' Declare Text Capture library COM server object
Dim TcServer As Object
Dim TcWindow As Object


Private Sub Form_Load()
        ' Create Text Capture library COM server object
    Set TcServer = CreateObject("TextCaptureLib.TextCapture")
    Set TcWindow = CreateObject("TextCaptureLib.Window")
    
    'Your registration information goes here 
    '
    'If TcServer.License("Your Name Here", "Your License Here") Then
    '        'The registered version of Text Capture Library
    'Else
    '        'The trial version of Text Capture Library
    'End If

End Sub

Private Sub Form_Unload(Cancel As Integer)
    Set TcServer = Nothing
    Set TcWindow = Nothing
End Sub

Private Sub GetTextBtn_Click()
    Dim str As String
    str = ""
    TcWindow.Handle = Val(HwndText.Text)
    str = TcServer.GetText(TcWindow)
    OutputText.Text = str
End Sub
