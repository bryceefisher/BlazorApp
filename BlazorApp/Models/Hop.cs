using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Hop
{
    public int Id { get; set; }

    public double AlphaAcid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hopaddition> Hopadditions { get; set; } = new List<Hopaddition>();
}
