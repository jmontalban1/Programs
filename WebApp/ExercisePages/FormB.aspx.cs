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
    public partial class FormB : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();

            if (!Page.IsPostBack)
            {
                
            }

        }

        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
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

        protected void DbUpdateException_Catch(DbUpdateException ex)
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
        protected void DbEntityValidationException_Catch(DbEntityValidationException ex)
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
        protected void General_Catch(Exception ex)
        {
            errormsgs.Add(GetInnerException(ex).ToString());
            LoadMessageDisplay(errormsgs, "alert alert-danger");
        }

        protected void ProgramDataBind()
        {
            //the web page needs to access the BLL class method
            //   to obtain its data
            ProgramController sysmgr = new ProgramController();
            //get the actual data
            List<Program> info = sysmgr.Program_List();
            ProgramSelectionList.DataSource = info;
            ProgramSelectionList.DataBind();
        }



        protected void SearchProgram_Click(object sender, EventArgs e)
        {
            //if (ProgramList.SelectedIndex == 0)
            //{
            //    errormsgs.Add("Select a category to look up.");
            //    LoadMessageDisplay(errormsgs, "alert alert-info");
            //}
            //else
            //{
            try
            {

                //standard lookup
                ProgramController sysmgr = new ProgramController();
                //List<Program> info = sysmgr.Programs_FindByProgramName(info.ProgramName);
                List<Program> infoSchool = sysmgr.Programs_FindByProgramName(SearchPartialName.Text);
                ProgramSelectionList.DataSource = infoSchool;
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


        protected void ProgramSelectionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            ProgramSelectionList.PageIndex = e.NewPageIndex;

           
            SearchProgram_Click(sender, new EventArgs());

        }
    }
}