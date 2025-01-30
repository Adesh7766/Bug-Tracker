using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models
{
    public class UserGroup
    {
        public int UserGroupID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int isActive { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users Users { get; set; }
    }
}
