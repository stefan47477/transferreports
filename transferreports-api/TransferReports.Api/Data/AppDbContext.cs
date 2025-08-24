using Microsoft.EntityFrameworkCore;
using TransferReports.Api.Models;
using TransferReports.Api.Models;

namespace TransferReports.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TransferRumor> Rumors => Set<TransferRumor>();
}
