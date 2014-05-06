using System;

abstract class aeroplane
{
	public abstract string type { get; }
}

abstract class aeroplaneFactory
{
	public abstract aeroplane getAeroplane();
}

class aeroplaneProductMustangP51: aeroplane
{
	string _type = "Mustang";
	
	public override string type
	{
		get { return _type; }
	}
}

class aeroplaneProductFokerWulf190: aeroplane
{
	string _type = "Foker-Wulf";
	
	public override string type
	{
		get { return _type; }
	}
}

class concreteNorthAmericaFactory: aeroplaneFactory
{
	public override aeroplane getAeroplane()
	{
		return new aeroplaneProductMustangP51();
	}
}

class concreteEuropeFactory: aeroplaneFactory
{
	public override aeroplane getAeroplane()
	{
		return new aeroplaneProductFokerWulf190();
	}
}
	
class testpilot
{
	public void askformodel(aeroplaneFactory factory)
	{
		aeroplane aircraft = factory.getAeroplane();
		Console.WriteLine("Planemodel {0}", aircraft.type);
	}
}

class MainClass
{
	static void Main(string[] args)
	{
		aeroplaneFactory factory = null;
		if (args.Length > 0 && args[0] == "P51")
			factory = new concreteNorthAmericaFactory();
		else if (args.Length > 0 && args[0] == "FW190")
			factory = new concreteEuropeFactory();
		new testpilot().askformodel(factory);
	}
}