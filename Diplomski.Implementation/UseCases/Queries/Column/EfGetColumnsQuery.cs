using Diplomski.Application.UseCases.Queries.Column;
using Diplomski.DataAccess;
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

            var query = Context.GetType().GetProperties().Where(x => x.PropertyType.Name.Contains("DbSet")).ToList();

            foreach (var table in query)
            {
                if (table.Name == search)
                {
                    var tableType = table.PropertyType.GenericTypeArguments[0];
                    var tableProperties = tableType.GetProperties();

                    foreach (var property in tableProperties)
                    {
                        columns.Add(property.Name);
                    }
                }
            }

            return columns;
            
        }
    }
}
