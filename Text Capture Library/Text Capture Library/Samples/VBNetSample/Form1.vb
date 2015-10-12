Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Designer created code "

    Public Sub New()
        MyBase.New()

        InitializeComponent()

    End Sub

    'Window dispose to clear componets list
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows Design needed
    Private components As System.ComponentModel.IContainer

    Friend WithEvents OutputText As System.Windows.Forms.TextBox
    Friend WithEvents GetTextBtn As System.Windows.Forms.Button
    Friend WithEvents AboutBtn As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OutputText = New System.Windows.Forms.TextBox
        Me.GetTextBtn = New System.Windows.Forms.Button
        Me.AboutBtn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OutputText
        '
        Me.OutputText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputText.Location = New System.Drawing.Point(16, 16)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.Size = New System.Drawing.Size(468, 176)
        Me.OutputText.TabIndex = 0
        '
        'GetTextBtn
        '
        Me.GetTextBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GetTextBtn.Location = New System.Drawing.Point(16, 208)
        Me.GetTextBtn.Name = "GetTextBtn"
        Me.GetTextBtn.Size = New System.Drawing.Size(128, 23)
        Me.GetTextBtn.TabIndex = 2
        Me.GetTextBtn.Text = "Capture it!"
        '
        'AboutBtn
        '
        Me.AboutBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AboutBtn.Location = New System.Drawing.Point(272, 208)
        Me.AboutBtn.Name = "AboutBtn"
        Me.AboutBtn.Size = New System.Drawing.Size(208, 23)
        Me.AboutBtn.TabIndex = 3
        Me.AboutBtn.Text = "About Text Capture Library"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 14)
        Me.ClientSize = New System.Drawing.Size(496, 246)
        Me.Controls.Add(Me.AboutBtn)
        Me.Controls.Add(Me.GetTextBtn)
        Me.Controls.Add(Me.OutputText)
        Me.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "VB.Net Sample for Text Capture Library COM Server"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Declare TextCapture library COM server object
    Dim TcServer As TextCaptureLib.ITextCapture
    Dim TcWindow As TextCaptureLib.IWindow

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create TextCapture library COM server object
        TcServer = CreateObject("TextCaptureLib.TextCapture")
        TcWindow = CreateObject("TextCaptureLib.Window")
        
	    'Please set your license info
	    'If TcServer.License("skesoft", "123456789") Then
	    '        'The registered version of Text Capture Library
	    'Else
	    '        'The trial version of Text Capture Library
	    'End If
        
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        TcServer = Nothing
        TcWindow = Nothing
    End Sub

    Private Sub GetTextBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetTextBtn.Click
        Dim strResult As String
        strResult = ""

        MsgBox("Three seconds after you close this dialog, the mouse pointed window will be captured.", MsgBoxStyle.OKOnly, "Information")

        Visible = False

        Sleep(2000)
        TcWindow.WindowFromCurrentPos()
        'Debug.WriteLine(TcWindow.Handle)

        If TcWindow.IsValidWindow Then
            strResult = TcServer.GetText(TcWindow)
            OutputText.Text = strResult
        End If

        Visible = True

    End Sub

    Private Sub AboutBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutBtn.Click
        TcServer.AboutBox()
    End Sub
End Class
