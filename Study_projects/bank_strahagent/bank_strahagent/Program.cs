using System;

   class Program
    {   
        static void Main()
       {
           int j;
           string[] n = {"Ivanov","Kulikov","Ponosov", "Petrenko", "Kulik" };
           string[] vk = { "Kvartira", "Kvartira", "Avto", "Kvartira", "Avto" };
           int[] razmer = {1000,3256,125800,20365,1548};

           agent.client[] A = new agent.client[5];
           for (j = 0; j < 5; j++)
           { A[j] = new agent.client(n[j],vk[j],razmer[j]);
             A[j].info();
           }
           for (j = 0; j < 5; j++)
           {
               if (A[j].check())
                   Console.WriteLine("zastrahoval avto "+ A[j].Name);
           }

           string[] N = { "Petrenko", "Popova", "Kulik" };
           int[] god = {  2002, 2003, 2004 };
           int[] vkladi = { 3, 3, 3};

            int i;

           bank.client[] B = new bank.client[3];
           for (j = 0; j < 3; j++)
           {
               B[j] = new bank.client(N[j], god[j], vkladi[j]);
               for (i = 0; i < vkladi[j]; i++)
                   B[j].otkril(1000, i);
               B[j].info(vkladi[j]);
               
           }
           float min = B[0].obwpr(god[0]);
            int l=0;
           for (j = 0; j < 3; j++)
           {
               if (min > B[j].obwpr(god[j]))
               {  min = B[j].obwpr(god[j]);
                 l = j;
                 }
            }

           Console.WriteLine(")))" + B[l].SurName);
            int k=0;
           for (j = 0; j < 5; j++)
           {
               if (A[j].check2())
                   for (k = 0; k < 3; k++)
                       if (A[j].Name == B[k].SurName)
                           Console.WriteLine("imya "+A[j].Name);
           }


       }
    }

