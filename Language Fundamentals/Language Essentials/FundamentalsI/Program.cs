// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

for(int i = 1; i <= 255; i++){
    Console.WriteLine(i);
}

for(int j = 1; j <= 100; j++){
    if(j % 3 == 0){
        Console.WriteLine("Fizz");
    }
    else if(j % 5 == 0){
        Console.WriteLine("Buzz");
    }
}

int start = 1;

while(start <= 100){
    if(start % 3 == 0){
        Console.WriteLine("Fizz");
        start++;
    }
    else if(start % 5 == 0){
        Console.WriteLine("Buzz");
        start++;
    }
}