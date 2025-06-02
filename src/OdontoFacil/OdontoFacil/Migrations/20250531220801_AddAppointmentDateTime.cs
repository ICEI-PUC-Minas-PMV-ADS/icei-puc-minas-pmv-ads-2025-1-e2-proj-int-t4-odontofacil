using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoFacil.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antecedente",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecedente", x => x.id);
                });

            /* migrationBuilder.CreateTable(
                 name: "Convenio",
                 columns: table => new
                 {
                     id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                     nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Convenio", x => x.id);
                 }); */ 

            /* //migrationBuilder.CreateTable(
            //    name: "Endereco",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Endereco", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Especialidade",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Especialidade", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Pergunta_Anamnese",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Pergunta_Anamnese", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Tipo_Exame",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tipo_Exame", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Usuario",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Usuario", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Auxiliar",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Auxiliar", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Auxiliar_Usuario_id",
            //            column: x => x.id,
            //            principalTable: "Usuario",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Dentista",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        cro = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Dentista", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Dentista_Usuario_id",
            //            column: x => x.id,
            //            principalTable: "Usuario",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Paciente",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_convenio = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        data_nascimento = table.Column<DateOnly>(type: "date", nullable: true),
            //        telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        id_endereco = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        sexo = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Paciente", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Paciente_Convenio_id_convenio",
            //            column: x => x.id_convenio,
            //            principalTable: "Convenio",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Paciente_Endereco_id_endereco",
            //            column: x => x.id_endereco,
            //            principalTable: "Endereco",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Paciente_Usuario_id",
            //            column: x => x.id,
            //            principalTable: "Usuario",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Especialidade_Dentista",
            //    columns: table => new
            //    {
            //        id_dentista = table.Column<string>(type: "character varying", nullable: false),
            //        id_especialidade = table.Column<string>(type: "character varying", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("Especialidade_Dentista_pkey", x => new { x.id_dentista, x.id_especialidade });
            //        table.ForeignKey(
            //            name: "Especialidade_Dentista_id_dentista_fkey",
            //            column: x => x.id_dentista,
            //            principalTable: "Dentista",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "Especialidade_Dentista_id_especialidade_fkey",
            //            column: x => x.id_especialidade,
            //            principalTable: "Especialidade",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HorarioAtendimento",
            //    columns: table => new
            //    {
            //        id_dentista = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        dia_semana = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        hora_inicial = table.Column<int>(type: "int", nullable: false),
            //        hora_final = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HorarioAtendimento", x => new { x.id_dentista, x.dia_semana });
            //        table.ForeignKey(
            //            name: "FK_HorarioAtendimento_Dentista_id_dentista",
            //            column: x => x.id_dentista,
            //            principalTable: "Dentista",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Anotacoes",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        data_criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        id_paciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_dentista = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Anotacoes", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Anotacoes_Dentista_id_dentista",
            //            column: x => x.id_dentista,
            //            principalTable: "Dentista",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Anotacoes_Paciente_id_paciente",
            //            column: x => x.id_paciente,
            //            principalTable: "Paciente",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Atendimento",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_dentista = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_paciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        data = table.Column<DateOnly>(type: "date", nullable: false),
            //        data_hora = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Atendimento", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Atendimento_Dentista_id_dentista",
            //            column: x => x.id_dentista,
            //            principalTable: "Dentista",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Atendimento_Paciente_id_paciente",
            //            column: x => x.id_paciente,
            //            principalTable: "Paciente",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Paciente_Antecedente",
            //    columns: table => new
            //    {
            //        id_paciente = table.Column<string>(type: "character varying", nullable: false),
            //        id_antecedente = table.Column<string>(type: "character varying", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("Paciente_Antecedente_pkey", x => new { x.id_paciente, x.id_antecedente });
            //        table.ForeignKey(
            //            name: "Paciente_Antecedente_id_antecedente_fkey",
            //            column: x => x.id_antecedente,
            //            principalTable: "Antecedente",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "Paciente_Antecedente_id_paciente_fkey",
            //            column: x => x.id_paciente,
            //            principalTable: "Paciente",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Pedido_Exame",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        tipo = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_paciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_dentista = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        data_solicitacao = table.Column<DateOnly>(type: "date", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Pedido_Exame", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Pedido_Exame_Dentista_id_dentista",
            //            column: x => x.id_dentista,
            //            principalTable: "Dentista",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Pedido_Exame_Paciente_id_paciente",
            //            column: x => x.id_paciente,
            //            principalTable: "Paciente",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Pedido_Exame_Tipo_Exame_tipo",
            //            column: x => x.tipo,
            //            principalTable: "Tipo_Exame",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Resposta_Anamnese",
            //    columns: table => new
            //    {
            //        id_pergunta = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_paciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        resposta = table.Column<bool>(type: "bit", nullable: false),
            //        resposta_textual = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Resposta_Anamnese", x => new { x.id_pergunta, x.id_paciente });
            //        table.ForeignKey(
            //            name: "FK_Resposta_Anamnese_Paciente_id_paciente",
            //            column: x => x.id_paciente,
            //            principalTable: "Paciente",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Resposta_Anamnese_Pergunta_Anamnese_id_pergunta",
            //            column: x => x.id_pergunta,
            //            principalTable: "Pergunta_Anamnese",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Resultado_Exame",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        id_pedido_exame = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        data = table.Column<DateOnly>(type: "date", nullable: false),
            //        laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Resultado_Exame", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Resultado_Exame_Pedido_Exame_id_pedido_exame",
            //            column: x => x.id_pedido_exame,
            //            principalTable: "Pedido_Exame",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Anotacoes_id_dentista",
            //    table: "Anotacoes",
            //    column: "id_dentista");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Anotacoes_id_paciente",
            //    table: "Anotacoes",
            //    column: "id_paciente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Atendimento_id_dentista",
            //    table: "Atendimento",
            //    column: "id_dentista");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Atendimento_id_paciente",
            //    table: "Atendimento",
            //    column: "id_paciente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Especialidade_Dentista_id_especialidade",
            //    table: "Especialidade_Dentista",
            //    column: "id_especialidade");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Paciente_id_convenio",
            //    table: "Paciente",
            //    column: "id_convenio");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Paciente_id_endereco",
            //    table: "Paciente",
            //    column: "id_endereco",
            //    unique: true,
            //    filter: "[id_endereco] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Paciente_Antecedente_id_antecedente",
            //    table: "Paciente_Antecedente",
            //    column: "id_antecedente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Pedido_Exame_id_dentista",
            //    table: "Pedido_Exame",
            //    column: "id_dentista");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Pedido_Exame_id_paciente",
            //    table: "Pedido_Exame",
            //    column: "id_paciente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Pedido_Exame_tipo",
            //    table: "Pedido_Exame",
            //    column: "tipo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Resposta_Anamnese_id_paciente",
            //    table: "Resposta_Anamnese",
            //    column: "id_paciente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Resultado_Exame_id_pedido_exame",
            //    table: "Resultado_Exame",
            //    column: "id_pedido_exame"); */
        } 

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotacoes");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Auxiliar");

            migrationBuilder.DropTable(
                name: "Especialidade_Dentista");

            migrationBuilder.DropTable(
                name: "HorarioAtendimento");

            migrationBuilder.DropTable(
                name: "Paciente_Antecedente");

            migrationBuilder.DropTable(
                name: "Resposta_Anamnese");

            migrationBuilder.DropTable(
                name: "Resultado_Exame");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Antecedente");

            migrationBuilder.DropTable(
                name: "Pergunta_Anamnese");

            migrationBuilder.DropTable(
                name: "Pedido_Exame");

            migrationBuilder.DropTable(
                name: "Dentista");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Tipo_Exame");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
