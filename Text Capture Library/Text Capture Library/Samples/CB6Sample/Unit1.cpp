//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
	// Create the TextCaptureLib COM library object.
	try
	{
		m_pTextCapture = CreateComObject(CLSID_CTextCapture);
		m_pWindowCapture = CreateComObject(CLSID_CInputWindow);

        // Your registration information goes here 

		/*
	    VARIANT_BOOL _result = m_pTextCapture->License((BSTR)WideString("Your Name Here"), (BSTR)WideString("Your License Here"));
	    if (_result == VARIANT_TRUE)
	    {
	    	// The registered version of Text Capture Library
	    }
	    else
	    {
	    	// The trial version of Text Capture Library
	    }
		*/

	}
	catch(...)
	{
		// Handle creation error.
		Memo1->Text = "Fatal error: failed to create Text capture COM library object.";
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::btnCaptureClick(TObject *Sender)
{
	if (IDOK ==MessageBox(0, "Three seconds after you close this dialog, "\
		"the mouse pointed window will be captured.", "Information", MB_OKCANCEL))
	{
		Visible = false;

		Sleep(3000);

		POINT p;
		GetCursorPos(&p);
		HWND hWnd = ::WindowFromPoint(p);
		m_pWindowCapture->set_Handle(long(hWnd));

		if (hWnd && m_pWindowCapture->IsValidWindow() == VARIANT_TRUE)
		{
			try
			{
				BSTR bstrResult = m_pTextCapture->GetText(m_pWindowCapture);
				Memo1->Text = bstrResult;

				::SysFreeString(bstrResult);
				bstrResult = NULL;
			}
			catch ( ... )
			{
				MessageBox(0,  "Unable to capture.", "Error", MB_ICONINFORMATION );
			}
		}
		else
		{
			MessageBox(0,  "Fatal error: failed to capture an invalid window control.", "Error", MB_ICONINFORMATION );
		}

		Visible = true;

	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnAboutClick(TObject *Sender)
{
	m_pTextCapture->AboutBox();
}
//---------------------------------------------------------------------------

