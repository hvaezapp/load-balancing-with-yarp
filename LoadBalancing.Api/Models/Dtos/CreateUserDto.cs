namespace LoadBalancing.Api.Models.Dtos;

public class CreateUserDto
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public DateTime DateOfBirth { get; init; }
}