using System;
using System.Collections.Generic;

namespace DWP_CitasMedicas.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int Idusuario { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Estatura { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? NumeroTelefono { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;

    public virtual ICollection<Medicacion> Medicacions { get; set; } = new List<Medicacion>();
}
