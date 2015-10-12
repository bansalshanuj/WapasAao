//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>

#include "TextCaptureLib_TLB.h"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
    TPanel *Panel1;
    TButton *btnCapture;
    TMemo *Memo1;
	TButton *btnAbout;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall btnCaptureClick(TObject *Sender);
	void __fastcall btnAboutClick(TObject *Sender);
private:	// User declarations

	// Declare the TextCaptureLib COM library object
	Textcapturelib_tlb::ITextCapturePtr 	m_pTextCapture;
	Textcapturelib_tlb::IWindowPtr			m_pWindowCapture;

public:		// User declarations
    __fastcall TForm1(TComponent* Owner);


};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
 