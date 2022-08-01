// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void FizzBuzz(){
    for(int i = 1; i <= 100; i++){
        if(i % 3 == 0){
            Console.WriteLine("Fizz");
        }
        else if(i % 5 == 0){
            Console.WriteLine("Buzz");
        }
    }
}

FizzBuzz();

void FizzBuzz1(){
    for(int i = 1; i <= 100; i++){
        if(i % 3 == 0 && i % 5 == 0){
            Console.WriteLine("FizzBuzz");
        }
        else if(i % 3 == 0){
            Console.WriteLine("Fizz");
        }
        else if(i % 5 == 0){
            Console.WriteLine("Buzz");
        }
        else{
            Console.WriteLine(i);
        }
    }
}

FizzBuzz1();

void FizzBuzzCustom(int range = 100){
    for(int i = 1; i <= range; i++){
        if(i % 3 == 0 && i % 5 == 0){
            Console.WriteLine("FizzBuzz");
        }
        else if(i % 3 == 0){
            Console.WriteLine("Fizz");
        }
        else if(i % 5 == 0){
            Console.WriteLine("Buzz");
        }
        else{
            Console.WriteLine(i);
        }
    }
}

FizzBuzzCustom(1050);

Console.WriteLine("I don't know what I am doing ikjsdbglabsfg");

// int myNum = 15;
// string someString = "hello";

List<string> flavors = new List<string>(){
    "cherry garcia",
    "mint chocolate chip",
    "chocolate",
    "chocolate chip",
    "lobster"
};

flavors.Add("caramel");
flavors.RemoveAt(4);
flavors.Insert(2, "Oreo");

Console.WriteLine(flavors.Count);

foreach(string flavor in flavors){
    Console.WriteLine(flavor);
}

Console.WriteLine(flavors[flavors.Count -1]);

List<int> orderedNums = new List<int>(){1,2,3,4,5,6,7,8,9,10};

List<int> shuffledList = new List<int>();

Random rand = new Random();

Console.WriteLine(rand.Next(0, 15));

while(orderedNums.Count > 0){
    int randIdx = rand.Next(0, orderedNums.Count);
    Console.WriteLine($"Removing {orderedNums[randIdx]} from ordered nums");
    shuffledList.Add(orderedNums[randIdx]);
    Console.WriteLine($"Adding {orderedNums[randIdx]} to shuffled list");
    orderedNums.RemoveAt(randIdx);
}

Console.WriteLine($"Remaining int in ordered nums: {orderedNums.Count}");
Console.WriteLine($"New numbers in shuffled list: {shuffledList.Count}");

foreach(int num in shuffledList){
    Console.WriteLine(num);
}


Dictionary<int, string> someDictionary = new Dictionary<int, string>(){
    {1, "Jonathan"}
};

Console.WriteLine(someDictionary[1]);

