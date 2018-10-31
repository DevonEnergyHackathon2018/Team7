namespace Griedy.Lib.DataContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GriedyDataContext : DbContext
    {
        public GriedyDataContext()
            : base("name=Griedy")
        {
            Database.SetInitializer<GriedyDataContext>(null);
        }

        public virtual DbSet<CompressorResult> CompressorResults { get; set; }
        public virtual DbSet<JobDetail> JobDetails { get; set; }
        public virtual DbSet<JobInstance> JobInstances { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobInstance>()
                .HasMany(e => e.JobDetails)
                .WithRequired(e => e.JobInstance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobStatus>()
                .HasMany(e => e.JobInstances)
                .WithRequired(e => e.JobStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobType>()
                .HasMany(e => e.JobInstances)
                .WithRequired(e => e.JobType)
                .WillCascadeOnDelete(false);
        }
    }
}
