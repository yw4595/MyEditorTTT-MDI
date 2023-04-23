using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using static System.Windows.Forms.VisualStyles.VisualStyleElement;
/*
 * Author: Yanzhi Wang
 * 
 * Purpose: This class represents the main form of MyEditorTTT MDI application. It handles user interface events, such as opening, saving, and editing text files, as well as font and color selection. 
 * 
 * Restrictions: None
 */

namespace MyEditor
{
    public partial class Form1 : Form
    {
        public Form1(MyEditorParent myEditorParent)
        {
            InitializeComponent();

            // Register event handlers for menu items and toolbar buttons

            this.MdiParent = myEditorParent;

            //this.newToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem_Click);
            myEditorParent.openToolStripMenuItem.Click += new EventHandler(OpenToolStripMenuItem_Click);
            myEditorParent.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem_Click);
            //this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);


            myEditorParent.copyToolStripMenuItem.Click += new EventHandler(CopyToolStripMenuItem_Click);
            myEditorParent.cutToolStripMenuItem.Click += new EventHandler(CutToolStripMenuItem_Click);
            myEditorParent.pasteToolStripMenuItem.Click += new EventHandler(PasteToolStripMenuItem_Click);

            myEditorParent.closeAllToolStripMenuItem.Click += new EventHandler(CloseAllToolStripMenuItem_Click);

            this.boldToolStripMenuItem.Click += new EventHandler(BoldToolStripMenuItem_Click);
            this.italicsToolStripMenuItem.Click += new EventHandler(ItalicsToolStripMenuItem_Click);
            this.underlineToolStripMenuItem.Click += new EventHandler(UnderlineToolStripMenuItem_Click);

            this.testToolStripButton.Click += new EventHandler(TestToolStripButton_Click);

            this.mSSansSerifToolStripMenuItem.Click += new EventHandler(MSSansSerifToolStripMenuItem_Click);
            this.timesNewRomanToolStripMenuItem.Click += new EventHandler(TimesNewRomanToolStripMenuItem_Click);
            this.richTextBox.SelectionChanged += new EventHandler(RichTextBox_SelectionChanged);

            this.countdownLabel.Visible = false;
            this.timer.Tick += new EventHandler(Timer_Tick);

            this.toolStrip.ItemClicked += new ToolStripItemClickedEventHandler(ToolStrip_ItemClicked);

            // Set initial window title
            this.Text = "MyEditor";
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.newToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem_Click);
            MyEditorParent myEditorParent = (MyEditorParent)this.MdiParent;
            myEditorParent.openToolStripMenuItem.Click -= new EventHandler(OpenToolStripMenuItem_Click);
            myEditorParent.saveToolStripMenuItem.Click -= new EventHandler(SaveToolStripMenuItem_Click);
            //this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);


            myEditorParent.copyToolStripMenuItem.Click -= new EventHandler(CopyToolStripMenuItem_Click);
            myEditorParent.cutToolStripMenuItem.Click -= new EventHandler(CutToolStripMenuItem_Click);
            myEditorParent.pasteToolStripMenuItem.Click -= new EventHandler(PasteToolStripMenuItem_Click);

