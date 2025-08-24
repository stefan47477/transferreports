using TransferReports.Api.Models;
using TransferReports.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace TransferWire.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(this IServiceProvider sp)
    {
        using var scope = sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.MigrateAsync();

        if (await db.Rumors.AnyAsync()) return;

        var data = new List<TransferRumor>
        {
            new() { Player="Kylian Mbappé", FromClub="PSG", ToClub="Real Madrid", Fee="Free", Source="Fabrizio Romano", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2024-07-22T10:00:00Z"), Note="Here we go, full agreement reached after years of speculation." },
            new() { Player="Declan Rice", FromClub="West Ham", ToClub="Arsenal", Fee="£105m", Source="BBC Sport", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-07-15T09:00:00Z"), Note="Arsenal smashed their transfer record." },
            new() { Player="Moisés Caicedo", FromClub="Brighton", ToClub="Chelsea", Fee="£115m", Source="Sky Sports", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-08-14T12:30:00Z"), Note="British record fee agreed." },
            new() { Player="Jude Bellingham", FromClub="Borussia Dortmund", ToClub="Real Madrid", Fee="€103m + add-ons", Source="Marca", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-06-07T14:00:00Z"), Note="Teenage superstar signs for Los Blancos." },
            new() { Player="Mason Mount", FromClub="Chelsea", ToClub="Manchester United", Fee="£55m", Source="The Athletic", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-07-05T10:00:00Z"), Note="First summer signing for Ten Hag." },
            new() { Player="André Onana", FromClub="Inter Milan", ToClub="Manchester United", Fee="£47m", Source="Sky Sports", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-07-20T09:30:00Z"), Note="Reunited with Erik ten Hag." },
            new() { Player="Kai Havertz", FromClub="Chelsea", ToClub="Arsenal", Fee="£65m", Source="Guardian", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-06-28T11:00:00Z"), Note="Cross-London move completed." },
            new() { Player="Sadio Mané", FromClub="Liverpool", ToClub="Bayern Munich", Fee="€32m", Source="Sky Germany", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2022-06-22T13:00:00Z"), Note="Completed after six successful years at Anfield." },
            new() { Player="Cristiano Ronaldo", FromClub="Free agent (Manchester United exit)", ToClub="Al-Nassr", Fee="Free (massive wages)", Source="BBC Sport", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-01-01T10:00:00Z"), Note="Historic move to Saudi Arabia." },
            new() { Player="Lionel Messi", FromClub="PSG", ToClub="Inter Miami", Fee="Free", Source="ESPN", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-06-08T15:00:00Z"), Note="Biggest MLS signing in history." },
            new() { Player="Mykhailo Mudryk", FromClub="Shakhtar Donetsk", ToClub="Chelsea", Fee="£88.5m", Source="Sky Sports", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-01-15T14:00:00Z"), Note="Hijacked Arsenal’s bid." },
            new() { Player="Harry Kane", FromClub="Tottenham", ToClub="Bayern Munich", Fee="€100m + add-ons", Source="Bild", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-08-12T09:00:00Z"), Note="Ends long Spurs chapter." },
            new() { Player="Romelu Lukaku", FromClub="Chelsea", ToClub="Inter Milan", Fee="Loan attempt failed (initially)", Source="Gazzetta dello Sport", Credibility=Credibility.Tier2, Timestamp=DateTimeOffset.Parse("2022-06-10T09:00:00Z"), Note="Negotiations collapsed before revived later." },
            new() { Player="Frenkie de Jong", FromClub="Barcelona", ToClub="Manchester United", Fee="€85m (rumoured)", Source="BBC Sport", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2022-08-15T12:00:00Z"), Note="Transfer failed, player refused move." },
            new() { Player="Sergio Ramos", FromClub="Real Madrid", ToClub="PSG", Fee="Free", Source="L’Équipe", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2022-07-10T09:00:00Z"), Note="Legend leaves Madrid after long career." },
            new() { Player="Erling Haaland", FromClub="Borussia Dortmund", ToClub="Manchester City", Fee="£51m release clause", Source="Manchester City", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2022-05-10T08:00:00Z"), Note="One of the biggest signings of 2022." },
            new() { Player="Kylian Mbappé", FromClub="PSG", ToClub="PSG", Fee="Contract renewal", Source="Le Parisien", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2022-05-21T18:00:00Z"), Note="Shocking U-turn, snubbed Real Madrid in 2022." },
            new() { Player="Nicolò Zaniolo", FromClub="AS Roma", ToClub="AC Milan", Fee="Deal collapsed", Source="Gazzetta", Credibility=Credibility.Gossip, Timestamp=DateTimeOffset.Parse("2023-01-29T12:00:00Z"), Note="Milan pulled out late." },
            new() { Player="Kylian Mbappé", FromClub="PSG", ToClub="Al-Hilal", Fee="€300m bid rejected", Source="Sky Sports", Credibility=Credibility.Tier1, Timestamp=DateTimeOffset.Parse("2023-07-25T11:00:00Z"), Note="World record bid rejected, player refused talks." },
            new() { Player="Victor Osimhen", FromClub="Napoli", ToClub="Chelsea", Fee="€120m rumoured", Source="Daily Mail", Credibility=Credibility.Gossip, Timestamp=DateTimeOffset.Parse("2024-01-15T15:00:00Z"), Note="Still just speculation." }
        };

        db.Rumors.AddRange(data);
        await db.SaveChangesAsync();
    }
}
