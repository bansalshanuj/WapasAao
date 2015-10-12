// TcServerSample.h : main header file for the TCSERVERSAMPLE application
//

#if !defined(AFX_TCSERVERSAMPLE_H__32AD9C91_2ABB_40CF_A8FF_787A930BCEDD__INCLUDED_)
#define AFX_TCSERVERSAMPLE_H__32AD9C91_2ABB_40CF_A8FF_787A930BCEDD__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CTcServerSampleApp:
// See TcServerSample.cpp for the implementation of this class
//

class CTcServerSampleApp : public CWinApp
{
public:
	CTcServerSampleApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTcServerSampleApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CTcServerSampleApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TCSERVERSAMPLE_H__32AD9C91_2ABB_40CF_A8FF_787A930BCEDD__INCLUDED_)
