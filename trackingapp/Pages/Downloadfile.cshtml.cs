using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trackingapp.Data;
using trackingapp.Models;
using Microsoft.Extensions.Configuration;
using ClosedXML.Excel;

namespace trackingapp.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly IssueDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IConfiguration Configuration { get; }

        public DownloadModel(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IssueDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            Configuration = configuration;
            _context = context;
        }

        public IList<Issue> Issues { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Issues = await _context.Issues.ToListAsync();
            return Page();
        }

        public IActionResult OnPostDownloadIssues(int[] selectedIssues)
        {
            if (selectedIssues == null || selectedIssues.Length == 0)
            {
                return BadRequest("No issues selected");
            }

            var issues = _context.Issues.Where(i => selectedIssues.Contains(i.Id)).ToList();

            // rest of the code remains the same
        


      

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Issues");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Title";
                worksheet.Cell(1, 3).Value = "Description";
                worksheet.Cell(1, 4).Value = "IssueType";
                worksheet.Cell(1, 5).Value = "Priority";
                worksheet.Cell(1, 6).Value = "Completed";
                worksheet.Cell(1, 7).Value = "Created";

                var row = 2;
                foreach (var issue in issues)
                {
                    var escapedTitle = issue.Title.Replace("\"", "\"\"");
                    var escapedDescription = issue.Description.Replace("\"", "\"\"");
                    worksheet.Cell(row, 1).Value = issue.Id;
                    worksheet.Cell(row, 2).Value = escapedTitle;
                    worksheet.Cell(row, 3).Value = escapedDescription;
                    worksheet.Cell(row, 4).Value = issue.IssueType.ToString();

                    worksheet.Cell(row, 5).Value = issue.Priority.ToString();
                    worksheet.Cell(row, 6).Value = issue.Completed;
                    worksheet.Cell(row, 7).Value = issue.Created.ToString("yyyy-MM-dd");
                    row++;
                }

                var excelFileName = "issues.xlsx";
                var excelFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", excelFileName);

                workbook.SaveAs(excelFilePath);

                var fileStream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read);
                var result = File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);

                return result;
            }
        }
    }
}
