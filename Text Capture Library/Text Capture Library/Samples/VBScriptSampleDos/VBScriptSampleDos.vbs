' Create TextCapture library COM server object
Set TcServer = CreateObject("TextCaptureLib.TextCapture")
Set TcWindow = CreateObject("TextCaptureLib.Window")

'Your registration information goes here 

'If TcServer.License("Your Name Here", "Your License Here") Then
'    'The registered version of Text Capture Library
'Else
'    'The trial version of Text Capture Library
'End If

Sub SaveToFile(FileName, Message)
	Dim fso, MyFile
	Set fso = CreateObject("Scripting.FileSystemObject")
	Set MyFile = fso.CreateTextFile(FileName, True)
	MyFile.Write(Message)
	MyFile.Close
End Sub 

set WshShell = WScript.CreateObject("WScript.Shell")
WScript.Sleep 3000

TcWindow.FindWindowA("C:\WINDOWS\system32\cmd.exe")

If TcWindow.IsValidWindow Then 

	WScript.echo "Now cmd dos output will be saved to c:\tc_xx.txt every 1 minute, until cmd dos window closed "

	nCount = 0

	Do Until Not TcWindow.IsValidWindow 

		nCount = nCount + 1

		'WScript.echo TcServer.GetText(TcWindow)

		SaveToFile "C:\Tc_" & nCount & ".txt", TcServer.GetText(TcWindow) 
	
		' Wait for 60"
		WScript.Sleep 60000
	Loop
Else
	WScript.echo "Please run cmd first!"
End If

Set WshShell = Nothing

Set TcWindow = Nothing
Set TcServer = Nothing


