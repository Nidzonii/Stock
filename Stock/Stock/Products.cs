using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Products : Form
    {
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Stock; Integrated Security = True");

        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBox1.SelectedIndex = 0;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Products", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            con.Open();
            bool status = false;
            if(comboBox1.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Products] ([ProductCode],[ProductName],[ProductStatus]) VALUES ('"+textBox1.Text + "', '" + textBox2.Text + "', '" + status + "')", con);
            cmd.ExecuteNonQuery();


            con.Close();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Products",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
            }

        }
    }
}
