using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace сценарные_расчеты
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double np, nds, str, pen, im, ycn1, ycn2;
            double n1, n2, n3, n4, n5, t, l1, l2, l3, l4, l5, w1, w2, w3;
            double income, cost, cost_yd, cap, cap_yd, trud, trud_yd;
            double prib, prib_yd, R_yd;
            double a, a_pr1, a_pr2, b1, b2, y, B1, B2;

            np = double.Parse(textBox1.Text);
            nds = double.Parse(textBox2.Text);
            str = double.Parse(textBox3.Text);
            pen = double.Parse(textBox4.Text);
            im = double.Parse(textBox5.Text);
            ycn1 = double.Parse(textBox6.Text);
            ycn2 = double.Parse(textBox7.Text);


            n1 = (1 - np) * nds / (1 + nds) / ycn1;
            n2 = (1 - np) * im / ycn1;
            n3 = (1 - np) * str / ycn1;
            n4 = np / ycn1;
            n5 = str * np;
            l1 = (1 - np) * nds / (1 + nds);
            l2 = (1 - np) * im;
            l3 = (1 - ycn2) * pen;
            l4 = (1 - np) * str;
            l5 = ycn2 - np;
            w1 = (1 - ycn2) * pen / ycn1;
            w2 = ycn2 / ycn1;
            w3 = ycn2 * pen / ycn1;

            income = double.Parse(textBox8.Text);
            cost = double.Parse(textBox9.Text);
            cap = double.Parse(textBox10.Text);
            trud = double.Parse(textBox11.Text);



            cost_yd = cost / income;
            cap_yd = cap / income;
            trud_yd = trud / income;
            prib = income - cost;
            prib_yd = prib / income;
            R_yd = (prib - trud * str / 100) / income;
            a = -n1 * cost_yd + n2 * cap_yd - n3 * trud_yd + n5 * prib_yd;
            a_pr1 = 0.5 - n1;
            a_pr2 = 1 - n1;
            b1 = n1 * cost_yd - n2 * cap_yd - n3 * trud_yd - n4 * prib_yd;
            b2 = n1 * cost_yd - n2 * cap_yd + n5 * trud_yd - n4 * prib_yd;
            B1 = w1 * trud_yd + w2 * prib_yd;
            B2 = w2 * prib_yd - w3 * trud_yd;
            y = (l3 - l4) * trud_yd - l1 * (1 - cost_yd) - l2 * cap_yd + l5 * prib_yd;
            t = 0.5 * ycn1 / str;

            if (a < a_pr1) { label12.Text = "схема 1 предпочтительнее схемы 2.1"; }
            if (a > a_pr2) { label12.Text = "схема 2.1 предпочтительнее схемы 1"; }

            if (a >= a_pr1 & a <= a_pr2 & trud_yd < t & b1 > n1 - 1)
            { label12.Text = "схема 1 предпочтительнее схемы 2.1"; }
            if (a >= a_pr1 & a <= a_pr2 & trud_yd >= t & b2 > n1 - 0.5)
            { label12.Text = "схема 1 предпочтительнее схемы 2.1"; }


            if (y > l1)
            { label13.Text = "схема 1 предпочтительнее схемы 2.2"; }
            else { label13.Text = "схема 2.2 предпочтительнее схемы 1"; }

            if (R_yd < 0.5 * ycn1 / ycn2)
            { label14.Text = "схема 2.2 предпочтительнее схемы 2.1"; }
            if (R_yd > ycn1 / ycn2)
            { label14.Text = "схема 2.1 предпочтительнее схемы 2.2"; }

            if (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd < t & B1 > 1)
            { label14.Text = "схема 2.1 предпочтительнее схемы 2.2"; }
            if (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd >= t & B2 > 0.5)
            { label14.Text = "схема 2.1 предпочтительнее схемы 2.2"; }

            if ((a < a_pr1 | (a >= a_pr2 & a <= a_pr1 & trud_yd < t & b1 > n1 - 1) | (a >= a_pr2 & a <= a_pr1 & trud_yd >= t & b2 > n1 - 0.5)) & y > l1)
            { label16.Text = "Таким образом, с позиции минимизации налоговых отчислений рекоммендуется выбрать схему 1 ";
            label17.Text = "в силу ресурсоемкости (материалоемкости) данного предприятия";
            }

            if (a > a_pr2 & ((R_yd > ycn1 / ycn2) | (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd < t & B1 > 1) | (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd >= t & B2 > 0.5)))
            { label16.Text = "Таким образом, с позиции минимизации налоговых отчислений рекоммендуется выбрать схему 2.1 ";
            label17.Text = "в силу высокой рентабельности оборота (отношенния прибыли к выручке от продаж) данного предприятия";
            }

            if (y < l1 & (R_yd < 0.5 * ycn1 / ycn2))
            { label16.Text = "Таким образом, с позиции минимизации налоговых отчислений рекоммендуется выбрать схему 2.2 ";
              label17.Text = "в силу низкой рентабельности оборота (отношенния прибыли к выручке от продаж) данного предприятия";
            }

        }

        

      

      

    }
}
