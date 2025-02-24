using System;
using System.Collections.Generic;

namespace Task_06.Models;

public partial class Department
{
    public int Id { get; set; }

    public string DepName { get; set; } = null!;

    public string? ManagerName { get; set; }

    public decimal? Budget { get; set; }

    public DateOnly? EstablishedDate { get; set; }
}
