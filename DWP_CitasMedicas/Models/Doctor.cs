using System;
using System.Collections.Generic;

namespace DWP_CitasMedicas.Models;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<Agenda> Agenda { get; set; } = new List<Agenda>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
