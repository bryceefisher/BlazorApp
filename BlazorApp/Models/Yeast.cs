using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Yeast
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lab { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Form { get; set; } = null!;

    public string Flocculation { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
