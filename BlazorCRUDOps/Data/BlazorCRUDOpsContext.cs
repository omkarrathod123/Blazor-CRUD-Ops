using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorCRUDOps.Shared;

namespace BlazorCRUDOps.Data
{
    public class BlazorCRUDOpsContext : DbContext
    {
        public BlazorCRUDOpsContext (DbContextOptions<BlazorCRUDOpsContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorCRUDOps.Shared.Product> Product { get; set; } = default!;
    }
}
