using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TransferReports.Api.Data;
using TransferReports.Api.Models;

namespace TransferReports.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RumorsController(AppDbContext db) : ControllerBase
{
    // GET /api/rumors?player=mbappe&club=chelsea&credibility=Tier1
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransferRumor>>> Get(
        [FromQuery] string? player,
        [FromQuery] string? club,
        [FromQuery] Credibility? credibility,
        [FromQuery] int take = 50,
        [FromQuery] int skip = 0)
    {
        IQueryable<TransferRumor> q = db.Rumors.AsNoTracking()
            .OrderByDescending(r => r.Timestamp);

        if (!string.IsNullOrWhiteSpace(player))
            q = q.Where(r => r.Player.Contains(player));
        if (!string.IsNullOrWhiteSpace(club))
            q = q.Where(r => r.FromClub.Contains(club) || r.ToClub.Contains(club));
        if (credibility.HasValue)
            q = q.Where(r => r.Credibility == credibility);

        var list = await q.Skip(skip).Take(take).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TransferRumor>> GetOne(Guid id)
        => await db.Rumors.FindAsync(id) is { } r ? r : NotFound();

    [HttpPost]
    public async Task<ActionResult<TransferRumor>> Create(TransferRumor dto)
    {
        db.Rumors.Add(dto);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOne), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, TransferRumor dto)
    {
        if (id != dto.Id) return BadRequest();
        db.Entry(dto).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var r = await db.Rumors.FindAsync(id);
        if (r is null) return NotFound();
        db.Rumors.Remove(r);
        await db.SaveChangesAsync();
        return NoContent();
    }
}
