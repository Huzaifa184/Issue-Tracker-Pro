using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trackingapp.Data;
using trackingapp.Models;

namespace trackingapp.Pages.Issues
{
    public class DetailModel : PageModel
    {
        private readonly IssueDbContext _context;

        public DetailModel(IssueDbContext context)
        {
            _context = context;
        }
        public List<Issue> Issues { get; private set; }

        public Issue Issue { get; private set; }

        public async Task OnGet(int id)
        {
            Issue = await _context.Issues.FindAsync(id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostResolveAsync(int id)
        {
            var issueToUpdate = await _context.Issues.FindAsync(id);
            if (issueToUpdate == null)
            {
                return NotFound();
            }

            issueToUpdate.Completed = DateTime.Now;
            await _context.SaveChangesAsync();

            // Remove the resolved issue from the list
            var issues = await _context.Issues.ToListAsync();
            issues.Remove(issueToUpdate);

            return RedirectToPage("/Index", issues);
        }

    }
}