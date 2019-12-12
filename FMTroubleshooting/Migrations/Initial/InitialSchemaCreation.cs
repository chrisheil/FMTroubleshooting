using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMTroubleshooting.Migrations.Initial
{
    [Migration(1)]
    public sealed class InitialSchemaCreation : Migration
    {
        public override void Down() => throw new NotImplementedException();

        public override void Up()
        {
            Execute.EmbeddedScript("InitialSchema.sql");
        }
    }
}
