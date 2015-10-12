#pragma once
#include "IExplore.h"


// CDemoIExploreWindowDlg Dialog

class CDemoIExploreWindowDlg : public CDialog
{
	DECLARE_DYNAMIC(CDemoIExploreWindowDlg)

public:
	CDemoIExploreWindowDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CDemoIExploreWindowDlg();

// 对话框数据
	enum { IDD = IDD_IEXPLORE_DIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	BOOL CreateModaless( CWnd * pParentWnd = NULL);
	CExplorer1 m_ieControl;
};
