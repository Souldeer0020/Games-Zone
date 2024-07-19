
namespace Games_Zone.Services
{
    public class DeviceService : IDevicesService
    {
        private readonly ApplicationDbContext _dbContext;

        public DeviceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectedDevicesAsync()
        {
            return await _dbContext.Devices
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .ToListAsync();
        }
    }
}
