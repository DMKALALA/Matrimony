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
        _db.CreateTableAsync<Couples>();

        //uncomment to add test data - AD 4-23-2025
       //_db.InsertAsync(new Couples { Name = "test couple", Date = DateTime.Now });
    }

    public Task<int> AddUserAsync(User user) =>
        _db.InsertAsync(user);

    public Task<User> GetUserAsync(string email, string password) =>
        _db.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

    public async void InsertCouples(Couples couple)
    {
        await _db.InsertAsync(couple);
    }

    public async Task<List<Couples>> GetCouplesByNameAsync(string name)
    {
        List<Couples> couplesList = await _db.Table<Couples>().Where(x => x.Name == name).OrderBy(x => x.Name).ToListAsync();

        return couplesList;
    }

    public async Task UpdateCoupleRSVPAsync(int coupleId, bool rsvpStatus)
    {
        var couple = await _db.Table<Couples>().FirstOrDefaultAsync(x => x.Id == coupleId);
        if (couple != null)
        {
            couple.RSVP = rsvpStatus;
            await _db.UpdateAsync(couple);
        }
    }
}
