namespace Auth.Domain.Dto
{
    public record JwtSettingsDto
    (
        string Issuer,
        string Audience
    );
}