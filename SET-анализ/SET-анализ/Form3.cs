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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double np, nds, str, pen, im, ycn1, ycn2;
            double n1, n2, n3, n4, n5, t, l1, l2, l3, l4, l5, w1, w2, w3;

            double income, cost, price, seb, demand, cap, trud;
            double income_opt, cost_opt, price_opt, seb_opt, demand_opt, cap_opt, trud_opt;
            double income_pes, cost_pes, price_pes, seb_pes, demand_pes, cap_pes, trud_pes;

            double prib, prib_yd, R_yd, cost_yd,cap_yd, trud_yd;
            double prib_opt, prib_yd_opt, R_yd_opt, cost_yd_opt, cap_yd_opt, trud_yd_opt;
            double prib_pes, prib_yd_pes, R_yd_pes, cost_yd_pes, cap_yd_pes, trud_yd_pes;

            double a, a_pr1, a_pr2, b1, b2, y, B1, B2;
            double a_opt, a_pr1_opt, a_pr2_opt, b1_opt, b2_opt, y_opt, B1_opt, B2_opt;
            double a_pes, a_pr1_pes, a_pr2_pes, b1_pes, b2_pes, y_pes, B1_pes, B2_pes;
                                 

            np = double.Parse(textBox1.Text);
            nds = double.Parse(textBox2.Text);
            str = double.Parse(textBox3.Text);
            pen = double.Parse(textBox4.Text);
            im = double.Parse(textBox5.Text);
            ycn1 = double.Parse(textBox6.Text);
            ycn2 = double.Parse(textBox7.Text);

            n1 = (1 - np/100) * nds/100 / (1 + nds/100) / ycn1/100;
            n2 = (1 - np/100) * im / ycn1;
            n3 = (1 - np/100) * str / ycn1;
            n4 = np / ycn1;
            n5 = str/100 * np/100;
            l1 = (1 - np/100) * nds/100 / (1 + nds/100);
            l2 = (1 - np/100) * im/100;
            l3 = (1 - ycn2/100) * pen/100;
            l4 = (1 - np/100) * str/100;
            l5 = (ycn2- np)/100;
            w1 = (1 - ycn2/100) * pen / ycn1;
            w2 = ycn2 / ycn1;
            w3 = ycn2/100 * pen / ycn1;

            // вероятностный сценарий //

           
            cap = double.Parse(textBox11.Text);
            trud = double.Parse(textBox20.Text);
           
            income = double.Parse(textBox23.Text);
            cost = double.Parse(textBox24.Text);  

            if (checkBox1.Checked == true)
            {
                price = double.Parse(textBox8.Text);
                seb = double.Parse(textBox9.Text);
                demand = double.Parse(textBox10.Text);
                income = price * demand;
                cost = seb * demand;          
                
            }



            
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
            { label1.Text = "схема 1"; }

            if (a > a_pr2 & ((R_yd > ycn1 / ycn2) | (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd < t & B1 > 1) | (R_yd >= 0.5 * ycn1 / ycn2 & R_yd <= ycn1 / ycn2 & trud_yd >= t & B2 > 0.5)))
            { label1.Text = "схема 2.1"; }

            if (y < l1 & (R_yd < 0.5 * ycn1 / ycn2))
            { label1.Text = "схема 2.2"; }

            // оптимистический сценарий//

            
            cap_opt = double.Parse(textBox15.Text);
            trud_opt = double.Parse(textBox21.Text);

            income_opt = double.Parse(textBox25.Text);
            cost_opt = double.Parse(textBox26.Text);

            if (checkBox1.Checked == true)
            {
                price_opt = double.Parse(textBox12.Text);
                seb_opt = double.Parse(textBox13.Text);
                demand_opt = double.Parse(textBox14.Text);
                income_opt = price_opt * demand_opt;
                cost_opt = seb_opt * demand_opt;

            }

                                                
            cost_yd_opt = cost_opt/ income_opt;
            cap_yd_opt = cap_opt / income_opt;
            trud_yd_opt = trud_opt/ income_opt;
            prib_opt = income_opt - cost_opt;
            prib_yd_opt = prib_opt/ income_opt;
            R_yd_opt = (prib_opt - trud_opt * str / 100) / income_opt;
            a_opt = -n1 * cost_yd_opt + n2 * cap_yd_opt - n3 * trud_yd_opt + n5 * prib_yd_opt;
            a_pr1_opt = 0.5 - n1;
            a_pr2_opt = 1 - n1;
            b1_opt = n1 * cost_yd_opt - n2 * cap_yd_opt - n3 * trud_yd_opt - n4 * prib_yd_opt;
            b2_opt = n1 * cost_yd_opt - n2 * cap_yd_opt + n5 * trud_yd_opt - n4 * prib_yd_opt;
            B1_opt = w1 * trud_yd_opt + w2 * prib_yd_opt;
            B2_opt = w2 * prib_yd_opt - w3 * trud_yd_opt;
            y_opt = (l3 - l4) * trud_yd_opt - l1 * (1 - cost_yd_opt) - l2 * cap_yd_opt + l5 * prib_yd_opt;

            if ((a_opt < a_pr1_opt | (a_opt >= a_pr2_opt & a_opt <= a_pr1_opt & trud_yd_opt < t & b1_opt > n1 - 1) | (a_opt >= a_pr2_opt & a_opt <= a_pr1_opt & trud_yd_opt >= t & b2_opt > n1 - 0.5)) & y_opt > l1)
            { label2.Text = "схема 1"; }

            if (a_opt > a_pr2_opt & ((R_yd_opt > ycn1 / ycn2) | (R_yd_opt >= 0.5 * ycn1 / ycn2 & R_yd_opt <= ycn1 / ycn2 & trud_yd_opt < t & B1_opt > 1) | (R_yd_opt >= 0.5 * ycn1 / ycn2 & R_yd_opt <= ycn1 / ycn2 & trud_yd_opt >= t & B2_opt > 0.5)))
            { label2.Text = "схема 2.1"; }

            if (y_opt < l1 & (R_yd_opt < 0.5 * ycn1 / ycn2))
            { label2.Text = "схема 2.2"; }
           
           

            // пессимистический сценарий //

            
            
            cap_pes = double.Parse(textBox19.Text);
            trud_pes = double.Parse(textBox22.Text);

            income_pes = double.Parse(textBox27.Text);
            cost_pes = double.Parse(textBox28.Text);

            if (checkBox1.Checked == true)
            {
                price_pes = double.Parse(textBox16.Text);
                seb_pes = double.Parse(textBox17.Text);
                demand_pes = double.Parse(textBox18.Text);
                income_pes = price_pes * demand_pes;
                cost_pes = seb_pes * demand_pes;
            }

            cost_yd_pes = cost_pes / income_pes;
            cap_yd_pes = cap_pes / income_pes;
            trud_yd_pes = trud_pes / income_pes;
            prib_pes = income_pes - cost_pes;
            prib_yd_pes = prib_pes / income_pes;
            R_yd_pes = (prib_pes - trud_pes * str / 100) / income_pes;
            a_pes = -n1 * cost_yd_pes + n2 * cap_yd_pes - n3 * trud_yd_pes + n5 * prib_yd_pes;
            a_pr1_pes = 0.5 - n1;
            a_pr2_pes = 1 - n1;
            b1_pes = n1 * cost_yd_pes - n2 * cap_yd_pes - n3 * trud_yd_pes - n4 * prib_yd_pes;
            b2_pes = n1 * cost_yd_pes - n2 * cap_yd_pes + n5 * trud_yd_pes - n4 * prib_yd_pes;
            B1_pes = w1 * trud_yd_pes + w2 * prib_yd_pes;
            B2_pes = w2 * prib_yd_pes - w3 * trud_yd_pes;
            y_pes = (l3 - l4) * trud_yd_pes - l1 * (1 - cost_yd_pes) - l2 * cap_yd_pes + l5 * prib_yd_pes;


            if ((a_pes < a_pr1_pes | (a_pes >= a_pr2_pes & a_pes <= a_pr1_pes & trud_yd_pes < t & b1_pes > n1 - 1) | (a_pes >= a_pr2_pes & a_pes <= a_pr1_pes & trud_yd_pes >= t & b2_pes > n1 - 0.5)) & y_pes > l1)
            { label3.Text = "схема 1"; }

            if (a_pes > a_pr2_pes & ((R_yd_pes > ycn1 / ycn2) | (R_yd_pes >= 0.5 * ycn1 / ycn2 & R_yd_pes <= ycn1 / ycn2 & trud_yd_pes < t & B1_pes > 1) | (R_yd_pes >= 0.5 * ycn1 / ycn2 & R_yd_pes <= ycn1 / ycn2 & trud_yd_pes >= t & B2_pes > 0.5)))
            { label3.Text = "схема 2.1"; }

            if (y_pes < l1 & (R_yd_pes < 0.5 * ycn1 / ycn2))
            { label3.Text = "схема 2.2"; }

        }

        

       
    }
}
