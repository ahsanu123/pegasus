using FluentMigrator;

namespace WingtipToys.WintipMigration
{
    public interface MigrationBase
    {
        void MigrationUp(Migration migration);
        void MigrationDown(Migration migration);
        void GenerateForeignKey(Migration migration);
    }
}
