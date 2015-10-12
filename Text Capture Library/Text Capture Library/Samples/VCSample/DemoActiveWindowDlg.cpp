// DemoActiveWindowDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TcServerSample.h"
#include "DemoActiveWindowDlg.h"
#include ".\demoactivewindowdlg.h"


// CDemoActiveWindowDlg dialog

IMPLEMENT_DYNAMIC(CDemoActiveWindowDlg, CDialog)
CDemoActiveWindowDlg::CDemoActiveWindowDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDemoActiveWindowDlg::IDD, pParent)
{
}

CDemoActiveWindowDlg::~CDemoActiveWindowDlg()
{
}

void CDemoActiveWindowDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDemoActiveWindowDlg, CDialog)
END_MESSAGE_MAP()


// CDemoActiveWindowDlg message handlers

BOOL CDemoActiveWindowDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// TODO:  
	GetDlgItem(IDC_EDIT1)->SetWindowText("This is some sample text that will\r\n" 
				"be captured by the:\r\n"
				"Text Capture Library\r\n" 
				"using the WindowFromActiveWindow\r\n"
				"method.\r\n");

	GetDlgItem(IDC_EDIT1)->SendMessage(EM_SETSEL, -1, -1);

	return TRUE;  // return TRUE unless you set the focus to a control
}

BOOL CDemoActiveWindowDlg::CreateModaless(CWnd * pParentWnd /*= NULL*/)
{
	return CreateDlg(MAKEINTRESOURCE(IDD_ACTIVE_DIALOG), pParentWnd);
}
