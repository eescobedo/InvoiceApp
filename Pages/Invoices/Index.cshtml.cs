using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
  public class IndexModel : PageModel
  {
    private readonly ApplicationDbContext context;
    public List<Invoice> invoices = new();

    public IndexModel(ApplicationDbContext context)
    {
      this.context = context;
    }


    public void OnGet()
    {
      invoices = context.Invoices.OrderByDescending(i => i.Id).ToList();
    }
  }
}