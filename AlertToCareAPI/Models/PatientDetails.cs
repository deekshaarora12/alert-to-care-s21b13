

namespace AlertToCareAPI.Models
{
    public class PatientDetails
    {
        
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string BedId { get; set; }
        public string IcuId { get; set; }
        public VitalsCategory Vitals { get; set; }
        public PatientAddress Address { get; set; }
    }
}