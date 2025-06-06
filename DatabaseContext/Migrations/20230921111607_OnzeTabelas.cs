using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseContext.Migrations
{
    /// <inheritdoc />
    public partial class OnzeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logons");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Niveis");

            migrationBuilder.CreateTable(
                name: "AppPortifolio",
                columns: table => new
                {
                    AppId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AppPorti__8E2CF7F9661FC2B9", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "BillModel",
                columns: table => new
                {
                    BillId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true, comment: "Tipo do meio de pagamento..."),
                    UrlAPI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BillMode__11F2FC6A3A430D14", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "CountryModel",
                columns: table => new
                {
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ISO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ISO3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    NomeFormal = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CountryM__10D1609F98E06333", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoleMode__8AFACE1A7677E852", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "StateModel",
                columns: table => new
                {
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IBGECode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CountryModel_CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StateMod__C3BA3B3ADDB287E7", x => x.StateId);
                    table.ForeignKey(
                        name: "FK__StateMode__Count__5165187F",
                        column: x => x.CountryModel_CountryId,
                        principalTable: "CountryModel",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GivenName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    RoleModel_RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserMode__1788CC4C16F1E003", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__UserModel__RoleM__534D60F1",
                        column: x => x.RoleModel_RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "CityModel",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IBGE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    StateModel_StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CityMode__F2D21B76EF796D0B", x => x.CityId);
                    table.ForeignKey(
                        name: "FK__CityModel__State__4AB81AF0",
                        column: x => x.StateModel_StateId,
                        principalTable: "StateModel",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserLoginId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuthenticateResult = table.Column<bool>(type: "bit", nullable: true),
                    LOG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserModel_UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserLogi__107D568C5EEFC7AD", x => x.UserLoginId);
                    table.ForeignKey(
                        name: "FK__UserLogin__UserM__52593CB8",
                        column: x => x.UserModel_UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationModel",
                columns: table => new
                {
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Razao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumberAddr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    District = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    EmailContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CityModel_CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__807E7679005F241C", x => new { x.OrganizationId, x.CNPJ });
                    table.ForeignKey(
                        name: "FK__Organizat__CityM__4E88ABD4",
                        column: x => x.CityModel_CityId,
                        principalTable: "CityModel",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "SignatureModel",
                columns: table => new
                {
                    SignatureId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeySignature = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OrganizationModel_OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    BillModel_BillId = table.Column<long>(type: "bigint", nullable: false),
                    AppId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationModel_CNPJ = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Signatur__3DCA57A9E0E50FD6", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK__SignatureModel__5070F446",
                        columns: x => new { x.OrganizationModel_OrganizationId, x.OrganizationModel_CNPJ },
                        principalTable: "OrganizationModel",
                        principalColumns: new[] { "OrganizationId", "CNPJ" });
                    table.ForeignKey(
                        name: "FK__Signature__BillM__4F7CD00D",
                        column: x => x.BillModel_BillId,
                        principalTable: "BillModel",
                        principalColumn: "BillId");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentModel",
                columns: table => new
                {
                    EnrollmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModel_UserId = table.Column<long>(type: "bigint", nullable: false),
                    AppPortifolio_AppId = table.Column<long>(type: "bigint", nullable: false),
                    SignatureModel_SignatureId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__37202B96D10BCCAE", x => new { x.EnrollmentId, x.UserModel_UserId });
                    table.ForeignKey(
                        name: "FK__Enrollmen__AppPo__4BAC3F29",
                        column: x => x.AppPortifolio_AppId,
                        principalTable: "AppPortifolio",
                        principalColumn: "AppId");
                    table.ForeignKey(
                        name: "FK__Enrollmen__Signa__4CA06362",
                        column: x => x.SignatureModel_SignatureId,
                        principalTable: "SignatureModel",
                        principalColumn: "SignatureId");
                    table.ForeignKey(
                        name: "FK__Enrollmen__UserM__4D94879B",
                        column: x => x.UserModel_UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityModel_StateModel_StateId",
                table: "CityModel",
                column: "StateModel_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentModel_AppPortifolio_AppId",
                table: "EnrollmentModel",
                column: "AppPortifolio_AppId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentModel_SignatureModel_SignatureId",
                table: "EnrollmentModel",
                column: "SignatureModel_SignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentModel_UserModel_UserId",
                table: "EnrollmentModel",
                column: "UserModel_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModel_CityModel_CityId",
                table: "OrganizationModel",
                column: "CityModel_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureModel_BillModel_BillId",
                table: "SignatureModel",
                column: "BillModel_BillId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureModel_OrganizationModel_OrganizationId_OrganizationModel_CNPJ",
                table: "SignatureModel",
                columns: new[] { "OrganizationModel_OrganizationId", "OrganizationModel_CNPJ" });

            migrationBuilder.CreateIndex(
                name: "IX_StateModel_CountryModel_CountryId",
                table: "StateModel",
                column: "CountryModel_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserModel_UserId",
                table: "UserLogin",
                column: "UserModel_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_RoleModel_RoleId",
                table: "UserModel",
                column: "RoleModel_RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentModel");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "AppPortifolio");

            migrationBuilder.DropTable(
                name: "SignatureModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "OrganizationModel");

            migrationBuilder.DropTable(
                name: "BillModel");

            migrationBuilder.DropTable(
                name: "RoleModel");

            migrationBuilder.DropTable(
                name: "CityModel");

            migrationBuilder.DropTable(
                name: "StateModel");

            migrationBuilder.DropTable(
                name: "CountryModel");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelAcesso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UsrName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastLogon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberTentatives = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logons_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logons_UserId",
                table: "Logons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NivelId",
                table: "Usuarios",
                column: "NivelId");
        }
    }
}
