using HungryNinja;

Buffet buffet = new Buffet();

Ninja ninja = new Ninja();

ninja.Eat(buffet.Serve());
ninja.Eat(buffet.Serve());
ninja.Eat(buffet.Serve());
ninja.Eat(buffet.Serve());
ninja.Eat(buffet.Serve());

Console.WriteLine("This Ninja will probably get diabetes...");