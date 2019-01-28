using System;
using System.IO;
using System.Windows.Forms;

namespace student1
{
		public class GruppaStudentov
	{
	
		public Stydent[] St = new Stydent[5];
		string[] A = new string[5];
		int[] B = new int[5];

		public void ReadFromFile(string p)
		{
				StreamReader f;
			try {f=new StreamReader(p);}
			catch (Exception e)
			{
					MessageBox.Show(e.Message);
				return;
			}
			string s;
			int j=0;
			while ((s=f.ReadLine())!=null)
			{
					A[j]=s;
				s=f.ReadLine();
				B[j]=int.Parse(s);
				j++;
			}

		}


		public GruppaStudentov()
		{
				string path="St.txt";
			ReadFromFile(path);
			for (int i = 0; i < 5; i++)
			{
					St[i] = new Stydent(A[i], B[i]);
			}
		}
		public int Max()
		{
			int[] r1 = new int[5];
			for (int i = 0; i < 5; i++)
			{
					r1[i] = St[i].Ball;
			}

			int max=r1[0];
			int l = 0;
			for (int i = 1; i < 5; i++)
				if (max < r1[i])
				{
						max = r1[i];
					l = i;
				}

			return l;

		}
		

	}
}
