using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Фарм
{
    public partial class Удаление : Form
    {
        public Удаление()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            installconnection installconnection1 = new installconnection();
            TableAdapterManager Manager7 = new TableAdapterManager();
            string dbLocation2 = Path.GetFullPath(installconnection1.connection);
            SqlConnection connection3 = new SqlConnection
                 (
                     installconnection1.connection1 + @dbLocation2
                 );
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete ";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    cmd.CommandText += "from apteka where id_cl = " + textBox1.Text;
                    break;
                case 1:
                    cmd.CommandText += "from zavod where id_post = " + textBox1.Text;
                    break;
                case 2:
                    cmd.CommandText += "from postavka where id_part = " + textBox1.Text;
                    break;
                case 3:
                    cmd.CommandText += "from prodaza where id_otgr = " + textBox1.Text;
                    break;
                
            }
            cmd.Connection = connection3;
            connection3.Open();
            label2.Text = cmd.CommandText;
            cmd.ExecuteNonQuery();
            connection3.Close();
            try
            {
                MessageBox.Show("Запись удалена");
            }
            catch (SqlException)
            {
                MessageBox.Show("Не удалось удалить запись");
            }
        }
    }
}
