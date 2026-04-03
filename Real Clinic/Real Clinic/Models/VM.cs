namespace Real_Clinic.Models
{
    public class VM
    {
        public int Id { get; set; } 
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public int tientId { get; set; }
         public int doctorId { get; set; }
         public DateOnly date { get; set; }
         public string notes { get; set; }

    }
}
