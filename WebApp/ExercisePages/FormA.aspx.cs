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
                ProgramDataBind();
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

        protected void ProgramDataBind()
        {
            try
            {
                //the web page needs to access the BLL class method
                //   to obtain its data
                ProgramController sysmgr = new ProgramController();
                //get the actual data
                //List<Program> info = sysmgr.Program_List();

                //inform control of the data source
                //ProgramList.DataSource = info;
                //set the DisplayText and ValueText fields to the
                //    appropriate Property names in the Entity
                //ProgramList.DataTextField = "ProgramName";
                //ProgramList.DataValueField = "ProgramID";
                //physically attach data to control
                ProgramList.DataBind();

                //add a prompt line to the start of the ddl control
                ProgramList.Items.Insert(0, "select ...");
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

            //if (ProgramList.SelectedIndex == 0)
            //{
            //    //ProductList has a prompt line at index 0
            //    errormsgs.Add("Select a program to search.");
            //    LoadMessageDisplay(errormsgs, "alert alert-warning");
            //}
            //else
            //{ 
            try
            {
                ProgramController sysmgr = new ProgramController();
                Program info = sysmgr.SchoolProgram_Get(int.Parse(ProgramList.SelectedValue));


                ProgramID.Text = info.ProgramID.ToString();
                ProgramName.Text = info.ProgramName;
                DiplomaName.Text = info.DiplomaName;
                SchoolCode.Text = info.SchoolCode;
                Tuition.Text = info.Tuition.ToString();
                InternationalTuition.Text = info.InternationalTuition.ToString();
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
            //end of search

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
                    List<Program> info = sysmgr.Programs_FindBySchool(SchoolList.SelectedValue);

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
        } //end of search

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProgramID.Text = "";
            ProgramName.Text = "";
            DiplomaName.Text = "";
            SchoolCode.Text = "";
            Tuition.Text = "";
            InternationalTuition.Text = "";
        }// end of clear

        protected void Add_Click(object sender, EventArgs e)
        {


            try
            {
                Program item = new Program();
                //item.ProgramID = int.Parse(ProgramID.Text);
                item.ProgramName = ProgramName.Text;
                item.DiplomaName = DiplomaName.Text;
                item.SchoolCode = SchoolCode.Text;

                item.Tuition = decimal.Parse(Tuition.Text);
                item.InternationalTuition = decimal.Parse(InternationalTuition.Text);



                //connect
                ProgramController sysmgr = new ProgramController();

                //method call
                int pkey = sysmgr.Program_Add(item);

                errormsgs.Add("Product was added");
                LoadMessageDisplay(errormsgs, "alert alert-success");

                //remember to refresh any other necessary associated controls
                ProgramDataBind();
                ProgramList.SelectedValue = ProgramID.Text;


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

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //this test is to ensure that a ProductID exists
                // before attempting to do an update
                if (string.IsNullOrEmpty(ProgramID.Text))
                {
                    errormsgs.Add("Update requires you to search for the program first.");
                }
                else
                {
                    int temp = 0;
                    if (!int.TryParse(ProgramID.Text, out temp))
                    {
                        errormsgs.Add("Program ID is invalid");
                    }
                }
            }
            try
            {
                Program item = new Program();
                item.ProgramID = int.Parse(ProgramID.Text); //primary key needs to be included
                item.ProgramName = ProgramName.Text;
                item.DiplomaName = DiplomaName.Text;
                item.SchoolCode = SchoolCode.Text;

                item.Tuition = decimal.Parse(Tuition.Text);
                item.InternationalTuition = decimal.Parse(InternationalTuition.Text);



                //connect
                ProgramController sysmgr = new ProgramController();

                //method call
                int rowsaffect = sysmgr.Program_Update(item);
                if (rowsaffect > 0)
                {
                    errormsgs.Add("Program was added");
                    LoadMessageDisplay(errormsgs, "alert alert-success");

                    //remember to refresh any other necessary associated controls
                    ProgramDataBind();
                    ProgramList.SelectedValue = ProgramID.Text;
                }
                else
                {
                    errormsgs.Add("Program does not appear to be on file. Look up the program again.");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                    ProgramDataBind();
                }

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

        protected void Remove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProgramID.Text))
            {
                errormsgs.Add("Update requires you to search for the program first.");
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(ProgramID.Text, out temp))
                {
                    errormsgs.Add("Program ID is invalid");
                }
            }
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ProgramController sysmgr = new ProgramController();

                    //method call returns the number of rows affected
                    int rowsaffect = sysmgr.Program_Delete(int.Parse(ProgramID.Text));

                    //if the call was successful and changed rows
                    //    or if no rows were changed
                    if (rowsaffect > 0)
                    {
                        errormsgs.Add("Program is discontinued");
                        LoadMessageDisplay(errormsgs, "alert alert-success");

                        //remember to refresh any other necessary associated controls
                        ProgramDataBind();
                        //reposition
                        ProgramList.SelectedValue = ProgramID.Text;

                    }
                    else
                    {
                        errormsgs.Add("Program does not appear to be on file. Look up the program again.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        ProgramDataBind();
                    }
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

        protected void SearchProgram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchPartialName.Text))
            {
                errormsgs.Add("Enter a partial product name to search");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ProgramController sysmgr = new ProgramController();
                    List<Program> info = sysmgr.Programs_FindBySchool(SearchPartialName.Text);
                    ProgramSelectionList.DataSource = info;
                    ProgramSelectionList.DataBind();
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
            try
            {
                //get a pointer to the gridview row that was selected
                GridViewRow agvrow = ProgramSelectionList.Rows[ProgramSelectionList.SelectedIndex];
                //access a specific control on the gridview row
                //data in the control is accessed by the control access method

                string schoolcode = (agvrow.FindControl("SchoolCode") as Label)); //
                ProgramController sysmgr = new ProgramController();
                Program info = sysmgr.Program_Get(schoolcode);
                ProgramID.Text = info.ProgramID.ToString();
                ProgramName.Text = info.ProgramName;
                DiplomaName.Text = info.DiplomaName;
                SchoolCode.Text = info.SchoolCode;
                Tuition.Text = string.Format("{0:0.0000}", info.Tuition);
                InternationalTuition.Text = string.Format("{0:0.0000}", info.InternationalTuition);
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

        protected void ProgramSelectionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //step 1) change the PageIndex of the GridView using the NewPageIndex under e
            ProgramSelectionList.PageIndex = e.NewPageIndex;

            //step 2) refresh your GridView by re-executing the call to the BLL.
            SearchProgram_Click(sender, new EventArgs());
        }
    }
}
