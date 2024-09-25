using Algo_Rhythoms.Data;

public class UserCredential
{
    public int CredentialID { get; set; } // This will be auto-incremented by the database
    public int UserID { get; set; } // Foreign key to User
    public string Credential { get; set; } // The actual credential

    public User User { get; set; } // Navigation property
}
