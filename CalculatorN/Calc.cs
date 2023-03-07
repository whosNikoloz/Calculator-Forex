using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CalculatorN
{
    public partial class Calc : Form
    {
        private char op;
        private double num1 = 0;
        private double num2 = 0;
        private int count = 0;
        private double ans = 0;
        public Calc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(op == '^')
            {
                double  temp3 = num1;
                num1 = num1 * num1;
                lblNum.Text = $"{temp3.ToString()} ^ {temp3.ToString()} =";
                ans = num1;
                txtRes.Text = num1.ToString();
                
            }else if(op == '?')
            {
                
                num1 = Math.Sqrt(num1);
                lblNum.Text = $"√{num1}";
                ans = num1;
                txtRes.Text = num1.ToString();
            }
            else
            {
                try
                {
                    num2 = double.Parse(txtRes.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Enter Num");
                }
                switch (op)
                {
                    case '+':
                        double temp = num1;
                        num1 = num1 + num2;
                        lblNum.Text = $"{temp.ToString()} + {num2.ToString()} =";
                        txtRes.Text = num1.ToString();
                        ans = num1;
                        break;
                    case '-':
                        temp = num1;
                        num1 = num1 - num2;
                        lblNum.Text = $"{temp.ToString()} - {num2.ToString()} =";
                        txtRes.Text = num1.ToString();
                        ans = num1;

                        break;
                    case 'x':
                        temp = num1;
                        num1 = num1 * num2;
                        lblNum.Text = $"{temp.ToString()} x {num2.ToString()} =";
                        txtRes.Text = num1.ToString();
                        ans = num1;
                        break;
                    case '/':
                        temp = num1;
                        num1 = num1 / num2;
                        lblNum.Text = $"{temp.ToString()} / {num2.ToString()} =";
                        txtRes.Text = num1.ToString();
                        ans = num1;

                        break;
                    
                }
            }
            
        }
        private void SetRoundButton(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddLine(radius, 0, button.Width - radius, 0);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(button.Width, radius, button.Width, button.Height - radius);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddLine(button.Width - radius, button.Height, radius, button.Height);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, button.Height - radius, 0, radius);
            button.Region = new Region(path);
        }

        private void Calc_Load(object sender, EventArgs e)
        {
            SetRoundButton(btnZero, 8);
            SetRoundButton(bntOne, 8);
            SetRoundButton(btnTwo, 8);
            SetRoundButton(btnTree, 8);
            SetRoundButton(btnFour, 8);
            SetRoundButton(btnFive, 8);
            SetRoundButton(btnSix, 8);
            SetRoundButton(btnSeven, 8);
            SetRoundButton(btnEight, 8);
            SetRoundButton(btnNine, 8);
            SetRoundButton(btnSum, 8);
            SetRoundButton(btnDot, 8);
            SetRoundButton(btnRemove, 8);
            SetRoundButton(btnPlus, 8);
            SetRoundButton(btnMult, 8);
            SetRoundButton(btnDivision, 8);
            SetRoundButton(btnClear1, 8);
            SetRoundButton(btnClear, 8);
            
        }
        private void NUmText(string text)
        {
            if (txtRes.Text == "0")
            {
                txtRes.Text = text;
            }
            else
            {
                txtRes.Text += text;
            }
        }

        private void bntOne_Click(object sender, EventArgs e)
        {
            NUmText("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            NUmText("2");
        }

        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            op = '+';

            count++;
            if (ans != 0)
            {
                num1 = ans;
                txtRes.Clear();
                lblNum.Text = num1.ToString() + "+";
            }
            else
            {
                if (count > 1)
                {
                    try
                    {
                        num2 = double.Parse(txtRes.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Num");
                    }
                    switch (op)
                    {
                        case '+':
                            num1 = num1 + num2;
                            txtRes.Text = num1.ToString();
                            lblNum.Text = txtRes.Text + " +";
                            txtRes.Clear();
                            break;
                    }
                }
                else
                {
                    num1 = double.Parse(txtRes.Text);
                    lblNum.Text = txtRes.Text + " +";
                    txtRes.Clear();
                }
            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            op = '-';

            count++;
            if (ans != 0)
            {
                num1 = ans;
                txtRes.Clear();
                lblNum.Text = num1.ToString() + "-";
            }
            else
            {
                if (count > 1)
                {
                    try
                    {
                        num2 = double.Parse(txtRes.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Num");
                    }
                    switch (op)
                    {
                        case '-':
                            num1 = num1 - num2;
                            txtRes.Text = num1.ToString();
                            lblNum.Text = txtRes.Text + " -";
                            txtRes.Clear();
                            break;
                    }
                }
                else
                {
                    num1 = double.Parse(txtRes.Text);
                    lblNum.Text = txtRes.Text + " -";
                    txtRes.Clear();
                }
            }
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            op = 'x';

            count++;
            if (ans != 0)
            {
                num1 = ans;
                txtRes.Clear();
                lblNum.Text = num1.ToString() + "x";
            }
            else
            {
                if (count > 1)
                {
                    try
                    {
                        num2 = double.Parse(txtRes.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Num");
                    }
                    switch (op)
                    {
                        case 'x':
                            num1 = num1 * num2;
                            txtRes.Text = num1.ToString();
                            lblNum.Text = txtRes.Text + " x";
                            txtRes.Clear();
                            break;
                    }
                }
                else
                {
                    num1 = double.Parse(txtRes.Text);
                    lblNum.Text = txtRes.Text + " x";
                    txtRes.Clear();
                }
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            op = '/';

            count++;
            if(ans != 0)
            {
                num1 = ans;
                txtRes.Clear();
                lblNum.Text = num1.ToString()+ "/";
            }
            else
            {
                if (count > 1)
                {
                    try
                    {
                        num2 = double.Parse(txtRes.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Num");
                    }
                    switch (op)
                    {
                        case '/':
                            num1 = num1 / num2;
                            txtRes.Text = num1.ToString();
                            lblNum.Text = txtRes.Text + " /";
                            txtRes.Clear();
                            break;
                    }
                }
                else
                {
                    num1 = double.Parse(txtRes.Text);
                    lblNum.Text = txtRes.Text + " /";
                    txtRes.Clear();
                }
            }
            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtRes.Text += '.';
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            NUmText("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            NUmText("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            NUmText("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            NUmText("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            NUmText("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            NUmText("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            NUmText("9");
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            NUmText("0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            count = 0;
            txtRes.Text = "0";
            lblNum.Text= " ";
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            count = 0;
            txtRes.Clear();
            lblNum.Text = " ";
        }
        private double temp1 = 0;
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            op = '?';

            
            count++;
            if (ans != 0)
            {
                num1 = ans;
                txtRes.Clear();
                lblNum.Text = num1.ToString() + "√";
            }
            else
            {
                if (count > 1)
                {
                    try
                    {
                        num2 = double.Parse(txtRes.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Num");
                    }
                    switch (op)
                    {
                        case '?':
                            num1 = Math.Sqrt(temp1);
                            txtRes.Text = (Math.Sqrt(num1).ToString());
                            lblNum.Text = txtRes.Text + " ?";
                            txtRes.Clear();
                            break;
                    }
                }
                else
                {
                    num1 = double.Parse(txtRes.Text);
                    lblNum.Text = "√" + txtRes.Text;
                    temp1 = num1;
                    txtRes.Clear();
                }
            }
        }
        private double temp2 = 0;
        private void btnPow_Click(object sender, EventArgs e)
        {
            op = '^';

            count++;
            
            if (ans != 0)
            {
                num1 = ans;
                txtRes.Clear();
                lblNum.Text = num1.ToString() + "^";
            }
            else
            {
                if (count > 1)
                {
                    try
                    {
                        num2 = double.Parse(txtRes.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Num");
                    }
                    switch (op)
                    {
                        case '^':
                            num1 = Math.Sqrt(temp2);
                            txtRes.Text = (Math.Sqrt(num1).ToString());
                            lblNum.Text = txtRes.Text + " ^";
                            txtRes.Clear();
                            break;
                    }
                }
                else
                {
                    num1 = double.Parse(txtRes.Text);
                    lblNum.Text = "^" + txtRes.Text;
                    temp2 = num1;
                    txtRes.Clear();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!txtRes.Text.Contains('-'))
            {
                txtRes.Text = '-' + txtRes.Text;
            }
            else
            {
                txtRes.Text.Remove(0);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string currentText = txtRes.Text;

            if (!string.IsNullOrEmpty(currentText))
            {
                currentText = currentText.Remove(currentText.Length - 1);
            }

            txtRes.Text = currentText;
        }

        private void Calc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                MessageBox.Show("You pressed the A key!");
            }
        }
    }
}
