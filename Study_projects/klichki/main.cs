using System;
using System.Windows.Forms;
using System.IO;


class Group
{ public Birka[] Register = new Birka[4];
  
		
	public Group()
	{
		string p="reg.txt";
		StreamReader f;
		try {f=new StreamReader(p);}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);
			return;
		}
		string s,s1,s2;
		int j=0;
		while ((s=f.ReadLine())!=null)
		{
			if (s=="s")
			{
				s1=f.ReadLine();
				Register[j]=new Birka(s,int.Parse(s1));
			}
			else
			{
				s1=f.ReadLine();
				s2=f.ReadLine();

				Register[j]=new Old_Birka(s,int.Parse(s1),int.Parse(s2));
			}
				
		}

	
		
	}


}