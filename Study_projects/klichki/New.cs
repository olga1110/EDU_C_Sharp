using System;

class Old_Birka: Birka
{
	int regist; //nomer otdela registracii

	public Old_Birka(string kli4ka, int nomber,int regist):
		base (kli4ka,nomber)
	{
		this.regist = regist;
	}
	
	public override int N
	{
		get { return 0; }
		
	}
        
	public override int check()
	{
		return regist;
	}
        

}
