using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WildlifeTrackingApp.Delegates;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Form class for the report generation page.
    /// Generates report of total number of animals per categories based on the from and to date.
    /// </summary>
    public partial class Report : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public DateTime fromDate = DateTime.Now;
        public DateTime toDate = DateTime.Now;

        public Report()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            this.fromDatePicker.Text = (DateTime.Now).AddDays(-5).ToString();

        }
        /// <summary>
        /// Event handler for form load.
        /// Customizes the datetime picker format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_Load(object sender, EventArgs e)
        {
            fromDatePicker.Format = DateTimePickerFormat.Custom;
            fromDatePicker.CustomFormat = Constants.DATE_PICKER_FOMAT;
            toDatePicker.Format = DateTimePickerFormat.Custom;
            toDatePicker.CustomFormat = Constants.DATE_PICKER_FOMAT;

        }

        /// <summary>
        /// Event handler for the change in the value of fromdate picker.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDate = fromDatePicker.Value.Date;
        }

        /// <summary>
        /// Event handler for the change in the value of todate picker.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            toDate = toDatePicker.Value.Date;
        }
        /// <summary>
        /// Event handler for the generate button click.
        /// It generates charts based on total number of animals per category.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void generate_button_Click(object sender, EventArgs e)
        {
            reportChart.Series[Constants.COUNT].Points.Clear();
            reportChart.Titles.Clear();
            if (toDate > DateTime.Now)
            {
                PopUp popUP = new PopUp(Constants.TO_DATE_VALIDATION_MESSAGE);
                popUP.ShowDialog();               
            }
            else if (fromDate > toDate && fromDate > DateTime.Now)
            {
                PopUp popUP = new PopUp(Constants.FROM_DATE_VALIDATION_MESSAGE);
                popUP.ShowDialog();                
            }
            else
            {
                string startDate = fromDate.ToString(Constants.DATE_PICKER_FOMAT);
                string endDate = toDate.ToString(Constants.DATE_PICKER_FOMAT);
                List<Models.AnimalCategoryCount> animals = AnimalDelegate.GetAnimalsCountPerCategory(startDate, endDate);
                int i = 0;
                foreach (Models.AnimalCategoryCount animal in animals)
                {
                    reportChart.Series[Constants.COUNT].Points.AddXY(animal.categoryName, animal.totalAnimals);
                    Color color = ColorTranslator.FromHtml(animal.colorIndication);
                    reportChart.Series[Constants.COUNT].Points[i].Color = color;
                    i++;
                }
                reportChart.Titles.Add(Constants.COUNT_OF_ALL_THE_ANIMALS_PER_CATEGORY);                
            }
        }
        /// <summary>
        /// Event handler for the activation of form.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void reportGeneration_Activated(object sender, EventArgs e)
        {
            reportChart.Series[Constants.COUNT].Points.Clear();
            reportChart.DataSource = null;
            reportChart.Titles.Clear();
        }
    }   
}
