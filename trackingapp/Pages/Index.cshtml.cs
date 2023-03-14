using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using trackingapp.Data;
using trackingapp.Models;
using ClosedXML.Excel;
using System.IO;

namespace trackingapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IssueDbContext _context;

        public IndexModel(IssueDbContext context)
        {
            _context = context;
        }

        public List<Issue> Issues { get; set; }

          

        public void OnGet()
        {
            // Retrieve all issues from the database
            Issues = _context.Issues.ToList();

            // Debug information: print the number of retrieved issues
            System.Diagnostics.Debug.WriteLine($"Retrieved {Issues.Count} issues from the database.");
        }
    }
}
