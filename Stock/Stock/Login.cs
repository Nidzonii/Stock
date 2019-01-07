﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TO-DO: Check Login username & password
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Stock; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM[dbo].[Login] WHERE[UserName] = '" + textBox1.Text + "' AND[Password] = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid username & password", "Error",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                Clear();
            }
            
        }

        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }
    }
}
