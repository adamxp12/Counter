using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Counter
{
    public partial class SettingsBox : Form
    {
        public SettingsBox()
        {
            InitializeComponent();
        }

        public String Label
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        public int Count
        {
            get
            {
                return Convert.ToInt32(numericUpDown1.Value);
            }

            set
            {
                numericUpDown1.Value = value;
            }
        }

        public Color Color
        {
            get
            {
                return colorDialog1.Color;
            }

            set
            {
                colorDialog1.Color = value;
            }
        }

        private void SettingsBox_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
