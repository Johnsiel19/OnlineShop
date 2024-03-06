﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopApi.Models;

[Index("Email", Name = "UQ__Customer__A9D10534C2251232", IsUnique = true)]
public partial class Customers
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(100)]
    public string Lastname { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(100)]
    public string Phone { get; set; }

    [StringLength(100)]
    public string Direccion { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string ClientType { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Password { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}