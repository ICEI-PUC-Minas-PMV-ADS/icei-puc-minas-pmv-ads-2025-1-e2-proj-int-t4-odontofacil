using Microsoft.EntityFrameworkCore;
using OdontoFacil.Models.Data;

namespace OdontoFacil.Data;

public partial class OdontoFacilDbContext : DbContext
{

    public OdontoFacilDbContext(DbContextOptions<OdontoFacilDbContext> options) : base(options)
    {
    }

    protected OdontoFacilDbContext()
    {
    }

    public virtual DbSet<MedicalHistoryItem> MedicalHistoryItems { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Helper> Helpers { get; set; }

    public virtual DbSet<HealthPlan> HealthPlans { get; set; }

    public virtual DbSet<Dentist> Dentists { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<DentistScheduleAvailability> DentistScheduleAvailability { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<ExamRequest> ExamRequests { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<AnamnesisQuestion> AnamnesisQuestions { get; set; }

    public virtual DbSet<AnamnesisAnswer> AnamnesisAnswers { get; set; }
    
    public virtual DbSet<Note> Notes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Dentist>(entity =>
        {
            entity
                .HasMany(d => d.Specialties)
                .WithMany(p => p.Dentists)
                .UsingEntity<Dictionary<string, object>>(
                    "EspecialidadeDentistum",
                    r => r.HasOne<Specialty>().WithMany()
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Especialidade_Dentista_id_especialidade_fkey"),
                    l => l.HasOne<Dentist>().WithMany()
                        .HasForeignKey("IdDentista")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Especialidade_Dentista_id_dentista_fkey"),
                    j =>
                    {
                        j.HasKey("IdDentista", "IdEspecialidade").HasName("Especialidade_Dentista_pkey");
                        j.ToTable("Especialidade_Dentista");
                        j.IndexerProperty<string>("IdDentista")
                            .HasColumnType("character varying")
                            .HasColumnName("id_dentista");
                        j.IndexerProperty<string>("IdEspecialidade")
                            .HasColumnType("character varying")
                            .HasColumnName("id_especialidade");
                    });
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasMany(d => d.MedicalHistory).WithMany(p => p.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "PacienteAntecedente",
                    r => r.HasOne<MedicalHistoryItem>().WithMany()
                        .HasForeignKey("IdAntecedente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Paciente_Antecedente_id_antecedente_fkey"),
                    l => l.HasOne<Patient>().WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Paciente_Antecedente_id_paciente_fkey"),
                    j =>
                    {
                        j.HasKey("IdPaciente", "IdAntecedente").HasName("Paciente_Antecedente_pkey");
                        j.ToTable("Paciente_Antecedente");
                        j.IndexerProperty<string>("IdPaciente")
                            .HasColumnType("character varying")
                            .HasColumnName("id_paciente");
                        j.IndexerProperty<string>("IdAntecedente")
                            .HasColumnType("character varying")
                            .HasColumnName("id_antecedente");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
