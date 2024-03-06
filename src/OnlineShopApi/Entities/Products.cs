﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopApi.Models;

public partial class Products
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(300)]
    public string Description { get; set; }

    [StringLength(100)]
    public string Provider { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? PurchasPrice { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? SalePrice { get; set; }

    public int? Stock { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    public int? CustomerId { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}