using System;
using System.Collections.Generic;

namespace Algo_Rhythoms.Data
{
    public class User
    {
        public int UserID { get; set; }  // Automatically incrementing 
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string? Affiliation { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Default to current UTC time

        // Navigation property to related UserCredentials
        public virtual ICollection<UserCredential> UserCredentials { get; set; } = new List<UserCredential>();
    }
}