            myEditorParent.closeAllToolStripMenuItem.Click -= new EventHandler(CloseAllToolStripMenuItem_Click);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // disable the RichTextBox initially
            richTextBox.Enabled = false;
        }

        private void testToolStripButton_Click(object sender, EventArgs e)
        {
            // enable the RichTextBox after the button is clicked
            richTextBox.Enabled = true;
        }




        // This is an event handler for a timer's tick event
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Decrement the value of a progress bar
            --this.toolStripProgressBar1.Value;
            // If the progress bar reaches 0
            if (this.toolStripProgressBar1.Value == 0)
            {
                // Stop the timer
                this.timer.Stop();

                // Calculate the typing performance (letters per second)
                string performance = "Congratulations. You typed " + Math.Round(this.richTextBox.TextLength / 30.0, 2) + " letters per second";

                // Display a message box with the typing performance
                MessageBox.Show(performance);
            }
        }


        // This method handles the Click event for the "Bold" ToolStripMenuItem.
        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Define the font style to be applied.
            FontStyle fontStyle = FontStyle.Bold;
            // Declare and initialize a Font variable to hold the selected text's font.
            Font selectionFont = null;
            selectionFont = richTextBox.SelectionFont;

            // If no text is currently selected, use the default font for the control.
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            // Call the SetSelectionFont method to apply the desired font style to the selected text.
            // Pass in the desired font style and a boolean indicating whether or not to make the text bold.
            SetSelectionFont(fontStyle, !selectionFont.Bold);

        }

        private void TestToolStripButton_Click(object sender, EventArgs e)
        {
            // Set the interval of the timer to 500 milliseconds.
            this.timer.Interval = 500;
            // Set the value of the toolStripProgressBar1 to 60.
            this.toolStripProgressBar1.Value = 60;

            // Set the text of the countdownLabel to "3".
            this.countdownLabel.Text = "3";

            // Make the countdownLabel visible.
            this.countdownLabel.Visible = true;

            // Hide the richTextBox.
            this.richTextBox.Visible = false;

            // Start a loop to count down from 3 to 1, updating the text of the countdownLabel each time.
            for (int i = 3; i > 0; --i)
            {
                // Update the text of the countdownLabel.
                this.countdownLabel.Text = i.ToString();

                // Refresh the form.
                this.Refresh();

                // Pause the thread for 1 second using Thread.Sleep(1000).
                Thread.Sleep(1000);
            }

            // Hide the countdownLabel.
            this.countdownLabel.Visible = false;

            // Make the richTextBox visible.
            this.richTextBox.Visible = true;

            // Start the timer.
            this.timer.Start();

        }



            // This method handles the "Italic" option in a menu strip
            private void ItalicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Define a FontStyle variable and set it to italic
            FontStyle fontStyle = FontStyle.Italic;
            // Define a Font variable and set it to null
            Font selectionFont = null;

            // Get the currently selected text in the RichTextBox control
            selectionFont = richTextBox.SelectionFont;

            // If no text is currently selected, set the Font variable to the default font
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            // Call the SetSelectionFont method to set the selected text to italic or non-italic
            SetSelectionFont(fontStyle, !selectionFont.Italic);

        }




        // This is an event handler for the UnderlineToolStripMenuItem
        private void UnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Define a FontStyle variable to represent Underline font style
            FontStyle fontStyle = FontStyle.Underline;
            // Define a Font variable to represent the selected text's font
            Font selectionFont = null;

            // Get the font of the currently selected text in the RichTextBox
            selectionFont = richTextBox.SelectionFont;

            // If no text is selected, set the selectionFont to the default font of the RichTextBox
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            // Call the SetSelectionFont method to apply the Underline style to the selected text
            SetSelectionFont(fontStyle, !selectionFont.Underline);

        }



        // This method handles the click event of the "MS Sans Serif" menu item and changes the font of the selected text in the RichTextBox to "MS Sans Serif"
        private void MSSansSerifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new Font object with the "MS Sans Serif" font family, same size and style as the current selected text font
            Font newFont = new Font("MS Sans Serif", richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);
            // Set the font of the selected text in the RichTextBox to the newly created font
            richTextBox.SelectionFont = newFont;
        }

        // This method handles the click event of the "Times New Roman" menu item and changes the font of the selected text in the RichTextBox to "Times New Roman"
        private void TimesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new Font object with the "Times New Roman" font family, same size and style as the current selected text font
            Font newFont = new Font("Times New Roman", richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);
            // Set the font of the selected text in the RichTextBox to the newly created font
            richTextBox.SelectionFont = newFont;
        }

        // This method is an event handler for the RichTextBox SelectionChanged event.
        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            // Check if the selection in the RichTextBox has a font style.
            if (this.richTextBox.SelectionFont != null)
            {
                // Set the Checked property of the Bold, Italic, and Underline ToolStripButtons to reflect the current font style of the selection.
                this.boldToolStripButton.Checked = richTextBox.SelectionFont.Bold;
                this.italicsToolStripButton.Checked = richTextBox.SelectionFont.Italic;
                this.underlineToolStripButton.Checked = richTextBox.SelectionFont.Underline;
            }
            // Set the BackColor property of the Color ToolStripButton to reflect the current selection color of the RichTextBox.
            this.colorToolStripButton.BackColor = richTextBox.SelectionColor;
        }



            // Method to handle "New" menu item click
            private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the rich text box and reset window title
            richTextBox.Clear();
            this.Text = "MyEditor";
        }

        // Method to handle "Open" menu item click
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // the MdiParent form keeps track of which child form is currently active
            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            // Display the Open File dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Determine the file type based on extension
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;
                if (openFileDialog.FileName.ToLower().Contains(".txt"))
                {
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }

                // Load the file into the rich text box and update the window title
                richTextBox.LoadFile(openFileDialog.FileName, richTextBoxStreamType);
                this.Text = "MyEditor (" + openFileDialog.FileName + ")";
            }
        }

        // Method to handle "Save" menu item click
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // the MdiParent form keeps track of which child form is currently active
            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            // Use the filename from the Open File dialog if available
            saveFileDialog.FileName = openFileDialog.FileName;

            // Display the Save File dialog
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Determine the file type based on extension
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;
                if (saveFileDialog.FileName.ToLower().Contains(".txt"))
                {
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }

                // Save the contents of the rich text box to the file and update the window title
                richTextBox.SaveFile(saveFileDialog.FileName, richTextBoxStreamType);
                this.Text = "MyEditor (" + openFileDialog.FileName + ")";
            }
        }

        // Method to handle "Exit" menu item click
        private void ExitToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        // Method to handle "Copy" menu item click
        private void CopyToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // the MdiParent form keeps track of which child form is currently active
            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            // Copy the selected text to the clipboard
            richTextBox.Copy();
        }

        // Method to handle "Cut" menu item click
        private void CutToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // the MdiParent form keeps track of which child form is currently active
            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            // Cut the selected text to the clipboard
            richTextBox.Cut();
        }

        // Method to handle "Paste" menu item click
        private void PasteToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // the MdiParent form keeps track of which child form is currently active
            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            // Paste the contents of the clipboard into the rich text box
            richTextBox.Paste();
        }

        // Method to handle toolbar item clicks
        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular;
            ToolStripButton toolStripButton = null;

            if (e.ClickedItem == this.boldToolStripButton)
            {
                fontStyle = FontStyle.Bold;
                toolStripButton = this.boldToolStripButton;
            }
            else if (e.ClickedItem == this.italicsToolStripButton)
            {
                fontStyle = FontStyle.Italic;
                toolStripButton = this.italicsToolStripButton;

            }
            else if (e.ClickedItem == this.underlineToolStripButton)
            {
                fontStyle = FontStyle.Underline;
                toolStripButton = this.underlineToolStripButton;
            }


            else if (e.ClickedItem == this.colorToolStripButton)
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionColor = colorDialog.Color;
                    colorToolStripButton.BackColor = colorDialog.Color;
                }
            }


            if (fontStyle != FontStyle.Regular)
            {
                toolStripButton.Checked = !toolStripButton.Checked;
                SetSelectionFont(fontStyle, toolStripButton.Checked);
            }
        }


        // Method to set the font style for the selected text
        private void SetSelectionFont(FontStyle fontStyle, bool bSet)
        {
            Font newFont = null;
            Font selectionFont = null;
            selectionFont = richTextBox.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }
            if (bSet)
            {
                newFont = new Font(selectionFont, selectionFont.Style | fontStyle);
            }
            else
            {
                newFont = new Font(selectionFont, selectionFont.Style & ~fontStyle);
            }
            this.richTextBox.SelectionFont = newFont;
        }
         //This is a method called "StartTest" that is triggered by an event
        // with two parameters, sender and e of type object and EventArgs respectively.
        private void StartTest(object sender, EventArgs e)
        {
            // This starts a timer.
            timer.Start();
            // This enables a ToolStripContainer.
            toolStripContainer1.Enabled = true;

            // This disables a ToolStripButton.
            testToolStripButton.Enabled = false;

            // This sets the focus on a RichTextBox control.
            richTextBox.Focus();

        }

        private void countdownLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
      
    

