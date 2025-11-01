namespace Auth.Shared.Domain.Dto
{
    public record UserDto
    (
        string UserName,
        string Email,
        string Password
    );
}