using System;
using System.Collections.Generic;

namespace DWP_CitasMedicas.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int IdPaciente { get; set; }

    public int IdDoctor { get; set; }

    public string? TipoServicio { get; set; }

    public DateTime? FechaCita { get; set; }

    public TimeSpan? HoraCita { get; set; }

    public string? EstadoCita { get; set; }

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
