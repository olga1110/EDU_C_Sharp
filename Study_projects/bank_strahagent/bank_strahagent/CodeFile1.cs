using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace bank
{
    class client
    {
        
        public string surname;
        public int year;
        public float[] vklad;

        public client( string surname, int year, int n)
        {
             this.surname = surname;
            this.year = year;
            this.vklad = new float[n];
        }

        

        public void info(int k)
        {
            Console.WriteLine(" surname " + surname + " year " + year);
            for (int i = 0; i < k; i++)
                Console.WriteLine(" vklad " + (i + 1) + " razmer " + vklad[i]);
        }

        public void otkril(float s, int p)
        {
            vklad[p] = s;
        }


        public void popolnil(float s, int p)
        {
            vklad[p - 1] += s;
        }
        public float kol(int p)
        {
            return vklad[p - 1];
        }
        public void procent(int y, int pr)
        {
            if ((y - year) % 5 == 0)
                vklad[0] *= 1 + (float)pr / 100;
        }
        public void udal(int p, int k)
        {
            for (int j = p - 1; j < k - 1; j++)
                vklad[j] = vklad[j + 1];
            vklad[k] = 0;
        }
        public void procent_v_god(int p)
        {
            for (int i = 0; i < p; i++)
                vklad[i] *= (float)1.09;
        }
        public float summa(int p)
        {
            float sum = 0;
            for (int i = 0; i < p; i++)
                sum += vklad[i];
            return sum;
        }
        public float kol(int n, int year) //n nomer vklada -  k 2008
        {
            int y = 2008 - year;
            float p = 1; 
            for (int i = 1; i <= y; i++)
                p = p * (float)1.09;
            float sum = (float)vklad[n - 1] * p;
            return sum - vklad[n - 1];
        }
        public float obwpr(int year)
        {
            float s = 0;
            for (int i = 1; i <= 3; i++)
                s += kol(i, year); 
            return s;
        }
        public string SurName
        {
            get
            { return surname; }
            set
            { surname = value; } 
        }
       
    }
}

