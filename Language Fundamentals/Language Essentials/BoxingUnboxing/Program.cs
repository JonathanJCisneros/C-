List<object> NewBox = new List<object>(){7, 28, -1, true, "chair"};

foreach(object value in NewBox){
    Console.WriteLine(value);
}

int sum = 0;

foreach(object value in NewBox){
    if(value is int){
        sum = sum + (int)value;
    }
}

Console.WriteLine(sum);
