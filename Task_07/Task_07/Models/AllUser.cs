using System;
using System.Collections.Generic;

namespace Task_07.Models;

public partial class AllUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }
}
