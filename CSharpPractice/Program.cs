
Console.WriteLine("Hello, World!");
// w3 source practice 
// 1.

Console.WriteLine("Hello: ");
Console.WriteLine("Alexandra Abramov!");

// 2.

int sum = 5 + 12;

Console.WriteLine(sum);

// 3.

int divide = 20/5;

Console.WriteLine(divide);

// 4.

Console.WriteLine(-1 + 4 * 6);
Console.WriteLine((35 + 5) % 7);
Console.WriteLine(14 + -4 * 6 / 11);
Console.WriteLine(2 + 15 / 6 * 1 - 7 % 2);

// 5.

int[] arr1 = {2,3};

static int[] Swap(int[] numbers)
{
    int first = 0;
    int second = numbers.Length-1;
    int temp = 0;
    temp = numbers[first];
    numbers[first] = numbers[second];
    numbers[second] = temp;
    return numbers;
}

int[] arr2 = Swap(arr1);

foreach(int idx in arr2)
{
    Console.WriteLine(idx);
}

// 6.

static int Multiply(int num1, int num2, int num3)
{
    return (num1 * num2 * num3);
}

Console.WriteLine(Multiply(2,3,4));

// 7.

static void AllMethods(int num1, int num2)
{
    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
    Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
    Console.WriteLine($"{num1} mod {num2} = {num1 % num2}");
}

AllMethods(10, 10);

// 8.

static void MultiplicationTable(int num)
{
    for(int i = 0; i <= 10; i++)
    {
        Console.WriteLine($"{num} * {i} = {num * i}");
    }
}

MultiplicationTable(5);

// 9. 




