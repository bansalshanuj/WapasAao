// DemoIExploreWindowDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TcServerSample.h"
#include "DemoIExploreWindowDlg.h"
#include ".\demoiexplorewindowdlg.h"


// CDemoIExploreWindowDlg dialog

IMPLEMENT_DYNAMIC(CDemoIExploreWindowDlg, CDialog)
CDemoIExploreWindowDlg::CDemoIExploreWindowDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDemoIExploreWindowDlg::IDD, pParent)
{
}

CDemoIExploreWindowDlg::~CDemoIExploreWindowDlg()
{
}

void CDemoIExploreWindowDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EXPLORER1, m_ieControl);
}


BEGIN_MESSAGE_MAP(CDemoIExploreWindowDlg, CDialog)
END_MESSAGE_MAP()


// CDemoIExploreWindowDlg message handlers

BOOL CDemoIExploreWindowDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// TODO:  
	m_ieControl.Navigate("http://www.yahoo.com", NULL, NULL, NULL, NULL);

	return TRUE;  // return TRUE unless you set the focus to a control
}

BOOL CDemoIExploreWindowDlg::CreateModaless(CWnd * pParentWnd /*= NULL*/)
{
	return CreateDlg(MAKEINTRESOURCE(IDD_IEXPLORE_DIALOG), pParentWnd);
}
