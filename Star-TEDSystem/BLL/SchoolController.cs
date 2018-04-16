using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Star_TED.Data.Entities;
using Star_TEDSystem.DAL;
#endregion

namespace Star_TEDSystem.BLL
{
    public class SchoolController
    {
        public List<School> School_List()
        {
            using (var context = new Star_TEDContext())
            {
                return context.Schools.ToList();
            }
        }
    }
}
