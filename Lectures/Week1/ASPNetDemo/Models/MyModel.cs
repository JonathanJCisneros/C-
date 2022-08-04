namespace ASPNetDemo.Models;

public class MyModel 
{
    public string FavoritePokemon {get; set;}
    public List<int> NumbersILike {get; set;} = new List<int>();

    public MyModel(string favoritePokemon, List<int> numbersILike)
    {
        FavoritePokemon = favoritePokemon;
        NumbersILike = numbersILike;
    }
}

