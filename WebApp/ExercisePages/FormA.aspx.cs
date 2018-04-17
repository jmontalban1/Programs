﻿using System;
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
                    //call the desired method
                    //select the value from the drop down list then populate the program information
                    Program info = sysmgr.Program_Get(SchoolList.SelectedValue); // not in a correct format?

                    //check the result of the method execution
                    //if the record was not found, the Product instance
                    //     will be null
                    if (info == null)
                    {

                        errormsgs.Add("School not found. Try again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        //this should not happen
                        //the value was taken from a list generated by
                        //    the system from the database
                        //HOWEVER: since we are in a multiple user
                        //    environment, between loading the ddl and
                        //    actually doing a search,  another user
                        //    could have deleted the desired product record
                        //THEREFORE: the ddl should be refreshed so that
                        //    it only shows the current product list
                        SchoolDataBind();
                    }
                    else
                    {
                        //record was found
                        //load the web form controls with the data
                        //  that was returned
                        //controls are loaded with datatype string

                        ProgramID.Text = info.ProgramID.ToString();
                        ProgramName.Text = info.ProgramName;
                        //SchoolCode.Text = info.SchoolCode;
                        ////ddl are positioned using SelectedValue
                        //SupplierList.SelectedValue = info.SupplierID.ToString();
                        //CategoryList.SelectedValue = info.CategoryID.ToString();
                        //QuantityPerUnit.Text = info.QuantityPerUnit;
                        ////UnitPrice, UnitsInStock, UnitsOnOrder and 
                        ////    ReorderLevel are nullable numerics
                        //UnitPrice.Text = info.UnitPrice == null ? "" : string.Format("{0:0.00}", info.UnitPrice);

                        //UnitsInStock.Text = info.UnitsInStock == null ? "" : info.UnitsInStock.ToString();
                        //UnitsOnOrder.Text = info.UnitsOnOrder == null ? "" : info.UnitsOnOrder.ToString();
                        //ReorderLevel.Text = info.ReorderLevel == null ? "" : info.ReorderLevel.ToString();
                        ////Discontinued is a checkbox which is a bool set
                        //Discontinued.Checked = info.Discontinued;
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
    }
}