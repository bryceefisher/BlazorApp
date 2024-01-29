using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Style { get; set; } = null!;

    public double? OriginalGravity { get; set; }

    public double FinalGravity { get; set; }

    public double Ibu { get; set; }

    public double Abv { get; set; }

    public int YeastId { get; set; }

    public double? YeastAmount { get; set; }

    public double? YeastViability { get; set; }

    public int? MashTemp { get; set; }

    public double? WaterRatio { get; set; }

    public double? AmountOfWater { get; set; }

    public double Color { get; set; }

    public virtual ICollection<Fermentablepair> Fermentablepairs { get; set; } = new List<Fermentablepair>();

    public virtual ICollection<Hopaddition> Hopadditions { get; set; } = new List<Hopaddition>();

    public virtual Yeast Yeast { get; set; } = null!;
}
