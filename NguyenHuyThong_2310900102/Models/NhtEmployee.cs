using System;
using System.Collections.Generic;

namespace NguyenHuyThong_2310900102.Models;

public partial class NhtEmployee
{
    public string NhtEmpId { get; set; } = null!;

    public string? NhtEmpName { get; set; }

    public string? NhtEmpLevel { get; set; }

    public DateOnly? NhtEmpStartDate { get; set; }

    public bool? NhtEmpStatus { get; set; }
}
