namespace CodeNotes.API.Requests;

public record CreateUserRequest(string Email, string Username, string Password, string Bio);
