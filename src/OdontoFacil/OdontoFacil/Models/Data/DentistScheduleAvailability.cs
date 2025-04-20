using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OdontoFacil.Models.Data;

[PrimaryKey(nameof(DentistId), nameof(WeekDay))]
[Table("HorarioAtendimento")]
public partial class DentistScheduleAvailability
{
    [Column("id_dentista")]
    public required string DentistId { get; set; }

    [Column("dia_semana")]
    public required string WeekDay { get; set; }

    [Column("hora_inicial")]
    public int InitialHour { get; set; }

    [Column("hora_final")]
    public int EndingHour { get; set; }

    public virtual Dentist Dentists { get; set; } = null!;
}
