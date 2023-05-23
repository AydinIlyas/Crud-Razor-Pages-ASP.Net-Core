using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            Category = _db.Categories.Find(Id);
            //Category = _db.Categories.First(u=>u.Id==Id);
            //Category = _db.Categories.FirstOrDefault(u => u.Id == Id);
            //Category = _db.Categories.SingleOrDefault(u => u.Id == Id);
            //Category = _db.Categories.Where(u => u.Id == Id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "Fuck You");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
