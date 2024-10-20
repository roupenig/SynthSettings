using Microsoft.EntityFrameworkCore;
using SynthSettings.Repositories.Entities;

namespace SynthSettings.Repositories
{
    public class SettingContext : DbContext
    {
        public SettingContext(DbContextOptions<SettingContext> options)
        : base(options)
        {

        }

        public DbSet<SettingEntity> Settings { get; set; }
        public DbSet<OscillatorEntity> Oscillators { get; set; }
        public DbSet<EnvelopeEntity> Envelopes { get; set; }
        public DbSet<FilterEntity> Filters { get; set; }
        public DbSet<ADSREntity> ADSRs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingEntity>().Navigation(e => e.Oscillator).AutoInclude();
            modelBuilder.Entity<SettingEntity>().Navigation(e => e.Envelope).AutoInclude();
            modelBuilder.Entity<EnvelopeEntity>().Navigation(e => e.ADSR).AutoInclude();
            modelBuilder.Entity<SettingEntity>().Navigation(e => e.Filter).AutoInclude();
            modelBuilder.Entity<FilterEntity>().Navigation(e => e.ADSR).AutoInclude();
        }
    }
}