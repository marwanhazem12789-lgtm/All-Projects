namespace Vechil.Models
{
    public class MaintenanceTypeRepo : IMaintenanceType
    {
        public readonly Context c;
        public MaintenanceTypeRepo()
        {
            c = new Context();
        }
        public void AddMaintenanceType(MaintenanceType maintenanceType)
        {
            c.MaintenanceTypes.Add(maintenanceType);
            c.SaveChanges();
        }

        public void DeleteMaintenanceType(int id)
        {
            var maintenanceType = c.MaintenanceTypes.Find(id);
            if (maintenanceType != null)
            {
                c.MaintenanceTypes.Remove(maintenanceType);
                c.SaveChanges();
            }
        }

        public MaintenanceType GetMaintenanceTypeById(int id)
        {
            return c.MaintenanceTypes.Find(id);
        }

        public List<MaintenanceType> GetMaintenanceTypes()
        {
            return c.MaintenanceTypes.ToList();
        }

        public void UpdateMaintenanceType(MaintenanceType maintenanceType)
        {
            c.MaintenanceTypes.Update(maintenanceType);
            c.SaveChanges();
        }
    }
}
