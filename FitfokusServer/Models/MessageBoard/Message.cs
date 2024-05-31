using FitfokusServer.Models.DomainObjects.Responses;

namespace FitfokusServer.Models.MessageBoard;

    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        
    
        public int? UserId { get; set; }
        public int TopicId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Topic Topic { get; set; }
    }

