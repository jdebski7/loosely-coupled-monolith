using Microsoft.AspNetCore.Identity;

namespace Identities.Domain;

public static class PasswordHasher
{
    private static readonly IPasswordHasher<object?> Hasher = new PasswordHasher<object?>();
    
    public static string Hash(string password)
    {
        return Hasher.HashPassword(default, password);
    }

    public static bool Verify(string password, string hash)
    {
        var passwordVerificationResult = Hasher.VerifyHashedPassword(default, hash, password);
        return passwordVerificationResult is PasswordVerificationResult.Success or
            PasswordVerificationResult.SuccessRehashNeeded;
    }
}