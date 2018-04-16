using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using Star_TED.Data.Entities;
#endregion


namespace Star_TEDSystem.DAL
{
    internal class Star_TEDContext:DbContext
    {
        public Star_TEDContext():base("StarTedDb")
        {

        }
        public DbSet<School> Schools { get; set; } // entity has singular

        public DbSet<Program> Programs { get; set; }
    }
}
