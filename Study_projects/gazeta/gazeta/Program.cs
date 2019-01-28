using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Gazeta
{
    string name;
    int t;//тираж
    int p;// количество полос
    static int l=0;
    static int r = 0;
    string[] a = new string[3];// имена журналистов
    float[] z = new float[3];// зарплата журналистов
    public Gazeta(string name, int t, int p, string[] a, float[] z)// Конструктор
    {
        this.name = name;
        this.t = t;
        this.p = p;
        for (int i = 0; i < 3; i++)
        {
            this.a[i] = a[i];
            this.z[i] = z[i];
        }
        l++;
    }
    public Gazeta()
    {
        l++;

    }
    public static int Getnum()
    {
        return l;
    }
    public static int Getr()
    {
        return r;
    }

    public float svvo // svoistvo!!!!
    { get
        { r++; return z[r]; }
      set
         { if (value>=0) z[r+1]= value;
         Console.WriteLine(z[r+1] + "  / " + (r+1));
          }

    }

    
     public void Info() // вывод информации о газете
    {
        Console.WriteLine("name " + name + " tirazh " + t + " koli4estvo polos " + p);
        Console.WriteLine("zhurnalisti/zarplata");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(a[i] + " - " + z[i]);
        }
    }
    public float SZarplat() // сумма всех зарплат
    {
        float s = z[0];
        for (int i = 1; i < 3; i++)
        {
            s += z[i];
        }
        return s;

    }
    public float srednee() // значение средней зарплаты
    {
        return SZarplat() / 3;
    }
    public bool mal(int i) //зарплата у заданного журналиста меньше средней?
    {
        bool d = false;
        if (z[i] < srednee())
            d = true;
        return d;
    }
    public void Mal() // найти всех журналистов с зарплатой меньше средней
    {
        Console.WriteLine(" zhurnalisti s malenkoy zarplatoy");
        for (int i = 0; i < 3; i++)
            if (mal(i))
                Console.WriteLine(a[i]);
    }
    public void Uvel(int K) //увеличиваем зарплату всем с маленькой - т.е. меньше средней
    {
        Console.WriteLine("Uveli4ili");
        for (int i = 0; i < 3; i++)
            if (mal(i))
            {
                z[i] = z[i] * (1 + (float)K / 100);
                Console.WriteLine(a[i] + " s zarplatoy " + z[i]);
            }

    }
    public void Umen(int K) //уменшить зарплату всем с большой
    {
        Console.WriteLine("Uvmenwili");
        for (int i = 0; i < 3; i++)
            if (!mal(i))
            {
                z[i] = z[i] * (1 - (float)K / 100);
                Console.WriteLine(a[i] + " s zarplatoy " + z[i]);
            }

    }
    public void Who(float F, ref int f)//с определенной зарплатой журналист
    {
        f = 0;
        for (int i = 0; i < 3; i++)
            if (z[i] == F)
            {
                Console.WriteLine(" u " + a[i] + " zarplata " + F);
                f++;
            }
        if (f == 0) Console.WriteLine(" niukogo net");
    }

    public void Obmen(out float zarp1, out float zarp2)
    {   float temp = 0;
    temp = this.z[1];
    this.z[1] = this.z[2];
    this.z[2] = temp;
    zarp1 = this.z[1];
    zarp2 = this.z[2];
        }


}

class work
{
    static void Main()
    {
        string[] A = { "Popov", "Ivanov", "Kulikov" };
        float[] B = { 1200, 3500, 12000 };
        Gazeta My = new Gazeta("WOR", 146, 6, A, B);
        Gazeta His = new Gazeta();
        My.Info();
        /*Console.WriteLine();
        Console.WriteLine("summa zarplay  " + My.SZarplat());
        Console.WriteLine();
        Console.WriteLine("sredn@@ zarplata " + My.srednee());
        My.Mal();
        Console.WriteLine();
        int k1 = 50;
        My.Uvel(k1);
        Console.WriteLine();
        int k2 = 25;
        My.Umen(k2);
        Console.WriteLine();*/


        Console.WriteLine("vvedite opr. zarplatu");
        string chislo = Console.ReadLine();
        float k3 = float.Parse(chislo);
        int l=0;
        My.Who(k3,ref l);
        Console.WriteLine("s opredelennoy zarplatoy " +l);
        Console.WriteLine();
        My.Info();
        Console.WriteLine("koli4estvo gazet "+Gazeta.Getnum());
        My.svvo=15000;
        Console.WriteLine("u "+(Gazeta.Getr()+1)+" "+  My.svvo);
        My.svvo = 12500;
        Console.WriteLine("u "+(Gazeta.Getr()+1)+"  " + My.svvo);
        float w, r ;
        Console.WriteLine();
        My.Obmen(out w, out r);
        Console.WriteLine(w+" "+r);
         My.Info();
    }
}
