// TcServerSampleDlg.h : header file
//

#if !defined(AFX_TCSERVERSAMPLEDLG_H__50A1619E_CA44_454C_8D80_543D6EC81A5A__INCLUDED_)
#define AFX_TCSERVERSAMPLEDLG_H__50A1619E_CA44_454C_8D80_543D6EC81A5A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "DemoActiveWindowDlg.h"
#include "DemoIExploreWindowDlg.h"

//////////////////////////////////////////////////////////////////////////
// Import _TextCaptureLib COM defination
//
#import "..\..\Lib\_TextCaptureLib.tlb"
//
//////////////////////////////////////////////////////////////////////////


// CTcServerSampleDlg dialog

class CTcServerSampleDlg : public CDialog
{
// Construction
public:

	// Declare the TextCaptureLib COM library object
	TextCaptureLib::ITextCapturePtr m_pTextCapture;	
	TextCaptureLib::IWindowPtr		m_pWindowCapture;

	CTcServerSampleDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CTcServerSampleDlg)
	enum { IDD = IDD_TCSERVERSAMPLE_DIALOG };

	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTcServerSampleDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

private:
	CDemoActiveWindowDlg	*m_pDemoActiveWindowDlg;
	CDemoIExploreWindowDlg	*m_pDemoIExploreWindowDlg;
// Implementation

protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CTcServerSampleDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedAbout();
	afx_msg void OnMouseCapture();
	afx_msg void OnHandleCapture();
	afx_msg void OnIExploreCapture();
	afx_msg void OnMouseXYCapture();
	afx_msg void OnTitleCapture();
	afx_msg void OnActiveWindowCapture();
	afx_msg void OnRectCapture();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnBnClickedClear();
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TCSERVERSAMPLEDLG_H__50A1619E_CA44_454C_8D80_543D6EC81A5A__INCLUDED_)
