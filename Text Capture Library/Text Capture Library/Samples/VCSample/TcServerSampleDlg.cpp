// TcServerSampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TcServerSample.h"
#include "TcServerSampleDlg.h"
#include ".\tcserversampledlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTcServerSampleDlg dialog

CTcServerSampleDlg::CTcServerSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CTcServerSampleDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CTcServerSampleDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	m_pDemoActiveWindowDlg = NULL;
	m_pDemoIExploreWindowDlg = NULL;
}

void CTcServerSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CTcServerSampleDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CTcServerSampleDlg, CDialog)
	//{{AFX_MSG_MAP(CTcServerSampleDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_CLOSE()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_ABOUT, OnBnClickedAbout)
	ON_BN_CLICKED(IDC_MOUSE_CAPTURE, OnMouseCapture)
	ON_BN_CLICKED(IDC_HANDLE_CAPTURE, OnHandleCapture)
	ON_BN_CLICKED(IDC_IEXPLORE_CAPTURE, OnIExploreCapture)
	ON_BN_CLICKED(IDC_MOUSE_XY_CAPTURE, OnMouseXYCapture)
	ON_BN_CLICKED(IDC_TITLE_CAPTURE, OnTitleCapture)
	ON_BN_CLICKED(IDC_ACTIVE_WINDOW_CAPTURE, OnActiveWindowCapture)
	ON_BN_CLICKED(IDC_RECT_CAPTURE, OnRectCapture)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_CLEAR, OnBnClickedClear)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTcServerSampleDlg message handlers

BOOL CTcServerSampleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	GetDlgItem(IDC_TITLE)->SetWindowText("Untitled - Notepad");
	SetTimer(1, 200, NULL);
	
	//
	m_pDemoActiveWindowDlg = new CDemoActiveWindowDlg;
	m_pDemoActiveWindowDlg->CreateModaless();
	m_pDemoIExploreWindowDlg = new CDemoIExploreWindowDlg;
	m_pDemoIExploreWindowDlg->CreateModaless();

	//
	GetDlgItem(IDC_POS_LEFT)->SetWindowText("0");
	GetDlgItem(IDC_POS_TOP)->SetWindowText("0");
	GetDlgItem(IDC_POS_RIGHT)->SetWindowText("0");
	GetDlgItem(IDC_POS_BOTTOM)->SetWindowText("0");

	// NOTE: Make sure to initialize COM before trying to create the Text capture COM library object.
	::CoInitialize( NULL );

	// Create the TextCaptureLib COM library object.
	m_pTextCapture.CreateInstance( __uuidof( TextCaptureLib::CTextCapture));
	if (m_pTextCapture == NULL )
	{
		// Handle creation error.
		AfxMessageBox( _T("Fatal error: failed to create Text capture COM library object."), MB_ICONERROR );
		EndDialog( IDCANCEL );
	}

	m_pWindowCapture.CreateInstance( __uuidof( TextCaptureLib::CInputWindow));
	if (m_pWindowCapture == NULL )
	{
		// Handle creation error.
		AfxMessageBox( _T("Fatal error: failed to create TextCaptureLib::CInputWindow COM object."), MB_ICONERROR );
		EndDialog( IDCANCEL );
	}

	// Your registration information goes here 
	//
	//VARIANT_BOOL _result = m_pTextCapture->License(_T("Your Name Here"), _T("Your License Here"));
	//if (_result == VARIANT_TRUE)
	//{
	//	// The registered version of Text Capture Library
	//}
	//else
	//{
	//	// The trial version of Text Capture Library
	//}

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CTcServerSampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CTcServerSampleDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CTcServerSampleDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CTcServerSampleDlg::OnMouseCapture() 
{
	if (IDOK ==AfxMessageBox(_T("Three seconds after you close this dialog, the mouse pointed window will be captured."), MB_OKCANCEL))
	{
		ShowWindow(SW_HIDE);

		Sleep(3000);

		// Capture text from mouse pointed window
		if (m_pWindowCapture->WindowFromCurrentPos() == VARIANT_TRUE)
		{
			CString strResult;

			try
			{
				_bstr_t bstr = m_pTextCapture->GetText(m_pWindowCapture);
				strResult = (LPTSTR)bstr;


				GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);

				// 
				CString str;
				str.Format("%d", m_pWindowCapture->Handle);
				GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);
			}
			catch ( _com_error captureError )
			{
				AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
			}
		}

		// Show window handle value
		CString str;
		str.Format(_T("%d"), m_pWindowCapture->Handle);
		GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);

		ShowWindow(SW_SHOW);
	}
}

