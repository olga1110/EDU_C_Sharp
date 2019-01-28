using System;

class Student
{
	public string name;
	public int reiting;

	public Student(string name,int reiting)
	{
		this.name=name;
		this.reiting=reiting;

	}
	public int rt
	{get{return reiting;}}
}
class Gruppa
{   
	public Student[]studenti=new Student[3];
	public Gruppa()
	{    
		string[]name={"Ivanov", "Petrov", "Sidorov"};
		int[]reiting={30,47,55};
	
	
		for(int i=0;i<3;i++)
			studenti[i]=new Student(name[i],reiting[i]);
	}
	}


