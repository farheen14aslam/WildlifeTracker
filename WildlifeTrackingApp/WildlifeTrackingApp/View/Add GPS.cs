using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WildlifeTrackingApp.Delegates;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Form class that accepts data about new animal to be added.
    /// </summary>
    public partial class Add_GPS : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public int categoryId;
        public string categoryName;
        public string GPSDeviceId;
        public string animalName;

        /// <summary>
        /// Constructor for intializing log4net
        /// </summary>
        public Add_GPS()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Event handler for add animal click.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void add_button_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(!(animalName_text.Text == "" | gpsDeviceId_Text.Text == ""))
                {
                    Models.Category selectedCategory = (Models.Category)this.category_comboBox.Items[category_comboBox.SelectedIndex];
                    this.categoryId = selectedCategory.categoryId;
                    this.animalName = this.animalName_text.Text;
                    this.GPSDeviceId = this.gpsDeviceId_Text.Text;
                }
                
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error in adding new animal {0}", ex.Message));
                PopUp popUpBox = new PopUp("Error in creating a new animal");
                popUpBox.ShowDialog();
            }
        }
        /// <summary>
        /// Event handler for activation of form.It reloads the datagrid view datasource. 
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void addGPS_Activated(object sender, EventArgs e)
        {
            Models.Category[] allCategories = CategoryDelegate.GetAllCategories().ToArray();
            category_comboBox.DataSource = allCategories;
            category_comboBox.ValueMember = Constants.CATEGORY_ID;
            category_comboBox.DisplayMember = Constants.CATEGORY_NAME;
        }
        
    }
}
