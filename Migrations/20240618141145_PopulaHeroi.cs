using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulaHeroi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into hero_table(Name,Power,StatusAtivo) values('fulano', 'voar', true)");
            migrationBuilder.Sql("insert into hero_table(Name,Power,StatusAtivo) values('Logan', 'carcaju', true)");
            migrationBuilder.Sql("insert into hero_table(Name,Power,StatusAtivo) values('ciclope', 'laser', true)");
            migrationBuilder.Sql("insert into hero_table(Name,Power,StatusAtivo) values('Charles X', 'psiquico', false)");
            migrationBuilder.Sql("insert into hero_table(Name,Power,StatusAtivo) values('Fera', 'besta', false)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from hero_table");
        }
    }
}
