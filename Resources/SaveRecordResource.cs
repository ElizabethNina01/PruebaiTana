

using System.ComponentModel.DataAnnotations;
using BackendData.Resources;

namespace BackendData.Resources
{
    public class SaveRecordResource 
    {

        [Required]
         public string year { get; set; }
         [Required]
        public string area { get; set; }
        [Required]
        public float rank { get; set; }
        [Required]
        public string domestic_exports { get; set; }
  
    }
}