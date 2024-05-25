namespace FitfokusServer.Models.DomainObjects.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public string UserResponse1 { get; set; } = "Hej hej från UserRepo";
    public string? Name { get; set; }
    public string? Email { get; set; }
}

