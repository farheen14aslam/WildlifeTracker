using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WildlifeTrackingApp.Delegates;
using WildlifeTrackingApp.Models;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Form class that adds loads the list of new animals , add animal ,delete animal and edit animal.
    /// </summary>
    public partial class GPSDevice : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public int selectedRow;
        DataTable animalDetails;
        List<Models.Animal> allAnimalsLocated;

        public GPSDevice()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }
        /// <summary>
        /// Event handler for add button click of adding new animal .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_Click(object sender, EventArgs e)
        {
            
            try
            {
                Add_GPS animalGPSAllocation = new Add_GPS();
                DialogResult dialogresult = animalGPSAllocation.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    string animalName = animalGPSAllocation.animalName;
                    int categoryId = animalGPSAllocation.categoryId;
                    string gpsDeviceId = animalGPSAllocation.GPSDeviceId;
                    this.animalDetails.Rows.Add(animalName, gpsDeviceId);
                    this.gps_dataGridView.Refresh();
                    Models.Animal animalDetails = GetAnimalDetails(animalName, categoryId, gpsDeviceId);
                    AnimalDelegate.AddNewAnimal(animalDetails);
                    dataGrid();
                    animalGPSAllocation.Dispose();
                    PopUp popUpBox = new PopUp(Constants.SUCCESSFULL_GPS_ALLOCATION_MESSAGE);
                    popUpBox.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in allocating the animal with GPS Device {0}", ex.Message));
                dataGrid();
                PopUp popUp = new PopUp(Constants.ERROR_GPS_ALLOCATION_MESSAGE);
                popUp.ShowDialog();
            }      
        }

        private Models.Animal GetAnimalDetails(string animalName, int categoryId, string gpsDeviceId)
        {
            Models.Animal animal = new Models.Animal();
            animal.categoryId = categoryId;
            animal.animalName = animalName;
            animal.gpsDeviceId = gpsDeviceId;
            return animal;
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
                selectedRow = this.gps_dataGridView.CurrentRow.Index;
                Models.Animal animalToBeDeleted = allAnimalsLocated[selectedRow];
                Models.Animal deletedItem = AnimalDelegate.DeleteAnimal(animalToBeDeleted.animalId);
                if (deletedItem != null)
                {
                    this.gps_dataGridView.Rows.RemoveAt(selectedRow);
                    this.gps_dataGridView.Refresh();
                    dataGrid();                    
                }
                PopUp popUpBox = new PopUp(Constants.SUCCESSFUL_ANIMAL_DELETING_MESSAGE);
                popUpBox.ShowDialog();
            }
            catch (Exception ex)
            {
                PopUp popUpBox = new PopUp(Constants.ERROR_ANIMAL_DELETING_MESSAGE);
                popUpBox.ShowDialog();
                log.Error(string.Format("Error in delete animal from server {0}", ex.Message));
                this.SuspendLayout();
            }
        }

        /// <summary>
        /// It loads data to datagrid view.
        /// </summary>
        private void dataGrid()
        {
            gps_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                gps_dataGridView.DataSource = getAllAnimalList();
                gps_dataGridView.Refresh();
                this.PerformLayout();
            }
            catch (WebException webex)
            {
                log.Error("Error in loading datagrid view" + webex.Message + webex.StackTrace);
            }

        }
        /// <summary>
        /// Collects categroy details and saves as a datatable.
        /// </summary>
        /// <returns>Returns category data as datatable</returns>
        private DataTable getAllAnimalList()
        {
            animalDetails = new DataTable();
            try
            {
                this.allAnimalsLocated = AnimalDelegate.GetAllAnimalsAllocated();
                animalDetails.Columns.Add("Category Name", typeof(string));
                animalDetails.Columns.Add("Animal Name", typeof(string));
                animalDetails.Columns.Add("GPS Device Id", typeof(string));
                foreach (Models.Animal animal in allAnimalsLocated)
                {
                    animalDetails.Rows.Add(animal.categoryName, animal.animalName, animal.gpsDeviceId);
                }
                return animalDetails;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in getting the  Reposiory details from server {0}", ex.Message));
                return animalDetails;
            }
        }
        /// <summary>
        /// Event handler for activation of form.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Argument</param>
        private void gpsDevice_Activated(object sender, EventArgs e)
        {
            dataGrid();
        }
    }
}
