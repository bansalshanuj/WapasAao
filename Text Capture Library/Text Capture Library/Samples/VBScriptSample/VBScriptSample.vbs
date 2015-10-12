' Create TextCapture library COM server object
Set TcServer = CreateObject("TextCaptureLib.TextCapture")
Set TcWindow = CreateObject("TextCaptureLib.Window")

'Your registration information goes here 

'If TcServer.License("Your Name Here", "Your License Here") Then
'    'The registered version of Text Capture Library
'Else
'    'The trial version of Text Capture Library
'End If

wsh.echo "Three seconds after you close this dialog, the mouse pointed window will be captured."

set WshShell = WScript.CreateObject("WScript.Shell")
WScript.Sleep 3000

TcWindow.WindowFromCurrentPos
wsh.echo TcServer.GetText(TcWindow)
 
Set WshShell = Nothing

Set TcWindow = Nothing
Set TcServer = Nothing


