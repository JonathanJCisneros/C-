// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> numbers = new List<int>(){1, 3, 6, 12345, 32, 11, 400, 9001, 7};

List<int> numsAboveTen = numbers.Where(num => num > 10).ToList();

List<int> numsBelowTen = numbers.Where(num => num < 10).ToList();

List<int> topThree = numbers.Where(num => num > 0 && num < 4).ToList();

int firstNumAboveTen = numbers.First(num => num > 9000);

int missingBigNumber = numbers.FirstOrDefault(num => num > 100000);

foreach (int num in numsAboveTen)
{
    Console.WriteLine(num);
}

Console.WriteLine(firstNumAboveTen);

foreach (int num in numsBelowTen)
{
    Console.WriteLine(num);
}

foreach (int num in topThree)
{
    Console.WriteLine(num);
}

Console.WriteLine(missingBigNumber);

List<string> names = new List<string>(){
    "Adam",
    "Amanda",
    "Spencir",
    "Juan",
    "Froilan",
    "Tre",
    "Alex Miller"
};

List<string> aNames = names.Where(name => name.Contains("A")).ToList();

string? missingName = names.FirstOrDefault(name => name == "Alex Miller");

foreach (string name in aNames)
{
    Console.WriteLine(name);
}

Console.WriteLine(missingName);

Person adam = new Person("Adam", "Bates", 117);
Person juan = new Person("Juan", "Santiago", 9001);
Person spencir = new Person("Spencir", "Fields", 4);

List<Person> peopleList = new List<Person>()
{
    adam,
    juan,
    spencir
};

List<Person> oldEnoughToDrink = peopleList.Where(person => person.Age > 21 && !person.FirstName.ToLower().StartsWith("a")).ToList();

foreach (Person p in oldEnoughToDrink)
{
    Console.WriteLine($"{p.FirstName} {p.LastName}");
}

bool olderThan100 = peopleList.Any(person => person.Age > 100);

Console.WriteLine(olderThan100);

Movie interStellar = new Movie("Interstellar", "Spencir Fields");
Movie rushHour = new Movie("Rush Hour", "Juan Santiago");

List<Movie> movies = new List<Movie>()
{
    interStellar,
    rushHour
};

var moviesAndActors = movies.
    Join(peopleList, //joining movies w/ list of people
    movie => movie.LeadActor,
    actor => actor.FullName(),
    (movies, actor) => new{movies, actor} //making new dictionary
).ToList();

foreach (var movieWithActor in moviesAndActors)
{
    Console.WriteLine(movieWithActor.movies.Title + " starring " + movieWithActor.actor.FullName() + " who is currently: " + movieWithActor.actor.Age);
}