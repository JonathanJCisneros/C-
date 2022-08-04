#pragma warning disable CS8618
namespace DojoSurveyModel.Models;

public class Survey
{
    public string Name {get; set;}
    public string Location {get; set;}
    public string FaveLang {get; set;}
    public string? Comment {get; set;}
}