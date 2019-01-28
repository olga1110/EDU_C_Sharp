using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GBDD
{
    int[] nomer = new int[4]; //массив номеров машин
    float[] stoim = new float[4]; // массив стоимостей машин
    bool[] pr = new bool[4];// массив - пройден ли техосмотр для каждой машины
    string[] vlad = new string[4]; // масси владельцев машин
    public GBDD(int[] A, float[] B, bool[] C, string[] D)//конструктор
    {
        nomer = A;
        stoim = B;
        pr = C;
        vlad = D;
    }
    public void Info() // вывод информации
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(" car  № " + nomer[i] + " stoit " + stoim[i] + " vladelec " + vlad[i]);
            if (pr[i]) Console.WriteLine("                  prowla teh osmotr");
            else Console.WriteLine("                 ne prowla teh osmotr");
        }
    }
    public float Nalog(int a, int k) //налог на покупку
    {
        float n = 0;
        for (int i = 0; i < 4; i++)
            if (nomer[i] == a)
                n = stoim[i] * (float)k / 100;
        return n;
    }

    public bool Prowel(int a) // прошла ли техосмотр машина с определенным номером
    {
        bool b = false;
        for (int i = 0; i < 4; i++)
            if (nomer[i] == a)
                if (pr[i]) b = true;
        return b;
    }
    public void Proverim() //те, кто не прошли тех осмотр
    {
        Console.WriteLine(" ne prowli teh osmotr");
        for (int i = 0; i < 4; i++)
            if (!Prowel(nomer[i]))
                Console.WriteLine(vlad[i]);
    }
    public int Dor() //возвращает номер самой дорогой машины
    {
        float max = stoim[0];
        int h = nomer[0];
        for (int i = 1; i < 4; i++)
        {
            if (max < stoim[i])
            {
                max = stoim[i];
                h = nomer[i];
            }
        }
        return h;
    }

}

class work
{
    static void Main()
    {
        int[] a = { 123, 586, 459, 563 }; //массив номеров машин
        float[] b = { 25000, 35000, 45000, 37000 }; // массив стоимостей машин
        bool[] c = { true, true, true, false };// массив - пройден ли техосмотр для каждой машины
        string[] d = { "Иванов", "Кузнецов", "Сидоров", "Петров" };// масси владельцев машин
        GBDD baza = new GBDD(a, b, c, d);
        int k = 4;
        baza.Info();
        Console.WriteLine();
        Console.WriteLine("vvedite nomer");
        string nmb = Console.ReadLine();
        int f = int.Parse(nmb);
        Console.WriteLine("nalog " + baza.Nalog(f, k));

        Console.WriteLine();
        baza.Proverim();

        Console.WriteLine();
        Console.WriteLine("prowel li osmotr s samoy dorogoy mawinoy");
        if (baza.Prowel(baza.Dor())) Console.WriteLine("da");
        else Console.WriteLine("net");

        Console.WriteLine();

    }
}

