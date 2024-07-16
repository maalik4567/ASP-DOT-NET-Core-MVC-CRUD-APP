using System;
using System.Collections.Generic;

namespace Crud_App_ASP_NETCoreMVC.Models;

public partial class EmpTb
{
    public string? EmpName { get; set; }

    public int? Age { get; set; }

    public string? Designation { get; set; }

    public int? Salary { get; set; }

    public int EmpId { get; set; }
}
