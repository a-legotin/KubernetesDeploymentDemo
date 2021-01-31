using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CustomerService.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "Guid", "LastName", "UpdatedTime" },
                values: new object[,]
                {
                    { 1L, "jsibley0@wp.com", "Justis", "Bigender", new Guid("24183b3d-196e-4695-887b-606d72ab042a"), "Sibley", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, "zsansomr@php.net", "Zorina", "Male", new Guid("ea6be99f-7279-4782-b54f-3ecfa3e2d2c1"), "Sansom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, "rventums@163.com", "Ravid", "Female", new Guid("7cdf841e-31db-4aa6-a13d-fe19603b4c43"), "Ventum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, "wpidgint@redcross.org", "Willie", "Genderqueer", new Guid("c048abcc-cb27-4c17-ae20-c238750d1d18"), "Pidgin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, "lwasielewskiu@merriam-webster.com", "Lora", "Male", new Guid("364c5ca3-e642-44ff-8e53-6365e46b728a"), "Wasielewski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, "kgapperv@tuttocitta.it", "Knox", "Genderfluid", new Guid("79d39fe7-a46d-4f60-bb55-3d3d78491467"), "Gapper", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, "fbartolommeow@issuu.com", "Fulton", "Male", new Guid("3768d14b-45f7-4dfb-b0d7-0ccf5c0d47d5"), "Bartolommeo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, "sklebesx@opera.com", "Simona", "Genderfluid", new Guid("318b7966-a974-4b8c-9011-67d220f9a1ca"), "Klebes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, "kbulchy@goo.gl", "Kelci", "Genderfluid", new Guid("d2eb436c-f88b-4af4-a3ba-64c13cf18823"), "Bulch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, "lricketz@networksolutions.com", "Lonnie", "Genderfluid", new Guid("232dad51-34b1-4648-be8f-2fb21e025c69"), "Ricket", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, "nmilthorpe10@utexas.edu", "Norean", "Genderfluid", new Guid("479ed05f-85d5-48e2-8b70-4be1ef1e4228"), "Milthorpe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, "showlett11@yandex.ru", "Sue", "Genderfluid", new Guid("e35caae3-ecec-46f8-a4fb-4aa82ed13637"), "Howlett", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39L, "sleser12@theglobeandmail.com", "Sidnee", "Bigender", new Guid("d491b9c3-b631-4a17-b799-e94e4e0cb94f"), "Leser", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40L, "cstrettell13@123-reg.co.uk", "Cynthie", "Agender", new Guid("89e58be5-9156-44c2-8ccb-4490a57823ee"), "Strettell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41L, "tdoggett14@amazon.co.uk", "Tome", "Bigender", new Guid("2b8115fc-4396-430e-ab7c-c344d2fe8765"), "Doggett", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42L, "tpaget15@rakuten.co.jp", "Tiertza", "Genderfluid", new Guid("7b1f767a-0ec9-48a9-9f26-6b488b85d068"), "Paget", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43L, "wmedford16@baidu.com", "Wolfie", "Agender", new Guid("11e49fce-0513-4280-a3bc-a6907a39ef85"), "Medford", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44L, "gkeuneke17@reference.com", "Galvin", "Agender", new Guid("ad1f0ae9-af27-48c8-8754-676021fae2c7"), "Keuneke", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45L, "lpatis18@multiply.com", "Lainey", "Genderfluid", new Guid("e486a6c4-6d5b-4c36-9ec7-1b409da071e0"), "Patis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46L, "dbrumbye19@is.gd", "Domini", "Genderfluid", new Guid("40bc03c7-8aaa-449f-9d66-2512450528c8"), "Brumbye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47L, "pmacdougall1a@w3.org", "Prentiss", "Bigender", new Guid("1ca792eb-bda3-497b-9de7-5b9c528d35a4"), "MacDougall", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48L, "scolaco1b@weibo.com", "Sheri", "Agender", new Guid("43212be8-e609-44b5-b94f-a1fc1f3009f3"), "Colaco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, "achickenq@blog.com", "Adolph", "Genderqueer", new Guid("48954833-1a02-46a3-991d-8740fa54044f"), "Chicken", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, "drikkardp@yahoo.co.jp", "Donnell", "Female", new Guid("6372ee25-9041-4caf-a60c-edfed53e0c83"), "Rikkard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, "dbrecheo@stanford.edu", "Darcee", "Agender", new Guid("606d07b8-f102-49a3-a1fe-2b77b9938307"), "Breche", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, "spopworthn@cbslocal.com", "Selina", "Non-binary", new Guid("4e90733a-d887-4c03-b91f-f22167ffc3a3"), "Popworth", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "nhubbart1@amazon.co.uk", "Nev", "Male", new Guid("7401a43e-46a4-4d3e-9f2c-a53f4fa546ca"), "Hubbart", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "rsteynor2@washingtonpost.com", "Richardo", "Female", new Guid("f47d70a5-92d9-4e40-92ab-901625f08091"), "Steynor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "gdeeprose3@studiopress.com", "Guenevere", "Female", new Guid("66e8fa52-f015-474c-9342-549347ffe69a"), "Deeprose", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "wallonby4@fotki.com", "Wynn", "Male", new Guid("5e586b3b-7ffc-4e39-bb41-0dca659e54cf"), "Allonby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, "abrede5@timesonline.co.uk", "Andre", "Non-binary", new Guid("92b6d64b-1335-4bb7-a58e-c0d4fecf0260"), "Brede", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "wmccotter6@bravesites.com", "Willdon", "Bigender", new Guid("b0312cfc-b42f-43fd-a9c2-59e2caafb02a"), "McCotter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, "mraymond7@howstuffworks.com", "Madlin", "Male", new Guid("4422eed3-c90d-4726-a20c-64fc2ca6a049"), "Raymond", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, "gespino8@ycombinator.com", "Garwin", "Male", new Guid("6a65484e-dc0c-4956-89d3-9b9104006974"), "Espino", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, "hstennes9@chicagotribune.com", "Hieronymus", "Non-binary", new Guid("7a566d8c-c64a-49d7-a107-25a1f6fa3668"), "Stennes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, "lmcgarrya@mtv.com", "Lacie", "Female", new Guid("4f76c895-e9b0-4036-b0f7-24ea07aff553"), "McGarry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49L, "msabbin1c@google.ca", "Millard", "Agender", new Guid("0f8054d2-cae5-4516-96db-2c3658d4bd79"), "Sabbin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, "rstembridgeb@webs.com", "Rosaline", "Agender", new Guid("f758423e-8547-468c-a898-fdd69958d79a"), "Stembridge", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, "sballind@smugmug.com", "Siffre", "Genderqueer", new Guid("82f10b12-695d-431f-8397-2a0eadccefbf"), "Ballin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, "apulhostere@springer.com", "Adelle", "Bigender", new Guid("039a9be8-b5d5-4640-9ecc-da09046ae53a"), "Pulhoster", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, "vmcgauhyf@dmoz.org", "Valeda", "Female", new Guid("35e642a5-13bc-4d1d-8a84-705e4532fdb1"), "McGauhy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, "hkubelkag@home.pl", "Horatia", "Bigender", new Guid("6990b88d-b5ae-4811-9603-4a920920ae76"), "Kubelka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, "ebangsh@networksolutions.com", "Emmalyn", "Genderfluid", new Guid("225521f6-ea2b-4e0c-be3a-c24d46ab83f5"), "Bangs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, "ahallardi@smh.com.au", "Andres", "Male", new Guid("d5f57e15-b2a7-4057-916f-731ab49a6f43"), "Hallard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, "jarensj@tripod.com", "Juditha", "Agender", new Guid("6c9d711d-59af-421c-b297-8bfb0a168362"), "Arens", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, "eisoldik@ebay.co.uk", "Ermentrude", "Female", new Guid("74a28896-ca74-4353-95ec-894c7c59244c"), "Isoldi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, "mcurpheyl@kickstarter.com", "Matty", "Polygender", new Guid("8cbde2d2-4e7c-4404-acac-fcb26b974d0f"), "Curphey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, "sjulyanm@so-net.ne.jp", "Sheffie", "Polygender", new Guid("ab13db04-1a86-4644-995f-7fed9e746fcd"), "Julyan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, "mishakc@huffingtonpost.com", "Mirna", "Non-binary", new Guid("a359d78f-d33a-4ec5-bc97-43bef6c0e895"), "Ishak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50L, "dskaif1d@so-net.ne.jp", "Dorelle", "Male", new Guid("2ff851dd-9954-463f-83c2-82d46205432a"), "Skaif", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
