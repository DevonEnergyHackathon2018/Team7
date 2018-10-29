namespace Griedy.Lib.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[Jobs].[JobType]")]
    public partial class JobType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobType()
        {
            JobInstances = new HashSet<JobInstance>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobTypeId { get; set; }

        [Required]
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobInstance> JobInstances { get; set; }
    }
}
