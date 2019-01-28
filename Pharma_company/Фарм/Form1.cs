using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Фарм
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void аптекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            аптеки fr2 = new аптеки();
            fr2.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа обеспечивает интерфейс работы с БД \n" + "предназначена для фармацевтических фирм");
        }

        private void заводыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            заводы1 fr3 = new заводы1();
            fr3.Show();
        }

        private void аптекиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.Show();
        }

        
    }
}
