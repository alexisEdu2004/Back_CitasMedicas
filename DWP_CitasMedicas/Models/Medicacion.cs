using System;
using System.Collections.Generic;

namespace DWP_CitasMedicas.Models;

public partial class Medicacion
{
    public int IdMedicacion { get; set; }

    public int IdPaciente { get; set; }

    public string? Medicamento { get; set; }

    public TimeSpan? Horario { get; set; }

    public string? Dosis { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
