using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class заводы1 : Form
    {
        public заводы1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connect;
            connect = "c:/Program Files/Microsoft SQL Server/MSSQL.1/MSSQL/DATA/Firma.mdf";
            SqlConnection connection2 = new SqlConnection(
                @" data source=.\LH-Q07WRANS3M63\SQLEXPRESS; User Instance=true;Integrated Security=SSPI;AttachDBFilename="+connect
                );
            connection1.Open();
            DataSet dataSet2 = new DataSet();
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter();
            string zapros = "select * from zavod";
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
                    zapros += "where p_name = '" + textBox1.Text + "'";
                    break;
                case 3:
                    zapros += "where p_inn = " + textBox2.Text;
                    break;
                case 5:
                    zapros += "where p_proiz = '" + textBox3.Text + "'";
                    break;
                case 4:
                    zapros += "where p_name = '" + textBox1.Text + "'" + "and p_city  = '" + textBox2.Text + "'";
                    break;
                case 6:
                    zapros += "where p_name = '" + textBox1.Text + "' and p_inn = " + textBox3.Text;
                    break;
                case 8:
                    zapros += "where p_inn = " + textBox3.Text + "and p_proiz = '" + textBox3.Text + "'";
                    break;
            }
            sqlDataAdapter1.SelectCommand =
new SqlCommand(zapros, connection2);
            try
            {
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                sqlDataAdapter1.Fill(table);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = table;
                connection1.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Интерфейс временно не исправен\n" + "советуем перезагрузить компьютер и зайти заново");

            }
        }

        }
    }

