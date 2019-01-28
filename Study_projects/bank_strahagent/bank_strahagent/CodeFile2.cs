using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agent
{
    class client
    {
        string name;
        string v; // vid strahovki
        int r; // razmer strahovki
        public client(string name, string v, int r)
        {
            this.name = name;
            this.v = v;
            this.r = r;
         }
        public void info()
        {
            Console.WriteLine("imya "+ name+ " vid strahovki "+v+ "  razmer strahovki "+r);
        }
        public bool check()
        {
            bool b = false;
            if ((v == "Avto") && (r > 2000))
                b = true;
            return b;
        }

        public string Name
        {get
            { return name;}
            set
            { name = value; }
         }
        public bool check2()
        {
            bool b = false;
            if ((v == "Kvartira") && (r > 3000))
                b = true;
            return b;
        }
        
    }

}