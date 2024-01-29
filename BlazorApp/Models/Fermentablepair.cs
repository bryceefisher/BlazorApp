using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Fermentablepair
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int FermentableId { get; set; }

    public double? Weight { get; set; }

    public virtual Fermentable Fermentable { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