void CTcServerSampleDlg::OnHandleCapture()
{
	CString str;
	GetDlgItem(IDC_WINDOW_HANDLE)->GetWindowText(str);
	HWND hWnd = (HWND)atoi(str.GetBuffer());
	if (hWnd)
	{
		m_pWindowCapture->Handle = (long)hWnd;
		if (m_pWindowCapture->IsValidWindow() == VARIANT_TRUE)
		{
			CString strResult;

			try
			{
				_bstr_t bstr = m_pTextCapture->GetText(m_pWindowCapture);
				strResult = (LPTSTR)bstr;

				GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);
			}
			catch ( _com_error captureError )
			{
				AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
			}
		}
		else
		{
			AfxMessageBox( _T("Fatal error: failed to capture an invalid window control."), MB_ICONERROR );
		}
	}
	else
	{
		AfxMessageBox( _T("Fatal error: Invalid window handle."), MB_ICONERROR );
	}
}


void CTcServerSampleDlg::OnMouseXYCapture()
{
	CString str;
	int x, y;

	GetDlgItem(IDC_POS_X)->GetWindowText(str);
	x = atoi(str.GetBuffer());

	GetDlgItem(IDC_POS_Y)->GetWindowText(str);
	y = atoi(str.GetBuffer());

	str.Format("%d", x);
	GetDlgItem(IDC_POS_X)->SetWindowText(str);
	str.Format("%d", y);
	GetDlgItem(IDC_POS_Y)->SetWindowText(str);

	if (m_pWindowCapture->WindowFromPos(x, y))
	{
		if (m_pWindowCapture->IsValidWindow() == VARIANT_TRUE)
		{
			CString strResult;

			try
			{
				_bstr_t bstr = m_pTextCapture->GetText(m_pWindowCapture);
				strResult = (LPTSTR)bstr;

				GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);

				// 
				CString str;
				str.Format("%d", m_pWindowCapture->Handle);
				GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);
			}
			catch ( _com_error captureError )
			{
				AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
			}
		}
		else
		{
			AfxMessageBox( _T("Fatal error: failed to capture an invalid window control."), MB_ICONERROR );
		}
	}
	else
	{
		AfxMessageBox( _T("Fatal error: Invalid window handle."), MB_ICONERROR );
	}
}

void CTcServerSampleDlg::OnTitleCapture()
{
	CString str;
	GetDlgItem(IDC_TITLE)->GetWindowText(str);

	if (m_pWindowCapture->FindWindowA(str.AllocSysString()))
	{
		if (m_pWindowCapture->IsValidWindow() == VARIANT_TRUE)
		{
			CString strResult;

			try
			{
				_bstr_t bstr = m_pTextCapture->GetText(m_pWindowCapture);
				strResult = (LPTSTR)bstr;

				GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);

				// 
				CString str;
				str.Format("%d", m_pWindowCapture->Handle);
				GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);

			}
			catch ( _com_error captureError )
			{
				AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
			}
		}
		else
		{
			AfxMessageBox( _T("Fatal error: failed to capture an invalid window control."), MB_ICONERROR );
		}
	}
	else
	{
		AfxMessageBox( _T("Fatal error: Window not found."), MB_ICONERROR );
	}
}

void CTcServerSampleDlg::OnActiveWindowCapture()
{
	m_pDemoActiveWindowDlg->ShowWindow(SW_SHOW);
	m_pDemoActiveWindowDlg->SetForegroundWindow();

	//
	if (m_pWindowCapture->WindowFromActiveWindow())
	{
		if (m_pWindowCapture->IsValidWindow() == VARIANT_TRUE)
		{
			CString strResult;

			try
			{
				_bstr_t bstr = m_pTextCapture->GetText(m_pWindowCapture);
				strResult = (LPTSTR)bstr;

				GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);

				// 
				CString str;
				str.Format("%d", m_pWindowCapture->Handle);
				GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);

			}
			catch ( _com_error captureError )
			{
				AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
			}
		}
		else
		{
			AfxMessageBox( _T("Fatal error: failed to capture an invalid window control."), MB_ICONERROR );
		}
	}
	else
	{
		AfxMessageBox( _T("Fatal error: Active Window not found."), MB_ICONERROR );
	}
}


