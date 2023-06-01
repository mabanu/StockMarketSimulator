using Microsoft.EntityFrameworkCore;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Services.AppContext;

namespace StockMarketSimulator.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public List<User> GetUsers()
  {
    return _context.Users.ToList();
  }

  public User FindUser(Guid id)
  {
    return _context.Users.Find(id);
  }

  public void CreateUser(User user)
  {
    _context.Users.Add(user);
  }

  public void UpdateUser(Guid id, User user)
  {
    _context.Entry(user).State = EntityState.Modified;
  }

  public void DeleteUser(Guid id)
  {
    var user = FindUser(id);

    _context.Remove(user);
  }

  public void Save()
  {
    _context.SaveChanges();
  }
}