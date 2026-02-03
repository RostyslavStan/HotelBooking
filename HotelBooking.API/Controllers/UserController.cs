using Microsoft.AspNetCore.Mvc;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Contracts;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        await _userService.RegisterUser(request);
        
        return Ok();
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
       var token = await _userService.LoginUser(request);

        Response.Cookies.Append("AuthToken", token);
        return Ok(token);
    }
}