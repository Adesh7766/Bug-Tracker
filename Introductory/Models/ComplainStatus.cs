using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models
{
    public class ComplainStatus
    {

        [Key]
        public int ComplainStatusID { get; set; }
        public string ComplainStatusName { get; set; }
        public string ComplainStatusCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users Users { get; set; }
    }
}
