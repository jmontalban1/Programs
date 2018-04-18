using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Star_TED.Data.Entities;
using Star_TEDSystem.DAL;
using System.Data.SqlClient;
#endregion


namespace Star_TEDSystem.BLL
{
    public class ProgramController
    {
        public List<Program> Program_List()
        {
            using (var context = new Star_TEDContext())
            {
                return context.Programs.ToList();
            }
        }

        public Program Program_Get(string schoolcode)
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
        public Program SchoolProgram_Get(int programid)
        {
            using (var context = new Star_TEDContext())
            {
                //we will use the EntityFramework extension method
                //   .Find()
                //this method takes a primary key value and searches
                //   the associated sql table for that primary key
                return context.Programs.Find(programid);
            }
        }



        public List<Program> Programs_FindBySchool(string schoolid)
        {
            using (var context = new Star_TEDContext())
            {
                var results = context.Database.SqlQuery<Program>(
                    "Programs_FindBySchool @PartialName",
                    new SqlParameter("PartialName", schoolid));
                return results.ToList();
            }
        }

        //Add Method
        public int Program_Add(Program item)
        {
            //input is an instance of all data for an entity
            //one could send in individual values in separate
            //    parameters BUT eventaully, they would need
            //    to be place in an instance of the entity
            //changes to the database should be done in a transaction
            using (var context = new Star_TEDContext())
            {
                //stage new record to DbSet<T> for commitment to 
                //    the database
                //the new record is not YET physically on the 
                //    database

                context.Programs.Add(item);

                //commit the staged record to the database table
                //if this statement is NOT executed then the
                //    insert is not completed on the database table (Rollback)
                //the new identity value is created on the successful
                //    execution of the statement
                //the identity value is NOT available until the execution
                //    of the statement is complete
                //during execution of this statemtent ANY entity validation
                //    annotation is executed
                context.SaveChanges();

                //optionally one could return the new identity value
                //    after the SaveChanges has been done
                return item.ProgramID;
            }
        }

        public int Program_Update(Program item)
        {
            //if you wish to return the number of rows affected
            //   your rdt should be an int; otherwise use a void

            //action is done as a transaction
            using (var context = new Star_TEDContext())
            {
                //stage the ENTIRE record for saving
                //all fields are altered
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                //capture the number of rows affected for the update
                //   commit and return
                return context.SaveChanges();
            }
        }

        public int Program_Delete(int schoolcode)
        {
            //if you wish to return the number of rows affected
            //   your rdt should be an int; otherwise use a void

            using (var context = new Star_TEDContext())
            {

                var existing = context.Programs.Find(schoolcode);
                context.Programs.Remove(existing);


                return context.SaveChanges();
            }
        }
    }
}
