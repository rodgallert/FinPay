namespace Domain.Shared;

public static class Utils
{
    public static string EncryptBcrpypt(string input, string? salt)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input cannot be null or empty", nameof(input));
        }
        var saltedInput = string.IsNullOrEmpty(salt) ? input : $"{input}{salt}";

        return BCrypt.Net.BCrypt.HashPassword(saltedInput);
    }

    public static string GenerateSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(16);
    }

    public static bool ValidatePassword(string input, string hashedPassword, string? salt)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(hashedPassword))
        {
            throw new ArgumentException("Input and hashed password cannot be null or empty");
        }
        var saltedInput = string.IsNullOrEmpty(salt) ? input : $"{input}{salt}";
        return BCrypt.Net.BCrypt.Verify(saltedInput, hashedPassword);
    }
}
