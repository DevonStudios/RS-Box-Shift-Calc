using System.Windows.Forms;
using System.Globalization;

namespace RS_Box_Shift_Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (_MaskedTextBox1.Text != "" && _MaskedTextBox2.Text != "" && _MaskedTextBox3.Text != "" && _MaskedTextBox4.Text != "")
            {
                uint initialSeed = uint.Parse(_MaskedTextBox1.Text, NumberStyles.HexNumber);
                string currentSeed = _MaskedTextBox2.Text;

                if (currentSeed.Length < 8)
                {
                    MessageBox.Show("The inserted Current Seed is too short", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string currentSeedInverted = "";

                    for (int i = 6; i >= 0; i -= 2)
                    {
                        currentSeedInverted += currentSeed.Substring(i, 2);
                    }
                    uint currentSeedFinal = uint.Parse(currentSeedInverted, NumberStyles.HexNumber);
                    uint dolphinFrame = uint.Parse(_MaskedTextBox4.Text);
                    uint vbaTarget = uint.Parse(_MaskedTextBox3.Text);
                    uint frame = 1;
                    uint pokémonOffset;

                    if (comboBox2.SelectedIndex == 0)
                    {
                        pokémonOffset = 654;
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        pokémonOffset = 2;
                    }
                    else if (comboBox2.SelectedIndex == 5)
                    {
                        pokémonOffset = 404;
                    }
                    else if (comboBox2.SelectedIndex == 6)
                    {
                        pokémonOffset = 431;
                    }
                    else
                    { pokémonOffset = 56; }

                    if (vbaTarget <= pokémonOffset)
                    {
                        MessageBox.Show("Target Frame is lower than the Offset", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        while (initialSeed != currentSeedFinal)
                        {
                            uint result = 0x41C64E6D * initialSeed + 0x00006073;
                            frame++;
                            initialSeed = result;
                        }
                        label10.Text = frame.ToString();

                        if ((vbaTarget - frame) < pokémonOffset)
                        {
                            MessageBox.Show("Target Frame - Current Frame is lower than the Offset", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        { textBox6.Text = (vbaTarget - frame + dolphinFrame - pokémonOffset).ToString(); }
                    }
                }
            }
            else
            { MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "80B1E9F8";
            }
        }

        private void TextBox6_Enter(object sender, System.EventArgs e)
        {
            label1.Focus();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("New Order Of Breeding © \nOriginal concept and idea by _Dragon & Drakero \nAddresses found by N.O.O.B. Team \nDeveloped by Real96 & Signum21", "About", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TextBox6_DoubleClick(object sender, System.EventArgs e)
        {
            textBox6.Text = "";
        }
    }
}