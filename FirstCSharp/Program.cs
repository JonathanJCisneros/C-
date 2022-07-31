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