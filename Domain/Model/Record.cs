using System.Collections;
using System.Collections.Generic;
namespace BackendData.Domain.Model
{
    public class Record
    {
        public int _id { get; set; }
        public string year { get; set; }
        public string area { get; set; }
        public float rank { get; set; }
        public string domestic_exports { get; set; }
    }
}