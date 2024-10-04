using System;
using System.Collections.Generic;

namespace Smz.Practice.Employee.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int Clave { get; set; }

    public string Nombre { get; set; } = null!;

    public string Paterno { get; set; } = null!;

    public string? Materno { get; set; }

    public decimal? Sueldo { get; set; }

    public DateOnly? Ingreso { get; set; }
}
