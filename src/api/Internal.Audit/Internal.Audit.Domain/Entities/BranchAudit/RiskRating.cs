using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit
{
    [Table("RiskRating", Schema = "BranchAudit")]
    internal class RiskRating : EntityBase
    {
        [Required]
        public Guid CountryId { get; set; }
        [Required]
        public Guid RatingTypeId { get; set; }
        [Required]
        public int MinWeightSum { get; set; }

        [Required]
        public int MaxWeightSum { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public DateTime EndingDate { get; set; }




        //Navigation properties
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; } = null!;

        [ForeignKey("RatingTypeId")]
        public virtual RatingType RatingType { get; set; } = null!; // foreign key
    }
}
