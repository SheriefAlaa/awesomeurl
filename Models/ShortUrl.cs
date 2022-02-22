using System.ComponentModel.DataAnnotations;

namespace AwesomeUrl.Models
{
  public class ShortURL
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? Url { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}
