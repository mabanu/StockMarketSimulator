using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Contracts.User;
using StockMarketSimulator.Mapping;
using StockMarketSimulator.Repositories.UserRepository;

namespace StockMarketSimulator.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserRepository _userRepository;

  public UserController(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  [HttpGet]
  public ActionResult<List<UserResponse>> GetUsers()
  {
    var users = _userRepository.GetUsers();

    if (users == null) return NotFound();

    var response = users.Select(UserMapper.UserToUserResponse).ToList();

    return Ok(response);
  }
}