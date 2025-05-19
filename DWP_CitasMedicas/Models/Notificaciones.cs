using System;
using System.Collections.Generic;

namespace DWP_CitasMedicas.Models;

public partial class Notificaciones
{
    public int IdNotificacion { get; set; }

    public int IdUsuario { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public bool? Visto { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
