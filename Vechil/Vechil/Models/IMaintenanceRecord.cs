namespace Vechil.Models
{
    public interface IMaintenanceRecord
    {
        List<MaintenanceRecord> GetAll();
        void Update(MaintenanceRecordFormViewModel record);
        void Delete(MaintenanceRecordFormViewModel record);
        MaintenanceRecord GetByID(int id);
        void Add(MaintenanceRecordFormViewModel record);
    }
}
