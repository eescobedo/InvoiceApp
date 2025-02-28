using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceApp.Pages.Invoices
{
  public class IndexModel : PageModel
  {
    private readonly ApplicationDbContext context;
    public List<Invoice> invoices = new();

    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; }
    public const int ItemsPerPage = 10;


    public IndexModel(ApplicationDbContext context)
    {
      this.context = context;
    }

    public void OnGet(int currentPage = 1)
    {
      CurrentPage = currentPage;
      var totalItems = context.Invoices.Count();
      TotalPages = totalItems / ItemsPerPage;
      if (totalItems % ItemsPerPage > 0)
      {
        TotalPages++;
      }

      invoices = context.Invoices
        .OrderByDescending(i => i.Id)
        .Skip((CurrentPage - 1) * ItemsPerPage)
        .Take(ItemsPerPage)
        .ToList();
    }
    /*    {
          invoices = context.Invoices.OrderByDescending(i => i.Id).ToList();
      }*/
  }
}