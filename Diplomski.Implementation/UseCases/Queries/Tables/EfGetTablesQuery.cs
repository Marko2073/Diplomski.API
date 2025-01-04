using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Table;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Tables
{
    public class EfGetTablesQuery : EfUseCase, IGetTablesQuery
    {
        public EfGetTablesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 200;

        public string Name => "Get Tables from database";

        public string Description => "Get Tables from database";

        public IEnumerable<TableDto> Execute(BaseSearch search)
        {

            var tables = new List<TableDto>();

            var query = Context.GetType().GetProperties().Where(x => x.PropertyType.Name.Contains("DbSet")).ToList();

            foreach (var table in query)
            {

                tables.Add(new TableDto
                {
                    Name = table.Name
                });

            }
            return tables;
            

                
        }

    }
}
