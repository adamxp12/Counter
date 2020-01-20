using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Counter
{
    public partial class Form1 : Form
    {
        public static DataSet dataSet;


        public Form1()
        {
            InitializeComponent();
        }

        public static void saveData()
        {
            Properties.Settings.Default.db = dataSet.GetXml();
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.db != null)
            {
                dataSet = new DataSet();
                dataSet.ReadXml(new StringReader(Properties.Settings.Default.db));


                if(dataSet.Tables.Count != 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        CountControl cC = new CountControl();
                        cC.Label = (string)row["name"];
                        cC.Count = Convert.ToInt32(row["count"]);
                        cC.Color = Color.FromArgb(Convert.ToInt32((string)row["color"]));
                        flowLayoutPanel1.Controls.Add(cC);
                    }
                } else
                {
                    // if no tables exist then create one so that data can be added
                    DataTable dt = new DataTable("counter");
                    dt.Columns.Add("name");
                    dt.Columns.Add("count");
                    dt.Columns.Add("color");
                    dataSet.Tables.Add(dt);
                    saveData();

                }



            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = DateTime.Now.ToString();
            dataSet.Tables[0].Rows.Add(name, 0, "0");

            CountControl cC = new CountControl();
            cC.Label = name;
            cC.Count = 0;
            cC.Color = Color.Aqua;
            flowLayoutPanel1.Controls.Add(cC);
            saveData();
        }
    }
}
