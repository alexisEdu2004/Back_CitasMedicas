using System;
using System.Collections.Generic;

namespace DWP_CitasMedicas.Models;

public partial class Agendum
{
    public int IdAgenda { get; set; }

    public int IdDoctor { get; set; }

    public string? DiaSemana { get; set; }

    public TimeSpan? Horario { get; set; }

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;
}
