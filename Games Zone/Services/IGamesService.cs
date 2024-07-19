namespace Games_Zone.Services
{
    public interface IGamesService
    {
        IEnumerable<SelectListItem> UniqueGames { get; set; }

        public Task<IEnumerable<Game>> GetAllAsync();

        public Task<Game>? GetByIdAsync(int? id);
        public Task CreateAsync(CreateGameFormViewModel model);
        
        public Task<Game?> UpdateAsync(EditGameFormViewModel model);
        public Task<bool> DeleteAsync(int id);

        public Task clientCreateAsync(CreateGameFormViewModel model);

        public Task<IEnumerable<Game>> GetByCategoryAsync(int categoryId);
        public Task<IEnumerable<Game>>? GetByNameAsync(string? Name);

        public Task<IEnumerable<Game>>? GetTopRatedAsync();
    }
}
