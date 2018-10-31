namespace Griedy.Lib.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[Jobs].[JobDetail]")]
    public partial class JobDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobDetailId { get; set; }

        public int JobInstanceId { get; set; }

        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }

        [Required]
        [StringLength(10)]
        public string Severity { get; set; }

        public virtual JobInstance JobInstance { get; set; }
    }
}
