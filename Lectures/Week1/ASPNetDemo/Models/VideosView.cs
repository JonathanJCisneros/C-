namespace ASPNetDemo.Models;

public class VideosView
{
    public List<string> YoutubeVideoIds = new List<string>
    {
        "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
    };

    public string Title {get; set;} = $"Here are all of my favorite videos!";

    public VideosView()
    {
        Title = $"These are my {YoutubeVideoIds.Count} favorite videos";
    }
}