#pragma warning disable CS8618
public class Movie
{
    public string Title {get; set;}
    public string LeadActor {get; set;}

    public Movie(string title, string leadActor)
    {
        Title = title;
        LeadActor = leadActor;
    }
}