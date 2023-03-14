using System.ComponentModel.DataAnnotations;

namespace trackingapp.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }   = string.Empty;

        [Required]
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        public IssueType IssueType { get; set; }
        public Priority Priority { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High,

    }
    public enum IssueType
    {
        Feature,
        Bug,
        Documentation
    }
}
