using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Counter
{
    public partial class CountControl : UserControl
    {

        public CountControl()
        {
            InitializeComponent();
        }

        public String Label
        {
            get
            {
                return label2.Text;
            }

            set
            {
                label2.Text = value;
            }
        }

        public Int32 Count
        {
            get
            {
                return Convert.ToInt32(label1.Text);
            }

            set
            {
                label1.Text = Convert.ToString(value);
            }
        }

        public Color Color
        {
            get
            {
                return label1.BackColor;
            }

            set
            {
                label1.BackColor = value;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Int32 current = Convert.ToInt32(label1.Text);

            foreach (DataRow r in Form1.dataSet.Tables[0].Select("name = '" + label2.Text + "'"))
            {
                current = Convert.ToInt32(r[1].ToString());
                r[1] = current + 1;
                Form1.saveData();
            }

            current++;

            label1.Text = Convert.ToString(current);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Int32 current = Convert.ToInt32(label1.Text);

            foreach (DataRow r in Form1.dataSet.Tables[0].Select("name = '" + label2.Text + "'"))
            {
               current = Convert.ToInt32(r[1].ToString());
                r[1] = current - 1;
                Form1.saveData();
            }

            current--;

            label1.Text = Convert.ToString(current);
        }

        private void CountControl_Load(object sender, EventArgs e)
        {

           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in Form1.dataSet.Tables[0].Select("name = '" + label2.Text + "'"))
            {
                r.Delete();
                Form1.saveData();
            }

            this.Parent.Controls.Remove(this);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SettingsBox sb = new SettingsBox();
            sb.Label = label2.Text;
            sb.Count = Convert.ToInt32(label1.Text);
            sb.Color = label1.BackColor;
            sb.ShowDialog();
            
            foreach (DataRow r in Form1.dataSet.Tables[0].Select("name = '" + label2.Text + "'"))
            {
                r[0] = sb.Label;
                r[1] = sb.Count;
                r[2] = sb.Color.ToArgb().ToString();
                label1.Text = sb.Count.ToString();
                label2.Text = sb.Label;
                label1.BackColor = sb.Color;
                Form1.saveData();
            }
        }
    }
}
