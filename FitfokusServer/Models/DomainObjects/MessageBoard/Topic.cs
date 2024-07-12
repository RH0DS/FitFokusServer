namespace FitfokusServer.Models.DomainObjects.MessageBoard;

public class Topic
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public int? UserId { get; set; }

    public required User User { get; set; }
    public List<Message>? Messages { get; set; } = new List<Message>();
}

