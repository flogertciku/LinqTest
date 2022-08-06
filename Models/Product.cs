using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
public class Product
{
    [Key]
    public int ProductId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public string Category {get;set;}
    [Required]
    public double Price {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

