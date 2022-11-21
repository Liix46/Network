namespace Network.Application.App.Images.Response;

public class CreateImageDto
{
    public string? Name { get; set; }
    public string? Url { get;set;}
    public string? FormatType { get; set; }
    public int PostId { get; set; }
}