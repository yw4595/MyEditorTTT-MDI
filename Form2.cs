using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
Author: Yanzhi Wang
Purpose: This class represents a form used in the MyEditor application.
Restrictions: None known.
*/

namespace MyEditor
{
    public partial class MyEditorParent : Form
    {
        public MyEditorParent()
        {
            InitializeComponent();

            this.newToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem_Click);
            this.tileToolStripMenuItem.Click += new EventHandler(TileToolStripMenuItem_Click);
            this.cascadeToolStripMenuItem.Click += new EventHandler(CascadeToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);

            Form1 form1 = new Form1(this);
            form1.Show();
        }

        //Purpose: Event handler for the "Tile" menu item click event. Tiles the open forms horizontally.
        private void TileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        //Purpose: Event handler for the "Cascade" menu item click event. Cascades the open forms.
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //Purpose: Event handler for the "New" menu item click event. Creates a new instance of Form1 and displays it.
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            form1.Show();
        }

        //Purpose: Event handler for the "Exit" menu item click event. Exits the application.
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Application.Exit();   
        }
    }
}
