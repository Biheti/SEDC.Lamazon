﻿namespace SEDC.Lamazon.Services.ViewModels.Product;

public class ProductViewModel
{
    public int Id { get; set; } 
    public string Name { get; set; }    
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }

    public string ProductCategoryName { get; set; }
}
