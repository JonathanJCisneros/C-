// prints all values between 1 and 255

// for(int i = 0; i <= 255; i++)
// {
//     Console.WriteLine(i);
// }




// prints all values divisible by 3 or 5 but not both

// for(int i = 1; i <= 100; i++)
// {
//     if(i % 3 == 0 && i % 5 == 0)
//     {
//         continue;
//     }
//     else if(i % 3 == 0)
//     {
//         Console.WriteLine(i);
//     }
//     else if(i % 5 == 0)
//     {
//         Console.WriteLine(i);
//     }
// }




// prints Fizz for divisible by 3 and Buzz for divisible by 5, FizzBuzz for divisible by both

// for(int i = 1; i <= 100; i++)
// {
//     if(i % 3 == 0 && i % 5 == 0)
//     {
//         Console.WriteLine("FizzBuzz");
//     }
//     else if(i % 3 == 0)
//     {
//         Console.WriteLine("Fizz");
//     }
//     else if(i % 5 == 0)
//     {
//         Console.WriteLine("Buzz");
//     }
// }




// use while loops for the above 3


// int start = 0;

// while (start <= 255)
// {
//     Console.WriteLine(start);
//     start++;
// }




// int s = 1;



// while(s <= 100)
// {
//     if(s % 3 == 0 && s % 5 == 0)
//     {
//         s++;
//     }
//     else if(s % 3 == 0)
//     {
//         Console.WriteLine(s);
//     }
//     else if(s % 5 == 0)
//     {
//         Console.WriteLine(s);
//     }
//     s++;
// }



// while(s <= 100)
// {
//     if(s % 3 == 0 && s % 5 == 0)
//     {
//         Console.WriteLine("FizzBuzz");
//     }
//     else if(s % 3 == 0)
//     {
//         Console.WriteLine("Fizz");
//     }
//     else if(s % 5 == 0)
//     {
//         Console.WriteLine("Buzz");
//     }
//     s++;
// }




// array with integers 0-9

// int[] nums = new int[]{0,1,2,3,4,5,6,7,8,9};

// foreach (int i in nums)
// {
//     Console.WriteLine(i);
// }





// array of names

// string[] names = new string[]{ "Tim", "Martin", "Nikki", "Sara" };

// foreach (string i in names)
// {
//     Console.WriteLine(i);
// }




// array of alternate bool

// bool[] altBool = new bool[10];

// for(int i = 0; i < altBool.Length; i++)
// {
//     if(i % 2 == 0)
//     {
//         altBool[i] = true;
//     }
//     else
//     {
//         altBool[i] = false;
//     }
// }

// foreach (bool i in altBool)
// {
//     Console.WriteLine(i);
// }




// List of flavors

// List<string> Flavors = new List<string>(){"Chocolate", "Caramel", "Vanilla", "Grape", "Huckleberry"};

// foreach (string i in Flavors)
// {
//     Console.WriteLine(i);
// }

// Console.WriteLine(Flavors.Count);

// Console.WriteLine(Flavors[2]);
// Flavors.RemoveAt(2);

// Console.WriteLine(Flavors.Count);




// Dictionary

// Dictionary<string, string> User = new Dictionary<string, string>();

Random rand = new Random();

// foreach (string n in names)
// {
//     int newIdx = rand.Next(0, Flavors.Count);
//     User.Add(n, Flavors[newIdx]);
// }

// foreach (KeyValuePair<string, string> i in User)
// {
//     Console.WriteLine("{ " + i.Key + " : " + i.Value + " }");
// }



// Random Array


// int[] nums = new int[10];

// int min = 25;
// int max = 5;
// int sum = 0;

// for(int i = 0; i < nums.Length; i++)
// {
//     int randIdx = rand.Next(5, 26);
//     nums[i] = randIdx;
//     sum += nums[i];
//     if(nums[i] < min)
//     {
//         min = nums[i];
//     }
//     if(nums[i] > max)
//     {
//         max = nums[i];
//     }
// }

// foreach (int i in nums)
// {
//     Console.WriteLine(i);
// }

// Console.WriteLine(min);
// Console.WriteLine(max);
// Console.WriteLine(sum);




// Coin flip

// string TossCoin()
// {
//     Console.WriteLine("Tossing a Coin!");
//     int side = rand.Next(0, 2);
//     if(side == 0)
//     {
//         return "Heads"; 
//     }
//     else
//     {
//         return "Tails";
//     }
// }

// Console.WriteLine(TossCoin());



// Names

List<string> names = new List<string>(){ "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };

List<string> Names(List<string> n)
{
    List<string> newList = new List<string>();
    foreach (string name in n)
    {
        if(name.Length > 5)
        {
            newList.Add(name);
        }
    }
    return newList;
}

Console.WriteLine(Names(names));