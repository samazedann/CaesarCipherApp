using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaesarCipherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text.ToUpper();

            if (!int.TryParse(txtShift.Text, out int shift))
            {
                MessageBox.Show("Enter a valid number");

                return;
            }

            string result = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar =
                        (char)(((c - 'A' + shift) % 26) + 'A');

                    result += encryptedChar;
                }
                else
                {
                    result += c;
                }
            }

            txtResult.Text = result;
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text.ToUpper();

            if (!int.TryParse(txtShift.Text, out int shift))
            {
                MessageBox.Show("Enter a valid number");

                return;
            }

            string result = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char decryptedChar =
                        (char)(((c - 'A' - shift + 26) % 26) + 'A');

                    result += decryptedChar;
                }
                else
                {
                    result += c;
                }
            }

            txtResult.Text = result;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);

            MessageBox.Show("Copied Successfully");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();

            txtResult.Clear();

            txtShift.Clear();

            txtInput.Focus();
        }
    }
}
