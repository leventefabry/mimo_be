namespace Mimo.Application.Contracts.Responses;

public  readonly record struct TokenResponseDto
{
    public string AccessToken { get; init; }
}