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
    int[] numArray = new int[] { };

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

int[] test3 = {1,2,3,4,5,6,7,8,9};
int y1 = 2;

static int GreaterThanY(int[] numbers, int y)
{
    for(int i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] > y)
        {
            return numbers[i];
        }
    }
}


Console.WriteLine(GreaterThanY(test3, y1));