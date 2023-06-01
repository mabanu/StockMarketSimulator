using StockMarketSimulator.Entities;

namespace StockMarketSimulator.Repositories.UserRepository;

public interface IUserRepository
{
  List<User> GetUsers();

  User FindUser(Guid id);

  void CreateUser(User user);

  void UpdateUser(Guid id, User user);

  void DeleteUser(Guid id);

  void Save();
}