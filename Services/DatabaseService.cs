using Matrimony.Models;
using SQLite;

namespace Matrimony.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<User>().Wait();
    }

    public Task<int> AddUserAsync(User user) =>
        _db.InsertAsync(user);

    public Task<User> GetUserAsync(string email, string password) =>
        _db.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
}
