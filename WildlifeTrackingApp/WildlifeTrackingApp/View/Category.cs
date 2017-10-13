using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WildlifeTrackingApp.Delegates;
using WildlifeTrackingApp.Models;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Form class for showing the list of all categories, adding new category, deleting and editing category.
    /// </summary>
    public partial class Category : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public int selectedRow;
        DataTable categoryDetail;
        private List<Models.Category> allCategoryDetails;       

        public Category()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Event handler for add button click.
        /// It accept data and send it to server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_Click(object sender, EventArgs e)
        {
            try
            {
                AddCategory category = new AddCategory();
                DialogResult dialogresult = category.ShowDialog();
                if(dialogresult == DialogResult.OK)
                {
                    string categoryName = category.categoryName;
                    string categoryColor = category.colorHexValue;
                    string categoryDesc = category.description;
                    this.categoryDetail.Rows.Add(categoryName, categoryColor);
                    this.category_dataGridView.Refresh();
                    Models.Category categoryDetails = GetCategory(categoryName, categoryColor, categoryDesc);
                    CategoryDelegate.AddNewCategory(categoryDetails);
                    dataGrid();
                    category.Dispose();
                    PopUp popUpBox = new PopUp(Constants.SUCCESSFUL_ADD_CATEGORY_MESSAGE);
                    popUpBox.ShowDialog();

                }
           
            }
            catch(Exception ex)
            {               
                log.Error(string.Format("Error in send new category data to server {0}", ex.Message));
                dataGrid();
                PopUp popUp = new PopUp(Constants.ERROR_CREATING_CATEGORY_MESSAGE);
                popUp.ShowDialog();
                
            }
        }

        private Models.Category GetCategory(string categoryName, string categoryColor, string categoryDesc)
        {
            Models.Category category = new Models.Category();
            category.categoryName = categoryName;
            category.categoryDesc = categoryDesc;
            category.colorIndication = categoryColor;
            return category;
        }
        /// <summary>
        /// It loads data to datagrid view.
        /// </summary>
        private void dataGrid()
        {
            category_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                category_dataGridView.DataSource = GetRESTData();
                category_dataGridView.Refresh();
                this.PerformLayout();
            }
            catch (WebException webex)
            {
                log.Error("Error in loading datagrid view"+webex.Message+webex.StackTrace);
            }

        }
        /// <summary>
        /// Collects categroy details and saves as a datatable.
        /// </summary>
        /// <returns>Returns category data as datatable</returns>
        private DataTable GetRESTData()
        {
            categoryDetail = new DataTable();
            try
            {
                this.allCategoryDetails = CategoryDelegate.GetAllCategories();
                categoryDetail.Columns.Add("Category Name", typeof(string));
                categoryDetail.Columns.Add("Category Color", typeof(string));
                categoryDetail.Columns.Add("Category Description", typeof(string));
                foreach (Models.Category category in allCategoryDetails)
                {
                    categoryDetail.Rows.Add(category.categoryName, category.colorIndication, category.categoryDesc);
                }
                return categoryDetail;
            }
            catch (Exception ex)
            {               
                log.Error(string.Format("Error in get Reposiory details from server {0}", ex.Message));
                return categoryDetail;
            }

        }             
        /// <summary>
        /// Event handler for activation of form.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Argument</param>
        private void Category_Activated(object sender, EventArgs e)
        {
            dataGrid();
        }
        /// <summary>
        /// Event handler for delete button click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.category_dataGridView.SelectedRows)
                {
                    int categoryIndex = row.Index;
                    Models.Category categoryToBeDeleted = allCategoryDetails[categoryIndex];
                    Models.Category deletedItem = CategoryDelegate.DeleteCategory(categoryToBeDeleted.categoryId);
                    if (deletedItem != null)
                    {
                        this.category_dataGridView.Rows.RemoveAt(categoryIndex);
                        this.category_dataGridView.Refresh();
                        dataGrid();
                    }
                    PopUp popUpBox = new PopUp(Constants.SUCCESSFUL_DELETE_CATEGORY_MESSAGE);
                    popUpBox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                PopUp popUpBox = new PopUp(Constants.ERROR_DELETING_CATEGORY_MESSAGE);
                popUpBox.ShowDialog();
                log.Error(string.Format("Error in delete category from server {0}", ex.Message));  
            }

        }       
        /// <summary>
        /// Event handler for edit button click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void edit_button_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event handler for edit button click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void editCategory_button_Click(object sender, EventArgs e)
        {

            try
            {
                selectedRow = this.category_dataGridView.CurrentRow.Index;
                Models.Category categoryToEdit = allCategoryDetails[selectedRow];
                AddCategory category = new AddCategory();
                category.colorHexValue = categoryToEdit.colorIndication;
                category.categoryName = categoryToEdit.categoryName;
                category.description = categoryToEdit.categoryDesc;
                DialogResult dialogresult = category.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    string categoryName = category.categoryName;
                    string categoryColor = category.colorHexValue;
                    string categoryDesc = category.description;
                    this.categoryDetail.Rows.Add(categoryName, categoryColor, categoryDesc);
                    this.category_dataGridView.Refresh();
                    Models.Category categoryDetails = GetUpdatedCategory(categoryName, categoryColor, categoryDesc, categoryToEdit.categoryId);
                    CategoryDelegate.UpdateCategory(categoryDetails);
                    dataGrid();
                    category.Dispose();
                    PopUp popUpBox = new PopUp(Constants.SUCCESSFUL_UPDATED_CATEGORY_MESSAGE);
                    popUpBox.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in updating category data to server {0}", ex.Message));
                dataGrid();
                PopUp popUp = new PopUp(Constants.ERROR_UPDATING_CATEGORY_MESSAGE);
                popUp.ShowDialog();

            }

        }

        private Models.Category GetUpdatedCategory(string categoryName, string categoryColor, string categoryDesc, int categoryId)
        {
            Models.Category category = new Models.Category();
            category.categoryName = categoryName;
            category.categoryDesc = categoryDesc;
            category.colorIndication = categoryColor;
            category.categoryId = categoryId;
            return category;
        }
    }    
}
