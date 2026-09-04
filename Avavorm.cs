using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
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
        CheckBox mruut1, mruut2;
        TextBox tbox;
        TabControl tabs;
        TabPage tab1, tab2, tab3;
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
            tn.Nodes.Add(new TreeNode("Markeruut"));
            tn.Nodes.Add(new TreeNode("Tekstivali"));
            tn.Nodes.Add(new TreeNode("Vahekaardid"));
            tree.Nodes.Add(tn);


            //nupp, silt ja pilt
            nupp = new Button();
            nupp.Text = "Valjuta mind";
            nupp.Location = new Point(300, 100);
            nupp.Width = 100;
            nupp.Height = 50;
            nupp.Click += (sender, e) => { MessageBox.Show("Nuppu vajutati!"); };

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
            else if (e.Node.Text == "Markeruut")
            {
                mruut1 = new CheckBox();
                mruut1.Text = "Tee suuremaks";
                mruut1.Location = new Point(300, 100);
                mruut1.AutoSize = true;
                mruut1.CheckedChanged += Mruut1_CheckedChanged;

                mruut2 = new CheckBox();
                mruut2.Text = "Tee vaiksemaks";
                mruut2.Location = new Point(300, 150);
                mruut2.AutoSize = true;
                mruut2.CheckedChanged += Mruut2_CheckedChanged;

                Controls.Add(mruut1);
                Controls.Add(mruut2);
            }

            else if (e.Node.Text == "Tekstivali")
            {
                tbox = new TextBox();
                tbox.Location = new Point(200, 500);
                tbox.Width = 200;
                tbox.TextChanged += (s, arg) =>
                {
                    Controls.Add(silt);
                    if (tbox.Text.Length > 0)
                    {
                        silt.Text = tbox.Text;
                    }
                    if (tbox.Text.Length == 0)
                    {
                        silt.Text = "See on silt";
                    }
                };
                Controls.Add(tbox);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Vahekaardid")
            {
                tabs = new TabControl();
                tabs.Location = new Point(500, 100);
                tabs.Size = new Size(450, 400);

                tab1 = new TabPage("Techno+TLN");

                WebBrowser brauser = new WebBrowser();
                brauser.Dock = DockStyle.Fill;
                brauser.ScriptErrorsSuppressed = true;
                brauser.Url = new Uri("https://techno.ee/");

                tab1.Controls.Add(brauser);

                tab2 = new TabPage("Fnaf 1");

                WebBrowser brauser2 = new WebBrowser();
                brauser2.Dock = DockStyle.Fill;
                brauser2.ScriptErrorsSuppressed = true;
                brauser2.Url = new Uri("https://irv77.github.io/hd_fnaf/1/");

                tab2.Controls.Add(brauser2);

                tab3 = new TabPage("+");

                tabs.SelectedIndexChanged += (s, arg) =>
                {
                    if (tabs.SelectedTab == tab3)
                    {
                        string uuskardinimi = Interaction.InputBox(
                            "Sisesta uue vahekaardi nimi:"
                        );

                        if (string.IsNullOrWhiteSpace(uuskardinimi))
                        {
                            MessageBox.Show("Vahekaardi nimi ei tohi olla tühi!");
                            tabs.SelectedTab = tab1;
                            return;
                        }


                        string veebiadress = Interaction.InputBox(
                            "Sisesta veebiaadress, mida soovid avada:"
                        );

                        if (string.IsNullOrWhiteSpace(veebiadress))
                        {
                            MessageBox.Show("Veebiaadress ei tohi olla tühi!");
                            tabs.SelectedTab = tab1;
                            return;
                        }

                        if (!veebiadress.StartsWith("http://") &&
                            !veebiadress.StartsWith("https://"))
                        {
                            veebiadress = "https://" + veebiadress;
                        }


                        Uri uri;

                        try
                        {
                            uri = new Uri(veebiadress);
                        }
                        catch
                        {
                            MessageBox.Show("Vale veebiaadress!");
                            tabs.SelectedTab = tab1;
                            return;
                        }


                        var vastus = MessageBox.Show(
                            $"Kas soovite uue vahekaardi nimega '{uuskardinimi}'?",
                            "Kinnita",
                            MessageBoxButtons.YesNo
                        );

                        if (vastus == DialogResult.No)
                        {
                            tabs.SelectedTab = tab1;
                            return;
                        }


                        TabPage uusVahekaart = new TabPage(uuskardinimi);
                        WebBrowser uusBrauser = new WebBrowser();
                        uusBrauser.Dock = DockStyle.Fill;
                        uusBrauser.ScriptErrorsSuppressed = true;
                        uusBrauser.Url = uri;

                        uusVahekaart.Controls.Add(uusBrauser);

                        tabs.TabPages.Insert(tabs.TabCount - 1, uusVahekaart);
                        tabs.SelectedTab = uusVahekaart;
                    }
                };


                tabs.TabPages.Add(tab1);
                tabs.TabPages.Add(tab2);
                tabs.TabPages.Add(tab3);

                Controls.Add(tabs);

                tree.SelectedNode = null;
            }

        }

        private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut2.Checked)
            {
                Size = new Size(500, 300);
                mruut2.Text = "Tee vaiksemaks";
            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked)
            {
                Size = new Size(1000, 600);
                mruut1.Text = "Tee suuremaks";
            }
        }
    }
}
