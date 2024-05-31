namespace FitfokusServer.Models.DomainObjects.Responses;

    public class Result
    {
    public int Id { get; set; }
    //Starting point
    public decimal? StartingWeight { get; set; }
    public decimal? StartingHip { get; set; }
    public decimal? StartingCheast { get; set; }
    public decimal? StartingNeck { get; set; }

    public decimal CurrentWeight { get; set; }
    public decimal CurrentHip { get; set; }
    public decimal CurrentCheast { get; set; }
    public decimal CurrentNeck { get; set; }


    public int UserId { get; set; }

    public User User { get; set; }


    }
