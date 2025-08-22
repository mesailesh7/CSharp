using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

public partial class Menu
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? MenuTitle { get; set; }

    [StringLength(300)]
    public string? Link { get; set; }

    [StringLength(20)]
    public string? Type { get; set; }
}
