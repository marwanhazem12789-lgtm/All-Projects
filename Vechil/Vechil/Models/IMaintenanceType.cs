namespace Vechil.Models
{
    public interface IMaintenanceType
    {
        List<MaintenanceType> GetMaintenanceTypes();
        MaintenanceType GetMaintenanceTypeById(int id);
        void AddMaintenanceType(MaintenanceType maintenanceType);
        void UpdateMaintenanceType(MaintenanceType maintenanceType);
        void DeleteMaintenanceType(int id);
    }
}
