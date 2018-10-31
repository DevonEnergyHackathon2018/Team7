namespace Griedy.Lib.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompressorResult")]
    public partial class CompressorResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CompressorId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompressorName { get; set; }

        public DateTime RankedOn { get; set; }

        public int RiskRanking { get; set; }
    }
}
