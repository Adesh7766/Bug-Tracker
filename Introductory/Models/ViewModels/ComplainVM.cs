using System.ComponentModel.DataAnnotations;

namespace Introductory.Models.ViewModels
{
    public class ComplainVM
    {
        public int ComplainId { get; set; }
        public string FullNme { get; set; }
        public string email { get; set; }
        public string ContactNo { get; set; }
        public string Statement { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public string IssueDate { get; set; }
        public string CreatedDate { get; set; }
        public int ComplainTypeId { get; set; }
    }
}
