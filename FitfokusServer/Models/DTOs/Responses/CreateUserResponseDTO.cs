namespace FitfokusServer.Models.DTOs.Responses;

public class CreateUserResponseDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool Verified { get; set; } = false;

}
