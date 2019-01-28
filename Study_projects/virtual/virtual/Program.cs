using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{   
    class Birka
    { protected string kli4ka;
      protected int nomber;

      public Birka (string kli4ka, int nomber)
       { this.kli4ka=kli4ka;
          this.nomber=nomber;
       }

      public virtual void info()
      {
          Console.WriteLine("kli4ka  " + kli4ka + "  nomber  " + nomber);
      }

      public string Name
      {
          get { return kli4ka; }
          set { kli4ka = value; }
      }
      public int Nomer
      {
          get { return nomber; }
          set { nomber = value; }
      }
      public virtual int check()
      {
          return 0;
      }
      
      
    }

    class Old_Birka: Birka
    {   int regist;

        public Old_Birka(string kli4ka, int nomber,int regist):
                                     base (kli4ka,nomber)
        {
            this.regist = regist;
         }
        public override void info()
        {
            Console.WriteLine("kli4ka  " + kli4ka + "  nomber  " + nomber);
            Console.WriteLine("  nomber registracii  " + regist);
        }
        public int N
        {
            get { return regist; }
            set {  regist= value; }
        }
        
        public override int check()
        {
            return regist;
        }
        

    }
    class Program
    {
        static void Main()
        {
            Birka[] Register = new Birka[4];
            StreamReader f;
            string s1,s2,s3;
            try { f = new StreamReader("reg.txt"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            int i=0;

            while ((s1 = f.ReadLine()) != null)
            {   s2 = f.ReadLine();
                s3 = f.ReadLine();
                if (s3 == "s")
                    Register[i] = new Birka(s1, int.Parse(s2));
                else Register[i] = new Old_Birka(s1, int.Parse(s2), int.Parse(s3));

                Register[i].info();
                i++;
            }
            string p = "Wurik";
            Console.WriteLine("soba4ka " +p);
            for (i = 0; i < 4; i++)
            {
                if (Register[i].Name == p)
                    Console.WriteLine(" nomer vladelca " + Register[i].Nomer);
            }

           
           
            Console.WriteLine("novie");
            
            StreamWriter outS;

            try { outS = new StreamWriter("zadanie.txt"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            outS.WriteLine("itak");

            for (i = 0; i < 4; i++)
            {
                if (Register[i].check()>0)
                {
                    Register[i].info();
                    outS.WriteLine("kli4ka  " + Register[i].Name + "  nomber  " + Register[i].Nomer);
                    outS.WriteLine("  nomber registracii  " + Register[i].check());
                }
            }

            outS.Close();

            int[] r1 = new int[5];

            for (i = 0; i < 4; i++)
                r1[i] = Register[i].Nomer;

            int j,s10;
            for (i = 0; i <= 3; i++)
                for (j = 3; j >= (i+1); j--)
                {
                    if (r1[j - 1] < r1[j])
                    {
                        s10 = r1[j - 1];
                        r1[j - 1] = r1[j];
                        r1[j] = s10;

                    }
                }
            Console.WriteLine("otsortirovanniy");
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    if (r1[i] == Register[j].Nomer)
                    {
                        Register[j].info();
                        Console.WriteLine(j);
                    }

       

        }
    }
}
