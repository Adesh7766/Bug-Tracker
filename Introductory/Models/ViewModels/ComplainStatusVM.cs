using System.ComponentModel.DataAnnotations;

namespace Introductory.Models.ViewModels
{
    public class ComplainStatusVM
    {
        public int ComplainStatusID { get; set; }
        public string ComplainStatusName { get; set; }
        public string ComplainStatusCode { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Created_By { get; set; }
    }
}
