using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
  public class InvoiceDto
  {
    [Required]
    public string Number { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = string.Empty; // Paid or Pending
    public DateOnly? IssueDate { get; set; }
    public DateOnly? DueDate { get; set; }

    // service details
    [Required]
    public string Service { get; set; } = string.Empty;

    [Range(1, 999999, ErrorMessage = "Unit Price is not valid!")]
    public decimal UnitPrice { get; set; }

    [Range(1, 99)]
    public int Quantity { get; set; }

    // client details
    [Required(ErrorMessage = "Client Name is required!")]
    public string ClientName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty; // email address

    [Phone]
    public string Phone { get; set; } = string.Empty; // phone number
    public string Address { get; set; } = string.Empty;


  }
}