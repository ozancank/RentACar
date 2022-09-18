namespace Application.Features.Models.Dtos;

public class CreateModelDto
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}