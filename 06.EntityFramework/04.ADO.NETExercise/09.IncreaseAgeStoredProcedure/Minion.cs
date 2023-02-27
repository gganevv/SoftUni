namespace _08.IncreaseMinionAge;

public class Minion
{
	private int age;
	private string name;

    public Minion(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
	{
		get { return name; }
		set { name = value; }
	}


	public int Age
	{
		get { return age; }
		set { age = value; }
	}

    public override string ToString()
    {
        return $"{Name} - {Age} years old";
    }
}