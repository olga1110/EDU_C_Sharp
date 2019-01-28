using System;

class Birka
{
	protected string kli4ka;
	protected int nomber;
	

	public Birka (string kli4ka, int nomber)
	{
		this.kli4ka=kli4ka;
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
	public  virtual int N
	{ 
		get { return 0; }
	
	
		
	}
	public virtual int check()
	{
		return 0;
	}
      
      
}
