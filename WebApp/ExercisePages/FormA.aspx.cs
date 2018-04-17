using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Star_TEDSystem.BLL;
using Star_TED.Data.Entities;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebApp.ExercisePages
{
    public partial class FormA : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();

            if (!Page.IsPostBack)
            {
                SchoolDataBind();
            }
        }
        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
        }

        protected void SchoolDataBind()
        {
            //setup user friendly error handling
            try
            {
                //the web page needs to access the BLL class method
                //   to obtain its data
                SchoolController sysmgr = new SchoolController();
                //get the actual data
                List<School> info = sysmgr.School_List();

                //sort a data collection, you decide which field to
                //     sort; normally this is the DataTextField property
                // x and y represent any two instances in your collection
                // => (lamda sign) basically says "do the following
                // following the lamda sign, indicate what is to be done
                // x.property.CompareTo(y.property) is an ascending sort
                // y.property.CompareTo(x.property) is an descending sort
                info.Sort((x, y) => x.SchoolName.CompareTo(y.SchoolName));

                //inform control of the data source
                SchoolList.DataSource = info;
                //set the DisplayText and ValueText fields to the
                //    appropriate Property names in the Entity
                SchoolList.DataValueField = "SchoolCode";
                SchoolList.DataTextField = "SchoolName";


                //physically attach data to control

                SchoolList.DataBind();

                //add a prompt line to the start of the ddl control
                SchoolList.Items.Insert(0, "select ...");
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                if (updateException.InnerException != null)
                {
                    errormsgs.Add(updateException.InnerException.Message.ToString());
                }
                else
                {
                    errormsgs.Add(updateException.Message);
                }
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        errormsgs.Add(validationError.ErrorMessage);
                    }
                }
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void PSearch_Click(object send, EventArgs e)
        {
            if (ProgramList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a program to search.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {
                try
                {
                    ProgramController sysmgr = new ProgramController();
                        
                }
            }
        }
       




        protected void Search_Click(object sender, EventArgs e)
        {
            //does my search value exist
            //search values may come from textboxes, dropdownlists,
            //    radiobuttonlists, etc.
            //check to see if you have a search value
            if (SchoolList.SelectedIndex == 0)
            {
                //ProductList has a prompt line at index 0
                errormsgs.Add("Select a school to search.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {
                //product was selected

                //check any other requirements that may be part
                //   of your search criteria

                //if all is good, do a standard pattern lookup
                try
                {




                    ProgramController sysmgr = new ProgramController();
                    //get the actual data
                    List<Program> info = sysmgr.Product_FindBySchool(SchoolList.SelectedValue);

                    //sort a data collection, you decide which field to
                    //     sort; normally this is the DataTextField property
                    // x and y represent any two instances in your collection
                    // => (lamda sign) basically says "do the following
                    // following the lamda sign, indicate what is to be done
                    // x.property.CompareTo(y.property) is an ascending sort
                    // y.property.CompareTo(x.property) is an descending sort
                    info.Sort((x, y) => x.ProgramName.CompareTo(y.ProgramName));

                    //inform control of the data source
                    ProgramList.DataSource = info;
                    //set the DisplayText and ValueText fields to the
                    //    appropriate Property names in the Entity
                    ProgramList.DataValueField = "ProgramID";
                    ProgramList.DataTextField = "ProgramName";


                    //physically attach data to control

                    ProgramList.DataBind();
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }
        }

        protected void ProgramList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}