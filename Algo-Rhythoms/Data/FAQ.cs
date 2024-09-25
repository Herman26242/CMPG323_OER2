using System;

namespace Algo_Rhythoms.Data
{
    public class FAQ
    {
        public int FAQID { get; set; }  // Unique ID for each FAQ entry (auto-incremented)
        public string Question { get; set; }  // The question in the FAQ
        public string Answer { get; set; }  // The answer corresponding to the question
        public int CreatedBy { get; set; }  // The ID of the user who created the FAQ
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;  // Date when the FAQ was created
        public int? UpdatedBy { get; set; }  // The ID of the user who last updated the FAQ
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;  // Date when the FAQ was last updated

        // Navigation properties can be added if needed
        //public User CreatedByUser { get; set; }  // Navigation property for the creator
        //public User UpdatedByUser { get; set; }  // Navigation property for the updater
    }
}
