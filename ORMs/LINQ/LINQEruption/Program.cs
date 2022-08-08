using LINQEruption;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// // Execute Assignment Tasks here!


// // Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
// static void PrintEach(IEnumerable<dynamic> items, string msg = "")
// {
//     Console.WriteLine("\n" + msg);
//     foreach (var item in items)
//     {
//         Console.WriteLine(item.ToString());
//     }
// }

// First chile eruption
Eruption FirstChile = eruptions.First(eruption => eruption.Location == "Chile");
Console.WriteLine(FirstChile);

// First Hawaiian Is eruption
Eruption? FirstHawaiian = eruptions.First(eruptions => eruptions.Location == "Hawaiian Is");
if(FirstHawaiian != null)
{
    Console.WriteLine(FirstHawaiian);
}
else
{
    Console.WriteLine("Hawaiian Is not found");
}

// New Zealand eruption > year 1900
IEnumerable<Eruption> NewZealand = eruptions.Where(eruption => eruption.Year > 1900);
Console.WriteLine(NewZealand.First());

// Eruptions higher than 2000m
IEnumerable<Eruption> heightTwoThousand = eruptions.Where(eruption => eruption.ElevationInMeters > 2000);

foreach (Eruption item in heightTwoThousand)
{
    Console.WriteLine(item);
}

// starts with Z
IEnumerable<Eruption> startsWithZ = eruptions.Where(eruption => eruption.Volcano.StartsWith("Z"));
foreach (Eruption item in startsWithZ)
{
    Console.WriteLine(item);
}
Console.WriteLine($"These are how many eruptions from volcanoes that start with 'Z': {startsWithZ.Count()}" );

// highest elevation
int? highest = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(highest);

// volcano Name
Eruption volName = eruptions.First(e => e.ElevationInMeters == highest);
Console.WriteLine(volName.Volcano);

// All Volcanoes by alphabet
IEnumerable<Eruption> allVolcanoes = eruptions.OrderBy(e => e.Volcano);
foreach (Eruption item in allVolcanoes)
{
    Console.WriteLine(item.Volcano);
}

// Print all
IEnumerable<Eruption> before1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
foreach (Eruption item in before1000)
{
    Console.WriteLine(item);
};

foreach (Eruption item in before1000)
{
    Console.WriteLine(item.Volcano);
};

