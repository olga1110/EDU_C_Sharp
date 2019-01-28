using System;

namespace student1
{
		public class Stydent

	
	{
		protected string name;
		protected int bal;

		public Stydent(string name, int bal)
		{
			this.name=name;
			this.bal = bal;

		}
		
		public string Name
		{
				get 
			{return name;}
			set
			{name=value;}
		}
		public int Ball
		{
			get
			{ return bal; }
			set
			{ bal = value; }
		}
       
		

	}
}
