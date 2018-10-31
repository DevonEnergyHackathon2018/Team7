using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Griedy.Lib.DataContext
{
    public interface IDataContext
    {
        DbSet<JobDetail> JobDetails { get; set; }
        DbSet<JobInstance> JobInstances { get; set; }
        DbSet<JobStatus> JobStatus { get; set; }
        DbSet<JobType> JobTypes { get; set; }

        int SaveChanges();

        void BeginTransaction();
        void Commit();
        void Rollback();

        void UpdateValues<T>(T src, T dest) where T : class;
    }
}
