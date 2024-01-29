using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Fermentable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public double Color { get; set; }

    public double PotentialGravity { get; set; }

    public double MaxInBatch { get; set; }

    public virtual ICollection<Fermentablepair> Fermentablepairs { get; set; } = new List<Fermentablepair>();
}
