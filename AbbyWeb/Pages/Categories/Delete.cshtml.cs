using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            Category = _db.Categories.Find(Id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryfromDb = _db.Categories.Find(Category.Id);
            if (categoryfromDb != null)
            {
                _db.Categories.Remove(categoryfromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
                
        }
    }
}
