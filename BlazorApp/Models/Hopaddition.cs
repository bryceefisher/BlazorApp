using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Hopaddition
{
    public int Id { get; set; }

    public string Use { get; set; } = null!;

    public int? BoilTime { get; set; }

    public int? DryHopDays { get; set; }

    public string Form { get; set; } = null!;

    public double? Amount { get; set; }

    public int RecipeId { get; set; }

    public int HopId { get; set; }

    public virtual Hop Hop { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
