namespace Mimo.Infrastructure.Auth.Responses;

public  readonly record struct TokenResponseDto
{
    public string AccessToken { get; init; }
}