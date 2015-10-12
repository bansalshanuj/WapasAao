;
; AutoIt Version: 3.0
; Language:       English
; Platform:       Win9x/NT
; Author:         skesoft.com
;

#include <GuiConstantsEx.au3>
#include <WindowsConstants.au3>

_Main()

Func _Main()
	$tcServer = ObjCreate('TextCaptureLib.TextCapture')
	$tcWindow = ObjCreate('TextCaptureLib.Window')

	;Your registration information goes here

	;If $TcServer.License ("Your Name Here", "Your License Here") Then
		;The registered version of Text Capture Library
		;MsgBox(0, "OK", "License is OK")
	;Else
		;The trial version of Text Capture Library
		;MsgBox(0, "ERROR", "License is ERROR")
	;EndIf

	GUICreate("Text Capture Library Auto-it example", 469, 200, (@DesktopWidth - 469) / 2, (@DesktopHeight - 200) / 2, $WS_OVERLAPPEDWINDOW + $WS_VISIBLE + $WS_CLIPSIBLINGS)

	GUICtrlCreateLabel("Window handle ", 10, 10, 150, 20)
	
	$Handle_Edit = GUICtrlCreateInput("", 170, 10, 280, 20)
	
	;Create an "OK" button
	$OK_Btn = GUICtrlCreateButton("Capture", 20, 80, 70, 25)
	
	;Create an "Exit" button
	$Exit_Btn = GUICtrlCreateButton("Exit", 290, 80, 70, 25)

	GUISetState()
	While 1
		$msg = GUIGetMsg()
		Select
			Case $msg = $OK_Btn
				$tcWindow.Handle = Int(GUICtrlRead ($Handle_Edit))
				If $tcWindow.IsValidWindow Then
					$strResult = $tcServer.GetText($tcWindow)
					MsgBox(0, "GetIt!", $strResult)
				Else
				EndIf
					
			Case $msg = $GUI_EVENT_CLOSE	
				ExitLoop

			case $msg = $Exit_Btn
				ExitLoop

			Case Else
				;;;
		EndSelect
	WEnd
	Exit
EndFunc   ;==>_Main
