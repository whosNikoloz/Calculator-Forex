using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        

        private void btnCalc_Click(object sender, EventArgs e)
        {
            loadform(new Calc());
           this.Size = new Size(402, 466);
            Calc f= new Calc();
            panelMenu.BackColor = f.BackColor;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new Forex());
            this.Size = new Size(462, 477);
            Forex f = new Forex();
            panelMenu.BackColor = f.BackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
