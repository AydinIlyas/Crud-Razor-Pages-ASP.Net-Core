using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{

    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty,"Fuck You");
            }
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
