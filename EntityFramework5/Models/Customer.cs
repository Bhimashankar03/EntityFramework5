using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework5.Models;

public partial class Customer
{
    public int Sno { get; set; }
    [Required]
    [Display(Name="Customer Name")]
    public string? Name { get; set; }
    [Required]
    [Display(Name="Email Id")]
    public string? Email { get; set; }
    [Required]
    [Display(Name="Mobile No")]
    public string? MobNo { get; set; }

    public string? Address { get; set; }
}
