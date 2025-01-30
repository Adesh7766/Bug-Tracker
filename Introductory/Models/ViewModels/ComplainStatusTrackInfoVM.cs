using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models.ViewModels
{
    public class ComplainStatusTrackInfoVM
    {
        public int ComplainStatusTrackInfoID { get; set; }
        public int ComplainID { get; set; }
        public int ComplainStatusID { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }

    }
}
