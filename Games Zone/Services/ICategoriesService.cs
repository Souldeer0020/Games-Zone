namespace Games_Zone.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<SelectListItem>> GetSelectListAsync();
    }
}
