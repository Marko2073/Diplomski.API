using Diplomski.Application.UseCases.Queries.Column;
using Diplomski.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Column
{
    public class EfGetColumnsQuery : EfUseCase, IGetColumnsQuery
    {
        public EfGetColumnsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 201;

        public string Name => "Get Columns of Table";

        public string Description => "Get Columns of Table";

        public IEnumerable<string> Execute(string search)
        {
            var columns = new List<string>();

            // Prolazimo kroz sve entitete u DbContext
            var entityType = Context.Model.GetEntityTypes()
                .FirstOrDefault(e => e.GetTableName() == search); // Tražimo entitet sa imenom tabele

            if (entityType != null)
            {
                // Ako postoji odgovarajući entitet, uzimamo njegove kolone
                var tableProperties = entityType.GetProperties();

                foreach (var property in tableProperties)
                {
                    // Preskačemo kolone CreatedAt i UpdatedAt
                    if (property.Name.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase) ||
                        property.Name.Equals("UpdatedAt", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string columnName = property.Name;

                    columns.Add(columnName);

                    // Proveravamo da li naziv kolone sadrži "Id" na kraju
                    if (columnName.EndsWith("Id", StringComparison.OrdinalIgnoreCase) && columnName.Length > 2)
                    {
                        // Dodajemo novi naziv kao "Name"
                        var relatedColumnName = columnName.ToLower().Substring(0, columnName.Length - 2) + "Name";
                        columns.Add(relatedColumnName);
                    }
                }
            }

            return columns;
        }

    }
}
