# TextCaptureLib COM library python demo
#

# Text Capture Library COM python demo
# http://www.skesoft.com
#

import win32com.client 	# http://sourceforge.net/projects/pywin32/
import win32com.client.dynamic

from Tkinter import *
from time import *

class App:

    def __init__(self, master):

        frame = Frame(master)
        frame.pack()
        self.root = master
        
        self.labelMessage = Label(frame, text="Three seconds after you clicked this button, the mouse pointed window will be captured.")
        self.labelMessage.pack()
        
        self.btnCapture = Button(frame, text="Capture It", fg="red", command=self.capture)
        self.btnCapture.pack()
        
        self.textBox = Text(frame)
        self.textBox.pack()
        
        self.btnClear = Button(frame, text="Clear Result", command=self.clear)
        self.btnClear.pack()
        
        self.tcServer = win32com.client.dynamic.Dispatch('TextCaptureLib.TextCapture.1')
        self.tcWindow = win32com.client.dynamic.Dispatch('TextCaptureLib.Window.1')
        
        # Please set your license info
        
        #if tcServer.License('Your Name Here', 'Your License Here'):
        #    #The registered version of Text Capture Library
        #else:
        #    #The trial version of Text Capture Library
                    

    def capture(self):
        self.clear()
        
        self.root.withdraw()
        
        sleep(3)
        self.tcWindow.WindowFromCurrentPos()
        
        self.textBox.insert(END, self.tcServer.GetText(self.tcWindow))
        
        self.root.update()
        self.root.deiconify()

    
    def clear(self):
        self.textBox.delete(1.0, END)

root = Tk()
root.title("Text Capture Library COM python demo")

app = App(root)

root.mainloop()
