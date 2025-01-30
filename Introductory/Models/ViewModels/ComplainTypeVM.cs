using System.ComponentModel.DataAnnotations;

namespace Introductory.Models.ViewModels
{
    public class ComplainTypeVM
    {
        public int ComplainTypeID { get; set; }
        public string ComplainTypeName { get; set; }
        public string ComplainTypeCode { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
    }
}
