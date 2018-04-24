﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Star_TED.Data.Entities;
using Star_TEDSystem.DAL;
using System.ComponentModel;
#endregion

namespace Star_TEDSystem.BLL
{
    [DataObject]
    public class SchoolController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<School> School_List()
        {
            using (var context = new Star_TEDContext())
            {
                return context.Schools.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Program School_Get(string schoolcode)
        {
            using (var context = new Star_TEDContext())
            {
                //we will use the EntityFramework extension method
                //   .Find()
                //this method takes a primary key value and searches
                //   the associated sql table for that primary key
                return context.Programs.Find(schoolcode);
            }
        }
    }
}
