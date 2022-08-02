// 1. Print 1-255

static void PrintNumbers(){
    for(int i = 0; i <= 255; i++){
        Console.WriteLine(i);
    }
}

PrintNumbers();

// 2. Print odd numbers between 1-255

static void PrintOdds(){
    for(int i = 0; i <= 255; i++){
        if(i % 3 == 0){
            Console.WriteLine(i);
        }
    }
}

PrintOdds();

// 3. Print Sum

static void PrintSum(){
    int sum = 0;
    for(int i = 0; i <= 255; i++){
        sum = sum + i;
        Console.WriteLine($"New number: {i} Sum: {sum}");
    }
}

PrintSum();

// 4. Iterating through an Array
int[] test = {1,2,3,4,5};

static void LoopArray(int[] numbers){
    for(int i = 0; i < numbers.Length; i++){
        Console.WriteLine(numbers[i]);
    }
}

LoopArray(test);

// 5. Find Max

int[] test1 = {1,2,3,4,5,6,7,8,9};

static void FindMax(int[] numbers){
    int largest = 0;
    for(int i = 0; i < numbers.Length; i++){
        if(numbers[i] > largest){
            largest = numbers[i];
        }
    }
    Console.WriteLine(largest);
}

FindMax(test1);

// 6. Get Average

int[] test2 = {3,6,9};

static void GetAverage(int[] numbers){
    int sum = 0;
    for(int i = 0; i < numbers.Length; i++){
        sum = sum + numbers[i];
    }
    sum = sum/numbers.Length;
    Console.WriteLine(sum);
}

GetAverage(test2);

// 7. Array with Odd Numbers

static int[] OddArray(){
    int[] numArray = new int[] {};

    List<int> temp = numArray.ToList();
    for (int i = 0; i <= 255; i++)
    {
        if(i % 3 == 0)
        {
            temp.Add(i);
        }
    }
    numArray = temp.ToArray();

    return numArray;

}

int[] array = OddArray();

foreach(int num in array){
    Console.WriteLine(num);
}

// 8. Greater than Y

int[] test3 = new int[]{1,2,3,4,5,6,7,8,9};
int y1 = 2;

static int GreaterThanY(int[] numbers, int y)
{
    int count = 0;
    for(int i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] > y)
        {
            count++;
        }
    }
    return count;
}


Console.WriteLine(GreaterThanY(test3, y1));

// 9. Square the Values

int[] test5 = {12, 24, 35, 127, 555, 1};

static void SquareArrayValues(int[] numbers)
{
    for(int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine(numbers[i] = numbers[i] * numbers[i]);
    }
}

SquareArrayValues(test5);


// 10. Eliminate Negative Numbers

int[] test4 = {1,2,3,4,5,-5,6,-8,-9};

static void EliminateNegatives(int[] numbers)
{
    for(int i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] < 0)
        {
            numbers[i] = 0;
            Console.WriteLine(numbers[i]);
        }
        else
        {
            Console.WriteLine(numbers[i]);
        }
    }
}

EliminateNegatives(test4);

// 11. Min, Max, Average

int[] test6 = {-3,-2,2,3,4,5,6,7,8};

static void MinMaxAverage(int[] numbers)
{
    int max = 0;
    int min = 0;
    int avg = 0;
    for(int i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] > max)
        {
            max = numbers[i];
        }
        else if(numbers[i] < min)
        {
            min = numbers[i];
        }
        avg = avg + numbers[i];
    }
    avg = avg/numbers.Length;
    Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg}");
}

MinMaxAverage(test6);

// 12. Shifting the values in an array

int[] test7 = {2,3,56,3,6,4,3};

static void ShiftValues(int[] numbers)
{
    for(int i = 0; i < numbers.Length-1; i++)
    {
        numbers[i] = numbers[i+1];
    }
    numbers[numbers.Length-1] = 0;
    foreach(int num in numbers)
    {
        Console.WriteLine(num);
    }
}

ShiftValues(test7);

// 13. Number to String

int[] test8 = {-1,-3,2};

static object[] NumToString(int[] numbers)
{
    object[] objects = new object[numbers.Length];
    for(int i = 0; i < numbers.Length; i++)
    {
        if(numbers[i]< 0)
        {
            objects[i] = "Dojo";
        }
        else 
        {
            objects[i] = numbers[i];
        }
    }
    return objects;
}

object[] testing = NumToString(test8);

foreach(object tester in testing)
{
    Console.WriteLine(tester);
}