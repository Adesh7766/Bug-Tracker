using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models
{
    public class Complain
    {

        [Key]
        public int ComplainId { get; set; }
        public string FullNme { get; set; }
        public string email { get; set; }
        public string ContactNo { get; set; }
        public string Statement { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ComplainTypeId { get; set; }

        [ForeignKey("ComplainTypeId")]
        public virtual ComplainType ComplainType { get; set; }
    }
}
