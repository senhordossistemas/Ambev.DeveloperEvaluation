using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Repositories;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Specifications;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;

public class AuthenticateUserHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
{
    public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user == null || !passwordHasher.VerifyPassword(request.Password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        var activeUserSpec = new ActiveUserSpecification();
        if (!activeUserSpec.IsSatisfiedBy(user)) throw new UnauthorizedAccessException("User is not active");

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticateUserResult
        {
            Token = token,
            Email = user.Email,
            Name = user.Username,
            Role = user.Role.ToString()
        };
    }
}