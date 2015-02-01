using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDice
{
    public partial class Form1 : Form
    {
        public TextBox[] txtName = new TextBox[10];
        public TextBox[] txtNum = new TextBox[10];
        public Label[] lblNum = new Label[10];
        public TextBox[] txtSide = new TextBox[10];
        public Label[] lblSide = new Label[10];
        public TextBox[] txtMod = new TextBox[10];
        public Label[] lblMod = new Label[10];
        public Button[] cmdRoll = new Button[10];
        public Label[] lblResult = new Label[10];
        public Random rnd = new Random();

        public event FormClosingEventHandler FormClosing;
        

        public Form1()
        {
            InitializeComponent();

            

            Int32 Offset;
            Int32 VOffset = 25;

            System.Collections.Specialized.StringCollection NameSettings = CSDice.Properties.Settings.Default.Name;
            System.Collections.Specialized.StringCollection NumSettings = CSDice.Properties.Settings.Default.Num;
            System.Collections.Specialized.StringCollection SideSettings = CSDice.Properties.Settings.Default.Side;
            System.Collections.Specialized.StringCollection ModSettings = CSDice.Properties.Settings.Default.Modi;

            for (int I = 0; I < 10; I++)
            {
                Offset = 0;

                txtName[I] = new TextBox();
                txtName[I].Text = NameSettings[I];
                txtName[I].Size = new Size(120, 25);
                txtName[I].Location = new Point(Offset, VOffset * I);
                this.Controls.Add(txtName[I]);
                Offset += 120;

                lblNum[I] = new Label();
                lblNum[I].Text = ":";
                lblNum[I].Location = new Point(Offset, I * VOffset + 3);
                lblNum[I].Size = new Size(10, 20);
                this.Controls.Add(lblNum[I]);
                Offset += 15;

                txtNum[I] = new TextBox();
                txtNum[I].Text = NumSettings[I];
                txtNum[I].Location = new Point(Offset, I * VOffset);
                txtNum[I].Size = new Size(20, 25);
                this.Controls.Add(txtNum[I]);
                Offset += 20;

                lblSide[I] = new Label();
                lblSide[I].Text = "D";
                lblSide[I].Location = new Point(Offset, I * VOffset + 3);
                lblSide[I].Size = new Size(10, 20);
                this.Controls.Add(lblSide[I]);
                Offset += 15;

                txtSide[I] = new TextBox();
                txtSide[I].Text = SideSettings[I];
                txtSide[I].Location = new Point(Offset, I * VOffset);
                txtSide[I].Size = new Size(20, 25);
                this.Controls.Add(txtSide[I]);
                Offset += 20;

                lblMod[I] = new Label();
                lblMod[I].Text = "+/-";
                lblMod[I].Location = new Point(Offset, I * VOffset + 3);
                lblMod[I].Size = new Size(25, 20);
                this.Controls.Add(lblMod[I]);
                Offset += 25;

                txtMod[I] = new TextBox();
                txtMod[I].Text = ModSettings[I];
                txtMod[I].Location = new Point(Offset, I * VOffset);
                txtMod[I].Size = new Size(20, 25);
                this.Controls.Add(txtMod[I]);
                Offset += 25;

                cmdRoll[I] = new Button();
                cmdRoll[I].Text = "Roll";
                cmdRoll[I].Location = new Point(Offset, I * VOffset - 2);
                cmdRoll[I].Size = new Size(50, 25);
                cmdRoll[I].Tag = I;
                //AddHandler cmdRoll[I].Click, AddressOf this.Roll;
                cmdRoll[I].Click += new EventHandler(Roll);
                this.Controls.Add(cmdRoll[I]);
                Offset += 50;

                lblResult[I] = new Label();
                lblResult[I].Text = "0";
                lblResult[I].Location = new Point(Offset, I * VOffset + 3);
                lblResult[I].Size = new Size(20, 20);
                this.Controls.Add(lblResult[I]);


            }
            //this.Controls.Add
            this.Width = 350;
            this.Height = 300;

        }

        public void Roll(Object sender, EventArgs e)
        {
            Button cmdRoll = sender as Button;
            Int32 Index = Convert.ToInt32(cmdRoll.Tag);
            Int32 Num, Sides, Mod, Min, Max, Roll;
            String Result;
            //The below is exploded to one thing per line for troubleshooting.
            //It can be all set up on one line.
            Num = int.Parse(txtNum[Index].Text);
            Sides = int.Parse(txtSide[Index].Text);
            Mod = int.Parse(txtMod[Index].Text);
            Min = Num;
            Max = Num * Sides + Mod + 1;
            Roll = rnd.Next(Min, Max);
            Result = Convert.ToString(Roll);
            lblResult[Index].Text = Result;
            //The below is the one line version.
            //lblResult[Index].Text = Convert.ToString(rnd.Next(int.Parse(txtNum[Index].Text), int.Parse(txtNum[Index].Text) * int.Parse(txtSide[Index].Text) + int.Parse(txtMod[Index].Text) + 1));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveSettings()
        {
            System.Collections.Specialized.StringCollection NameSettings = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection NumSettings = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection SideSettings = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection ModSettings = new System.Collections.Specialized.StringCollection();
            for (int I = 0; I < 10; I++)
            {
                NameSettings.Add(txtName[I].Text);
                NumSettings.Add(txtNum[I].Text);
                SideSettings.Add(txtSide[I].Text);
                ModSettings.Add(txtMod[I].Text);
            }
            CSDice.Properties.Settings.Default.Name = NameSettings;
            CSDice.Properties.Settings.Default.Num = NumSettings;
            CSDice.Properties.Settings.Default.Side = SideSettings;
            CSDice.Properties.Settings.Default.Modi = ModSettings;
            CSDice.Properties.Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
    }
}
