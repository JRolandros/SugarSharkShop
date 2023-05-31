using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SugarShark.Application.Common;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.Tests
{
    public class SugarSharkInMemoryDbContext 
    {
        public static SugarSharkDbContext GetSugarSharkDbContext()
        {
            DbContextOptionsBuilder<SugarSharkDbContext> builder =new DbContextOptionsBuilder<SugarSharkDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(x => { x.Ignore(InMemoryEventId.TransactionIgnoredWarning); });

            var ctx = new SugarSharkDbContext(builder.Options);

            ctx.Database.EnsureCreated();

            return ctx;
        }
        
    }
}
