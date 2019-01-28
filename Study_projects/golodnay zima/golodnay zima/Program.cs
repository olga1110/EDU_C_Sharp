using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Program
{
    static void Main()
    {
        float s = 150;
        float t = 150;
        float f = 150;
        float u = 1;
        float v = (float)1.5;
        float w = 2;
        int q = 5;
        int r = 3;
        int l = 2;
        int p = 2;
        int k = 25; 
        int i = 0;
        while (s > 0 && t > 0 && f > 0)
        {
            i++;
            s = s * (1 - q / 100) - k * (1 - p / 100) * u;
            t = t * (1 - r / 100) - k * (1 - p / 100) * v;
            f = f * (1 - l / 100) - k * (1 - p / 100) * w;

        }

        if (s <= 0)
            Console.WriteLine("zakon4ilos seno");
        if (t <= 0)
            Console.WriteLine("zakon4ils@ silos");
        if (f <= 0)
            Console.WriteLine("zakon4ils@ kombikorn");
        if (s == 0 || t == 0 || f == 0)
            Console.WriteLine("zakon4itsya norm pitanie 4erez " + i + " dney");
        if (s < 0 || t < 0 || f < 0)
            Console.WriteLine("zakon4itsya norm pitanie 4erez " + (i - 1) + " dney");



    }
}

