namespace Griedy.Lib.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[Jobs].[JobInstance]")]
    public partial class JobInstance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobInstance()
        {
            JobDetails = new HashSet<JobDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobInstanceId { get; set; }

        public int JobTypeId { get; set; }

        public DateTime BeginOn { get; set; }

        public DateTime? EndOn { get; set; }

        public int JobStatusId { get; set; }

        public string Message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobDetail> JobDetails { get; set; }

        public virtual JobStatus JobStatus { get; set; }

        public virtual JobType JobType { get; set; }
    }
}
