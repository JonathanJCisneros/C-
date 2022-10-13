using CSharpOOP;


// Human


Human Kevin = new Human("Kevin");
Human James = new Human("James");
Human Roger = new Human("Roger", 5, 5, 5, 250);

Console.WriteLine(Kevin.Status());

Console.WriteLine(Roger.Status());

Console.WriteLine(Kevin.Attack(Roger));
Console.WriteLine(Kevin.Attack(Roger));
Console.WriteLine(Kevin.Attack(Roger));
Console.WriteLine(Roger.Attack(Kevin));
Console.WriteLine(Roger.Attack(Kevin));
Console.WriteLine(Roger.Attack(Kevin));


Console.WriteLine(Kevin.Status());

Console.WriteLine(Roger.Status());



// Hungry Ninja


Buffet buffet = new Buffet();
Food quesadilla = new Food("Quesadilla", 600, true, false);

Console.WriteLine(buffet.AddToMenu(quesadilla));

Ninja Sam = new Ninja();

Sam.stats();

Sam.Eat(buffet.Serve());
Sam.stats();
Console.WriteLine("--------------------");
Sam.Eat(buffet.Serve());
Sam.stats();
Console.WriteLine("--------------------");
Sam.Eat(buffet.Serve());
Sam.stats();
Console.WriteLine("--------------------");
Sam.Eat(buffet.Serve());
Sam.stats();