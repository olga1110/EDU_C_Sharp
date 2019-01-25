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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double np, nds, str, pen, im, ycn1, ycn2;
            double n1, n2, n3, n4, n5, t, l1, l2, l3, l4, l5, w1, w2, w3;
            double income, cost, cost_yd, cap, cap_yd, trud, trud_yd, prib, prib_yd, R_yd;
            int income_min, income_max, cost_min, cost_max, cap_min, cap_max, trud_min, trud_max;
            double a, a_pr1, a_pr2, b1, b2, y, B1, B2;
            int m, n, o, i, amount;
            m = 0;
            n = 0;
            o = 0;
            amount = int.Parse(textBox20.Text);
            np = double.Parse(textBox1.Text);
            nds = double.Parse(textBox2.Text);
            str = double.Parse(textBox3.Text);
            pen = double.Parse(textBox4.Text);
            im = double.Parse(textBox5.Text);
            ycn1 = double.Parse(textBox6.Text);
            ycn2 = double.Parse(textBox7.Text);

            n1 = (1 - np / 100) * nds / 100 / (1 + nds / 100) / ycn1 / 100;
            n2 = (1 - np / 100) * im / ycn1;
            n3 = (1 - np / 100) * str / ycn1;
            n4 = np / ycn1;
            n5 = str / 100 * np / 100;
            l1 = (1 - np / 100) * nds / 100 / (1 + nds / 100);
            l2 = (1 - np / 100) * im / 100;
            l3 = (1 - ycn2 / 100) * pen / 100;
            l4 = (1 - np / 100) * str / 100;
            l5 = (ycn2 - np) / 100;
            w1 = (1 - ycn2 / 100) * pen / ycn1;
            w2 = ycn2 / ycn1;
            w3 = ycn2 / 100 * pen / ycn1;

            income = double.Parse(textBox8.Text);
            cost = double.Parse(textBox9.Text);
            cap = double.Parse(textBox10.Text);
            trud = double.Parse(textBox11.Text);

            income_min = int.Parse(textBox12.Text);
            cost_min = int.Parse(textBox13.Text);
            cap_min = int.Parse(textBox14.Text);
            trud_min = int.Parse(textBox15.Text);

            income_max = int.Parse(textBox16.Text);
            cost_max = int.Parse(textBox17.Text);
            cap_max = int.Parse(textBox18.Text);
            trud_max = int.Parse(textBox19.Text);



            for (i = 1; i < amount + 1; i++)
            {
                Random ran = new Random();
                income = ran.Next(income_min, income_max);
                cost = ran.Next(cost_min, cost_max);
                cap = ran.Next(cap_min, cap_max);
                trud = ran.Next(trud_min, trud_max);

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


                if ((a < a_pr1 | (a >= a_pr2 & a <= a_pr1 & trud_yd < t & b1 > n1 - 1) | (a >= a_pr2 & a <= a_pr1 & trud_yd >= t & b2 > n1 - 0.5)) & y > l1)
                { m = m + 1; }

                if (a > a_pr2 & ((R_yd > ycn1 / ycn2) | (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd < t & B1 > 1) | (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd >= t & B2 > 0.5)))
                { n = n + 1; }

                if (y < l1 & (R_yd < 0.5 * ycn1 / ycn2))
                { o = o + 1; }

            }
            label15.Text = "" + m;
            label16.Text = "" + n;
            label17.Text = "" + o;
        }
    }
}
