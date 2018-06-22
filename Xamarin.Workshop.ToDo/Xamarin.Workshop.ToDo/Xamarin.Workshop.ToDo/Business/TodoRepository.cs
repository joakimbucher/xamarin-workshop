using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Xamarin.Workshop.ToDo.Business
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IFileHelper _fileHelper;

        private readonly string _databasePath;

        private SQLiteAsyncConnection _database;

        public TodoRepository(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;

            _databasePath = _fileHelper.GetLocalFilePath("TodoSQLite.db3");

            _database = new SQLiteAsyncConnection(_databasePath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            return await _database.Table<TodoItem>().ToListAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await _database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(TodoItem item)
        {
            return await _database.UpdateAsync(item);
        }

        public async Task<int> InsertAsync(TodoItem item)
        {
            return await _database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            return await _database.DeleteAsync(item);
        }
    }
}
