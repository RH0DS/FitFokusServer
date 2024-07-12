using FitfokusServer.Models.DomainObjects;

namespace FitfokusServer.Models.MessageBoard;

public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public int? UserId { get; set; }

        public User User { get; set; }
        public List<Message>? Messages { get; set; } = new List<Message>();
    }

