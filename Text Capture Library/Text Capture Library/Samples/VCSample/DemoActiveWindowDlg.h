#pragma once


// CDemoActiveWindowDlg Dialog

class CDemoActiveWindowDlg : public CDialog
{
	DECLARE_DYNAMIC(CDemoActiveWindowDlg)

public:
	CDemoActiveWindowDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CDemoActiveWindowDlg();

// 对话框数据
	enum { IDD = IDD_ACTIVE_DIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	BOOL CreateModaless( CWnd * pParentWnd = NULL);
};
