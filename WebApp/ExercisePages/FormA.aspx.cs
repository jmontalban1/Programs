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
        protected Exception GetInnerException(Exception ex)
        {
            
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
        }

        protected void SchoolDataBind()
        {
            try
            {
                SchoolController sysmgr = new SchoolController();
                List<School> info = sysmgr.School_List();
                info.Sort((x, y) => x.SchoolName.CompareTo(y.SchoolName));
                SchoolList.DataSource = info;
                SchoolList.DataValueField = "SchoolCode";
                SchoolList.DataTextField = "SchoolName";
                SchoolList.DataBind();
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
                ProgramController sysmgr = new ProgramController();
                List<Program> info = sysmgr.Program_List();
                info.Sort((x, y) => x.ProgramName.CompareTo(y.ProgramName));
                ProgramList.DataSource = info;
                ProgramList.DataBind();
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

            try
            {
                ProgramController sysmgr = new ProgramController();
                Program info = sysmgr.SchoolProgram_Get(int.Parse(ProgramList.SelectedValue));


                ProgramID.Text = info.ProgramID.ToString();
                ProgramName.Text = info.ProgramName;
                DiplomaName.Text = info.DiplomaName;
                SchoolCode.Text = info.SchoolCode;
                Tuition.Text = $"{info.Tuition:F}";
                InternationalTuition.Text = $"{info.InternationalTuition:F}";
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
            if (SchoolList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a school to search.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {
                try
                {
                    ProgramController sysmgr = new ProgramController();
                    List<Program> info = sysmgr.Programs_FindBySchool(SchoolList.SelectedValue);
                    info.Sort((x, y) => x.ProgramName.CompareTo(y.ProgramName));
                    ProgramList.DataSource = info;
                    ProgramList.DataValueField = "ProgramID";
                    ProgramList.DataTextField = "ProgramName";
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
                errormsgs.Add("Program was added");
                LoadMessageDisplay(errormsgs, "alert alert-success");
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
                    int rowsaffect = sysmgr.Program_Delete(int.Parse(ProgramID.Text));
                    if (rowsaffect > 0)
                    {
                        errormsgs.Add("Program was deleted");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        ProgramDataBind();
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

        //protected void SearchProgram_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(SearchPartialName.Text))
        //    {
        //        errormsgs.Add("Enter a partial product name to search");
        //        LoadMessageDisplay(errormsgs, "alert alert-info");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            ProgramController sysmgr = new ProgramController();
        //            List<Program> info = sysmgr.Programs_FindBySchool(SearchPartialName.Text);
        //            ProgramSelectionList.DataSource = info;
        //            ProgramSelectionList.DataBind();
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            UpdateException updateException = (UpdateException)ex.InnerException;
        //            if (updateException.InnerException != null)
        //            {
        //                errormsgs.Add(updateException.InnerException.Message.ToString());
        //            }
        //            else
        //            {
        //                errormsgs.Add(updateException.Message);
        //            }
        //            LoadMessageDisplay(errormsgs, "alert alert-danger");
        //        }
        //        catch (DbEntityValidationException ex)
        //        {
        //            foreach (var entityValidationErrors in ex.EntityValidationErrors)
        //            {
        //                foreach (var validationError in entityValidationErrors.ValidationErrors)
        //                {
        //                    errormsgs.Add(validationError.ErrorMessage);
        //                }
        //            }
        //            LoadMessageDisplay(errormsgs, "alert alert-danger");
        //        }
        //        catch (Exception ex)
        //        {
        //            errormsgs.Add(GetInnerException(ex).ToString());
        //            LoadMessageDisplay(errormsgs, "alert alert-danger");
        //        }
        //    }
        //}




        //protected void ProgramList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //get a pointer to the gridview row that was selected
        //        GridViewRow agvrow = ProgramSelectionList.Rows[ProgramSelectionList.SelectedIndex];
        //        //access a specific control on the gridview row
        //        //data in the control is accessed by the control access method

        //        string schoolcode = (agvrow.FindControl("SchoolCode") as Label)); //
        //        ProgramController sysmgr = new ProgramController();
        //        Program info = sysmgr.Program_Get(schoolcode);
        //        ProgramID.Text = info.ProgramID.ToString();
        //        ProgramName.Text = info.ProgramName;
        //        DiplomaName.Text = info.DiplomaName;
        //        SchoolCode.Text = info.SchoolCode;
        //        Tuition.Text = string.Format("{0:0.0000}", info.Tuition);
        //        InternationalTuition.Text = string.Format("{0:0.0000}", info.InternationalTuition);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        UpdateException updateException = (UpdateException)ex.InnerException;
        //        if (updateException.InnerException != null)
        //        {
        //            errormsgs.Add(updateException.InnerException.Message.ToString());
        //        }
        //        else
        //        {
        //            errormsgs.Add(updateException.Message);
        //        }
        //        LoadMessageDisplay(errormsgs, "alert alert-danger");
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        foreach (var entityValidationErrors in ex.EntityValidationErrors)
        //        {
        //            foreach (var validationError in entityValidationErrors.ValidationErrors)
        //            {
        //                errormsgs.Add(validationError.ErrorMessage);
        //            }
        //        }
        //        LoadMessageDisplay(errormsgs, "alert alert-danger");
        //    }
        //    catch (Exception ex)
        //    {
        //        errormsgs.Add(GetInnerException(ex).ToString());
        //        LoadMessageDisplay(errormsgs, "alert alert-danger");
        //    }
        //}

        //protected void ProgramSelectionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //step 1) change the PageIndex of the GridView using the NewPageIndex under e
        //    ProgramSelectionList.PageIndex = e.NewPageIndex;

        //    //step 2) refresh your GridView by re-executing the call to the BLL.
        //    SearchProgram_Click(sender, new EventArgs());
        //}
    }
}
