// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int[] basic1 = {0,1,2,3,4,5,6,7,8,9};

foreach(int num in basic1){
    Console.WriteLine(num);
}

string[] basic2 = {"Tim", "Martin", "Nikki", "Sara"};

foreach(string name in basic2){
    Console.WriteLine(name);
}

bool[] basic3 = new bool[10];

for(int i = 0; i < basic3.Length; i++){
    if(i % 2 == 0){
        basic3[i] = true;
    }
    else{
        basic3[i] = false;
    }
}

foreach(bool state in basic3){
    Console.WriteLine($"{state}");
}

Console.WriteLine("[{0}]", string.Join(", ", basic3));


List<string> flavors = new List<string>(){"chocolate", "vanilla", "mint", "oreo", "caramel"};

Console.WriteLine(flavors.Count);
Console.WriteLine(flavors[2]);
flavors.RemoveAt(2);
Console.WriteLine($"The new length is: {flavors.Count}");

Dictionary<string,string> userInfo = new Dictionary<string, string>(){
    {"Tim", "caramel"},
    {"Martin", "oreo"},
    {"Nikki", "vanilla"},
    {"Sara", "mint"}
};

foreach(KeyValuePair<string, string> user in userInfo){
    Console.WriteLine($"Name: {user.Key}, Flavor: {user.Value}");
}