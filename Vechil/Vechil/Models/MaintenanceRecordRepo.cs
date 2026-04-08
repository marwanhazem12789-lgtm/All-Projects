namespace Vechil.Models
{
    public class MaintenanceRecordRepo : IMaintenanceRecord
    {
        public readonly Context c;
        public MaintenanceRecordRepo()
        {
            c = new Context();
        }
        public void Add(MaintenanceRecordFormViewModel record)
        {
            var maintenanceRecord = new MaintenanceRecord
            {
                VehicleId = record.VehicleId,
                MaintenanceTypeId = record.MaintenanceTypeId,
                ServiceDate = record.ServiceDate,
                CurrentKm = record.CurrentKm,
                Notes = record.Notes
            };
            c.MaintenanceRecords.Add(maintenanceRecord);
            c.SaveChanges();
        }
        public void Delete(MaintenanceRecordFormViewModel record)
        {
            var maintenanceRecord = c.MaintenanceRecords.Find(record.Id);
            if (maintenanceRecord != null)
            {
                c.MaintenanceRecords.Remove(maintenanceRecord);
                c.SaveChanges();
            }
        }
        public List<MaintenanceRecord> GetAll()
        {
            return c.MaintenanceRecords.ToList();
        }
        public MaintenanceRecord GetByID(int id)
        {
            return c.MaintenanceRecords.Find(id);
        }
        public void Update(MaintenanceRecordFormViewModel record)
        {
            var maintenanceRecord = c.MaintenanceRecords.Find(record.Id);
            if (maintenanceRecord != null)
            {
                maintenanceRecord.ServiceDate = record.ServiceDate;
                maintenanceRecord.CurrentKm = record.CurrentKm;
                maintenanceRecord.Notes = record.Notes;
                c.MaintenanceRecords.Update(maintenanceRecord);
                c.SaveChanges();
            }

        }
    }
}
