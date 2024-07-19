
namespace Games_Zone.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectListAsync()
        {
            return await _dbContext.Categories
               .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }) // SelectListItem used for representing drop down list
               .OrderBy(c => c.Text)
               .ToListAsync();

        }
    }
}
