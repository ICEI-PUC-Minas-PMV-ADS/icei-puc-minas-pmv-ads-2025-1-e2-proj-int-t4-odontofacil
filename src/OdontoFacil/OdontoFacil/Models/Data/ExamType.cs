using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
namespace OdontoFacil.Models.Data;

[Table("Tipo_Exame")] 
public partial class ExamType
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString(); 
    [Column("descricao")]
    public string Description { get; set; } = null!; 

    public virtual ICollection<ExamRequest> ExamRequests { get; set; } = [];
}
