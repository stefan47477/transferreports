namespace TransferReports.Api.Models;

public class TransferRumor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Player { get; set; } = "";
    public string FromClub { get; set; } = "";
    public string ToClub { get; set; } = "";
    public string? Fee { get; set; }           // "€65m", "Free", "Loan"
    public string Source { get; set; } = "";   // "Sky Sports"
    public string? SourceUrl { get; set; }
    public Credibility Credibility { get; set; } = Credibility.Tier2;
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    public string? Note { get; set; }          // short quote
}
