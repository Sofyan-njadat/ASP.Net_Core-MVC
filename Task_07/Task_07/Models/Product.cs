using System;
using System.Collections.Generic;

namespace Task_07.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }
}
