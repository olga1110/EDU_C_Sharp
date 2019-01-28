using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Фарм
{
    public partial class аптеки : Form
    {
        public аптеки()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string connect;
            connect = "c:/Program Files/Microsoft SQL Server/MSSQL.1/MSSQL/DATA/Firma.mdf";*/
            SqlConnection connection1 = new SqlConnection(
                " data source=localhost; Initial Catalog=Firma; Integrated Security=SSPI;"
                );
            connection1.Open();
            DataSet dataSet1 = new DataSet();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            string zapros = "select * from apteka";
            int n = 0;
            if (checkBox1.Checked == true)
                n += 1;
            if (checkBox2.Checked == true)
                n += 3;
            if (checkBox3.Checked == true)
                n += 5;
            switch (n)
            {
                case 1:
                    zapros += "where c_name = '" + textBox1.Text + "'";
                    break;
                case 3:
                    zapros += "where c_inn = " + textBox2.Text;
                    break;
                case 5:
                    zapros += "where c_city = '" + textBox3.Text + "'";
                    break;
                case 4:
                    zapros += "where c_name = '" + textBox1.Text + "'" + "and c_city  = '" + textBox2.Text + "'";
                    break;
                case 6:
                    zapros += "where c_name = '" + textBox1.Text + "' and c_inn = " + textBox3.Text;
                    break;
                case 8:
                    zapros += "where c_inn = " + textBox3.Text + "and c_city = '" + textBox3.Text + "'";
                    break;
            }
            sqlDataAdapter1.SelectCommand =
new SqlCommand(zapros, connection1);
            try
            {
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                sqlDataAdapter1.Fill(table);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = table;
                connection1.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Интерфейс временно не исправен\n" + "советуем перезагрузить компьютер и зайти заново");

            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            аптеки.ActiveForm.Close();
        }
    }
}
