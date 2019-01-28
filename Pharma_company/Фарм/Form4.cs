using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace Фарм
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aptekaTableAdapter Tableadapter1 = new БанкиTableAdapter();
            TableAdapterManager Manager1 = new TableAdapterManager();
            Tableadapter1.Insert(textBox1.Text, textBox3.Text, int.Parse(textBox2.Text));
            try
            {
                MessageBox.Show("Банк успешно добавлен");
            }
            catch (SqlException)
            {
                MessageBox.Show("Не удалось сделать заполнение");
            }
            Manager1.UpdateAll(this.Dataset1);
            Manager1.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form4.ActiveForm.Close();
        }
    }
}