void CTcServerSampleDlg::OnIExploreCapture()
{
	m_pDemoIExploreWindowDlg->ShowWindow(SW_SHOW);
	m_pDemoIExploreWindowDlg->SetForegroundWindow();

	//
	m_pWindowCapture->Handle = (long)m_pDemoIExploreWindowDlg->GetDlgItem(IDC_EXPLORER1)->GetSafeHwnd();

	if (m_pWindowCapture->IsValidWindow() /*&& m_pWindowCapture->WindowType == TextCaptureLib::WINDOWTYPE_IEXPLORE*/)
	{
		CString strResult;

		try
		{
			_bstr_t bstr = m_pTextCapture->GetHTMLText(m_pWindowCapture,  
				IsDlgButtonChecked(IDC_HTML_SOURCE)!=0 ? VARIANT_TRUE : VARIANT_FALSE);
			strResult = (LPTSTR)bstr;

			GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);

			// 
			CString str;
			str.Format("%d", m_pWindowCapture->Handle);
			GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);

		}
		catch ( _com_error captureError )
		{
			AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
		}
	}
	else
	{
		AfxMessageBox( _T("Fatal error: IExplore Window not found."), MB_ICONERROR );
	}
}

void CTcServerSampleDlg::OnRectCapture()
{
	CString str;

	RECT rect;

	GetDlgItem(IDC_POS_LEFT)->GetWindowText(str);
	rect.left = atoi(str.GetBuffer());

	GetDlgItem(IDC_POS_TOP)->GetWindowText(str);
	rect.top = atoi(str.GetBuffer());

	GetDlgItem(IDC_POS_RIGHT)->GetWindowText(str);
	rect.right = atoi(str.GetBuffer());

	GetDlgItem(IDC_POS_BOTTOM)->GetWindowText(str);
	rect.bottom = atoi(str.GetBuffer());

	CString strResult;

	try
	{
		// Get result from rect region
		if (m_pWindowCapture->WindowFromRect(rect.left, rect.top, rect.right, rect.bottom) == VARIANT_TRUE)
		{
			CString strResult;

			try
			{
				_bstr_t bstr = m_pTextCapture->GetText(m_pWindowCapture);
				strResult = (LPTSTR)bstr;


				GetDlgItem(IDC_RESULT_EDIT)->SetWindowText(strResult);

				// 
				CString str;
				str.Format("%d", m_pWindowCapture->Handle);
				GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);
			}
			catch ( _com_error captureError )
			{
				AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
			}
		}

	}
	catch ( _com_error captureError )
	{
		AfxMessageBox( _T("Unable to capture."), MB_ICONINFORMATION );
	}
}


void CTcServerSampleDlg::OnBnClickedAbout()
{
	try
	{
		ShowWindow(SW_HIDE);

		m_pTextCapture->AboutBox();

		ShowWindow(SW_SHOW);
	}
	catch ( _com_error captureError )
	{
	}
}

void CTcServerSampleDlg::OnClose() 
{
	// Closes the TextCaptureLib COM library on the current apartment
	if (m_pTextCapture != NULL)
		m_pTextCapture.Release();

	if (m_pWindowCapture != NULL)
		m_pWindowCapture.Release();

	::CoUninitialize();

	if (m_pDemoActiveWindowDlg)
	{
		m_pDemoActiveWindowDlg->DestroyWindow();
		delete m_pDemoActiveWindowDlg;
	}

	if (m_pDemoIExploreWindowDlg)
	{
		m_pDemoIExploreWindowDlg->DestroyWindow();
		delete m_pDemoIExploreWindowDlg;
	}
	
	CDialog::OnClose();
}

void CTcServerSampleDlg::OnTimer(UINT_PTR nIDEvent)
{
	if (nIDEvent == 1)
	{
		POINT point;
		GetCursorPos(&point);

		//HWND hWnd = ::WindowFromPoint(point);

		CString str;

		str.Format("Current mouse position:   X = %d, Y = %d", point.x, point.y);
		GetDlgItem(IDC_MOUSE_POS)->SetWindowText(str);

		//str.Format("%d", hWnd);
		//GetDlgItem(IDC_WINDOW_HANDLE)->SetWindowText(str);
	}

	CDialog::OnTimer(nIDEvent);
}

void CTcServerSampleDlg::OnBnClickedClear()
{
	GetDlgItem(IDC_RESULT_EDIT)->SetWindowText("");
}

