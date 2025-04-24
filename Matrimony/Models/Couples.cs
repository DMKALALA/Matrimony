using SQLite;
namespace Matrimony.Models;


public class Couples
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public DateTime Date { get; set; }
	public bool RSVP { get; set; }

}