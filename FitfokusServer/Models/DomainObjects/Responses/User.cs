using System.Numerics;
using FitfokusServer.Models.MessageBoard;

namespace FitfokusServer.Models.DomainObjects.Responses;

public class User
{
    public int Id { get; set; }
    public string? GoogleId { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool Verified  { get; set; } = false;

    public List<Result> Results { get; set; }
    //Forum properties
    public List<Topic>? Topics { get; set; }
    public List<Message>? Messages { get; set; }
}

