using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TcServerSample
{
    public partial class Form1 : Form
    {
        // Declare the TextCaptureLib COM object.  
        // NOTE: You must add a reference to the project 
        // in order for this line to compile.  
        private TextCaptureLib.CTextCapture TcServer;

        public Form1()
        {
            InitializeComponent();

            // Create a new TextCaptureLib COM object.
            TcServer = new TextCaptureLib.CTextCapture();

            // Your registration information goes here 

            /*
            if (TcServer.License("Your Name Here", "Your License Here"))
            {
                // The registered version of Text Capture Library
            }
            else
            {
                // The trial version of Text Capture Library
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int nHandle;

            //try
            //{
            //    nHandle = System.Convert.ToInt32(txtHandle.Text);
            //}
            //catch (System.FormatException)
            //{
            //    MessageBox.Show("FormatException in conversion.");
            //    nHandle = 0;
            //}

            //if (nHandle == 0)
            //{
            //    textBox1.Text = "Error!\nPlease input a existing window handle!!!!";
            //    txtHandle.Focus();
            //    return;
            //}

            try
            {
                TextCaptureLib.CInputWindow TcWindow;
                TcWindow = new TextCaptureLib.CInputWindow();
                TcWindow.Handle = nHandle;

                textBox1.Text = TcServer.GetText(TcWindow);

                TcWindow = null;

                //Thread.Sleep(3000);
                //TextCaptureLib.CInputWindow TcWindow;
                //TcWindow = new TextCaptureLib.CInputWindow();
                //if (TcWindow.WindowFromRect(651, 541, 978, 580))
                //    textBox1.Text = TcServer.GetText(TcWindow);

                //TcWindow = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Visible = false;
            TcServer.AboutBox();
            Visible = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            TcServer = null;
        }
    }
}
