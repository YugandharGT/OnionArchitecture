Login Functionality:
Asp.Net Core Identity - https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/identity/sample
Core 5.0 Example: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio

Skip Tables;

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Subject = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    From_Email = table.Column<string>(nullable: true),
                    To_Email = table.Column<string>(nullable: true),
                    Email_Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Subject);
                    table.UniqueConstraint("AK_Email_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Department = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });


Custom Build Events:
if $(ConfigurationName) == Release (
 copy /Y "$(TargetDir)" "DestPath"
 del "DestPath\*.pdb"
)
Using Batch Script:
if $(ConfigurationName) == Release (
for /r "$(TargetDir)" %%I in (*.dll *.json *.config *.xml) do copy "%%I" "D:\Technology\Dotnet-Projects\VS19\AutomaticPublish\OnionArchWebApi\"
)
