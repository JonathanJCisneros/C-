// Random Array

static int[] RandomArray()
{
    int[] newArray = new int[10];
    int min = 15;
    int max = 0;
    int sum = 0;
    Random rand = new Random();
    for(int i = 0; i < newArray.Length; i++)
    {
        newArray[i] = rand.Next(5, 25);
        sum += newArray[i];
        if(newArray[i] > max)
        {
            max = newArray[i];
        }
        if(newArray[i] < min)
        {
            min = newArray[i];
        }
    }
    Console.WriteLine($"Min: {min}, Max: {max}, Sum: {sum}");
    return newArray;
}

int[] array1 = RandomArray();

foreach(int num in array1)
{
    Console.WriteLine(num);
}

// Coin Flip

static string TossCoin()
{
    Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    int num = rand.Next(1,3);
    if(num == 1)
    {
        return "Heads!";
    }
    else
    {
        return "Tails!";
    }
}

Console.WriteLine(TossCoin());

// Names

static List<string> Names()
{
    List<string> nameList = new List<string>(){"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
    List<string> newList = new List<string>(){};
    foreach(string name in nameList)
    {
        if(name.Length > 5)
        {
            newList.Add(name);
        }
    }
    return newList;
}

List<string> array2 = Names();

foreach(string name in array2)
{
    Console.WriteLine(name);
}