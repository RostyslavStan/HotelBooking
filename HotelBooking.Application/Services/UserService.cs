using HotelBooking.Application.Contracts;
using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

using HotelBooking.Domain.Enums;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task RegisterUser(RegisterRequest request)
    {
        var passwordHash = _passwordHasher.HashPassword(request.password);
        var user = new User
        {
            Name = request.name,
            Email = request.email,
            PasswordHash = passwordHash,
            Role = UserRole.Admin,
        };
        await _userRepository.Add(user);
    }

    public async Task<string> LoginUser(LoginRequest request)
    {
        var user = await _userRepository.GetByEmail(request.email);

        var passwordHash = _passwordHasher.Verify(request.password, user.PasswordHash);

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }
}