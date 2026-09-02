using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public partial class Avavorm : Form
    {
        TreeView tree;
        Button nupp;
        Label silt;
        PictureBox pilt;
        RadioButton tumeTeema;
        RadioButton heleTeema;
        public Avavorm()
        {
            Height = 600;
            Width = 1000;
            Text = "Naidis IKTpv25 Windows Forms";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;


            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));
            tn.Nodes.Add(new TreeNode("Pilt"));
            tn.Nodes.Add(new TreeNode("tumeTeema"));
            tn.Nodes.Add(new TreeNode("heleTeema"));
            tree.Nodes.Add(tn);


            //nupp, silt ja pilt
            nupp = new Button();
            nupp.Text = "Valjuta mind";
            nupp.Location = new Point(300, 100);
            nupp.Width = 100;
            nupp.Height = 50;
            nupp.Click += (sender, e) => { MessageBox.Show("Nuppu vajutati!");  };

            silt = new Label();
            silt.Text = "See on silt";
            silt.Location = new Point(300, 200);
            silt.Font = new Font("Arial", 16, FontStyle.Bold);
            silt.AutoSize = true;
            silt.MouseLeave += Silt_MouseLeave;
            silt.MouseHover += Silt_MouseHover;
            silt.MouseDoubleClick += Silt_MouseDoubleClick;

            pilt = new PictureBox();
            pilt.Image = Image.FromFile(@"..\..\Pildid\mem.jpg");
            pilt.Location = new Point(100, 100);
            pilt.Size = new Size(200, 200);
            pilt.SizeMode = PictureBoxSizeMode.StretchImage;
            pilt.MouseDoubleClick += Pilt_MouseDoubleClick;

            tumeTeema = new RadioButton();
            tumeTeema.Text = "Tume teema";
            tumeTeema.Location = new Point(300, 350);
            tumeTeema.CheckedChanged += TumeTeema;

            heleTeema = new RadioButton();
            heleTeema.Text = "Hele teema";
            heleTeema.Location = new Point(300, 380);
            heleTeema.CheckedChanged += HeleTeema; 


            Controls.Add(tree);
        }

        private void HeleTeema(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void TumeTeema(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
        }

        private void Pilt_MouseDoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.youtube.com/watch?v=cqAJ3ncDgbI&list=RDcqAJ3ncDgbI&start_radio=1",
                UseShellExecute = true
            });
        }

        private void Silt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            silt.BackColor = Color.Yellow;
        }

        private void Silt_MouseHover(object sender, EventArgs e)
        {
            silt.BackColor = Color.LightBlue;
            silt.BorderStyle = BorderStyle.Fixed3D;
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.BackColor = Color.Red;
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(nupp);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Silt")
            {
                Controls.Add(silt);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pilt);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "heleTeema") 
            {
                Controls.Add(heleTeema);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "tumeTeema")
            {
                Controls.Add(tumeTeema);
                tree.SelectedNode = null;
            }
        }
    }
}
