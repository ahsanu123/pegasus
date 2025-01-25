using System;
using System.Collections.Generic;
using FluentMigrator;
using WingtipToys.Models;
using WingtipToys.Builder.Application;

namespace WingtipToys.WintipMigration
{
    public class ModelMigrationList : MigrationBase
    {
        private List<Type> listModel = new List<Type> { typeof(Dummy), typeof(Product) };

        public static List<string> listExcludedType = new List<string>
        {
            nameof(System.Collections),
        };

        public void MigrationDown(Migration migration)
        {
            this.listModel.ForEach((type) => migration.DeleteTableIfExists(type));
        }

        public void MigrationUp(Migration migration)
        {
            this.listModel.ForEach(
                (type) => migration.ConvertModelToMigration(type, listExcludedType)
            );
        }

        public void GenerateForeignKey(Migration migration)
        {
            this.listModel.ForEach((type) => migration.GenerateForeignKey(type));
        }
    }
}
