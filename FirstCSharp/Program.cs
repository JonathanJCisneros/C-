// See https://aka.ms/new-console-template for more information

string place = "Coding Dojo";

string message = $"Hello {place}";

Console.WriteLine("Hello, World!");

Console.WriteLine("Using Console.WriteLine, you can output any string to the terminal/console");

Console.WriteLine("Hello from the other side :-) " + place);

Console.WriteLine($"Hello World from {place}");

Console.WriteLine(message);

string name = "Todd";
int age = 32;
double height = 1.875;
bool blueEyed = true;

Console.WriteLine($"Hi my name is {name}, I am {age} years old. I am {height} tall. {blueEyed}");

int numRings = 3;
if(numRings >= 5){
    Console.WriteLine("You are welcome to join the party");
}
else if(numRings > 2 && numRings < 5){
    Console.WriteLine($"Decent...but {numRings} rings aren't enough");
}
else{
    Console.WriteLine("Go win some more rings");
}

int numRings1 = 5;
int numOfAllStarAppearances = 17;
if (numRings1 >= 5 || numOfAllStarAppearances > 3){
    Console.WriteLine("Welcome, you are truly a legend");
}
else{
    Console.WriteLine("Get back in the game");
}

bool crazy = false;
if (!crazy){
    Console.WriteLine("Let's party!");
}

for(int i = 1; i <=5; i++){
    Console.WriteLine(i);
}

int start = 0;
int end = 12;

for(int i = start; i < end; i ++){
    Console.WriteLine(i);
}

int j = 1;
while(j < 6){
    Console.WriteLine(j);
    j++;
}

Random rand = new Random();

for(int val = 0; val < 10; val++){
    Console.WriteLine(rand.Next(2,8));
}

int[] arrayOfInts = {1, 2, 3, 4, 5};
Console.WriteLine(arrayOfInts[0]);    // The first number lives at index 0.
Console.WriteLine(arrayOfInts[1]);    // The second number lives at index 1.
Console.WriteLine(arrayOfInts[2]);    // The third number lives at index 2.
Console.WriteLine(arrayOfInts[3]);    // The fourth number lives at index 3.
Console.WriteLine(arrayOfInts[4]);    // The fifth and final number lives at index 4.

int[] arr = {1, 2, 3, 4};
Console.WriteLine($"The first number of the arr is {arr[0]}"); 
arr[0] = 8;
Console.WriteLine($"The first number of the arr is now {arr[0]}");


string[] myCars = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"}; 
foreach (string car in myCars){
    Console.WriteLine($"I own a {car}");
}

List<string> cars = new List<string>();

cars.Add("Mazda");
cars.Add("BMW");
cars.Add("Dodge");

Console.WriteLine(cars[1]);

Console.WriteLine($"We currently know of {cars.Count} car manufacturers");

Console.WriteLine("The current car manufacturers we have seen are:");

foreach(string car in cars){
    Console.WriteLine("-" + car);
}

cars.Remove("Dodge");
Console.WriteLine("We removed Dodge because no one likes them so: ");

Console.WriteLine("New List: ");
foreach (string car in cars){
    Console.WriteLine("-" + car);
}


