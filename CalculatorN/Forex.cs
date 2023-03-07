using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CalculatorN = CalculatorN.CurrencyConverter;
using System.Collections.Generic;
using System.Globalization;

namespace CalculatorN
{
    public partial class Forex : Form
    {
        CurrencyConverter currencyConverter;
        public Forex()
        {
            InitializeComponent();
            currencyConverter = new CurrencyConverter();
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
            btnConverter.Text = "C\nO\nN\nV\nE\nR\nT";
            btnConverter.AutoSize = false;
            btnConverter.Size = new Size(30, 200);
            btnConverter.Font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            btnConverter.TextAlign = ContentAlignment.MiddleCenter;
            btnConverter.FlatStyle = FlatStyle.Flat;
            btnConverter.FlatAppearance.BorderSize = 0;
        }

        private void Forex_Load(object sender, EventArgs e)
        {
            SetRoundButton(btnConverter, 8);
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
            SetRoundButton(btnDot, 8);
            SetRoundButton(btnClear, 8);

            Dictionary<string, string> symbolData = currencyConverter.GetSymbols();
            cmbFromCurrency.Items.Clear();
            cmbToCurrency.Items.Clear();

            cmbFromCurrency.DataSource = new BindingSource(symbolData, null);
            cmbFromCurrency.DisplayMember = "Value";
            cmbFromCurrency.ValueMember = "Key";

            cmbToCurrency.DataSource = new BindingSource(symbolData, null);
            cmbToCurrency.DisplayMember = "Value";
            cmbToCurrency.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fromCurrency = ((KeyValuePair<string, string>)cmbFromCurrency.SelectedItem).Key;
            string toCurrency = ((KeyValuePair<string, string>)cmbToCurrency.SelectedItem).Key;

            double currencyAmount = double.Parse(txtFromCurrencyAmount.Text);
            double finalValue = currencyConverter.Convert(fromCurrency, toCurrency, currencyAmount);

            txtToCurrencyAmount.Text = finalValue.ToString();
        }
        private void NUmText(string text)
        {
            if (txtFromCurrencyAmount.Text == "0")
            {
                txtFromCurrencyAmount.Text = text;
            }
            else
            {
                txtFromCurrencyAmount.Text += text;
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

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtFromCurrencyAmount.Text += '.';
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFromCurrencyAmount.Clear();
            txtToCurrencyAmount.Clear();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            NUmText("0");
        }
    }
}
