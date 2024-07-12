using FitfokusServer.Models.DomainObjects;
using FitfokusServer.Models.DomainObjects.MessageBoard;
using FitfokusServer.Models.DTOs.Requests;


namespace FitfokusServer.Models.DTOs.Responses;
    public class GetUserResponseDTO
    {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool Verified { get; set; } = false;

    public List<ReportResultRequestDTO> Results { get; set; } = new List<ReportResultRequestDTO>();
    //Forum properties
    //public List<Topic>? Topics { get; set; }
    //public List<Message>? Messages { get; set; }
}

