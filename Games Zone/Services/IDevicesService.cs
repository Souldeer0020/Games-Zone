namespace Games_Zone.Services
{
    public interface IDevicesService
    {
        public Task<IEnumerable<SelectListItem>> GetSelectedDevicesAsync();
    }
}
