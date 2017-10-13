using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Parent Form class which loades the main page of the application.
    /// </summary>
    public partial class MainPage : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        /// <summary>
        /// Event handler for the category selection click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void category__label_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(category__label);
            foreach (Form form in this.MdiChildren)
            {
                if (form is Category)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            Category configure = new Category();
            configure.MdiParent = this;
            configure.FormBorderStyle = FormBorderStyle.None;
            configure.Dock = DockStyle.Fill;
            configure.Show();
            this.ResumeLayout();
          
        }
        /// <summary>
        /// Changes the color of label based on selection.
        /// </summary>
        /// <param name="label">Instance of selected label</param>
        private void ChangeButtonColor(Label label)
        {
            foreach (var strip in mainPanel.Controls.OfType<Label>())
            {
                if (strip == label)
                {
                    label.BackColor = Color.Honeydew;
                }
                else
                {
                    strip.BackColor = Color.Transparent;
                }
            }
        }

        private void GPSDevice_toolstrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        /// <summary>
        /// Event handler for the GPs device selection click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void gpsDevice_Label_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(gpsDevice_Label);
            foreach (Form form in this.MdiChildren)
            {
                if (form is GPSDevice)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            GPSDevice gpsDevice = new GPSDevice();
            gpsDevice.MdiParent = this;
            gpsDevice.FormBorderStyle = FormBorderStyle.None;
            gpsDevice.Dock = DockStyle.Fill;
            gpsDevice.Show();
            this.ResumeLayout();
        }
        /// <summary>
        /// Event handler for the locate category selection click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void locate_label_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(locate_label);
            foreach (Form form in this.MdiChildren)
            {
                if (form is LocateCategory)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            LocateCategory locateCategory = new LocateCategory();
            locateCategory.MdiParent = this;
            locateCategory.FormBorderStyle = FormBorderStyle.None;
            locateCategory.Dock = DockStyle.Fill;
            locateCategory.Show();
            this.ResumeLayout();
        }
        /// <summary>
        /// Event handler for the report selection click.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void report_label_Click(object sender, EventArgs e)
        {

            this.SuspendLayout();
            ChangeButtonColor(report_label);
            foreach (Form form in this.MdiChildren)
            {
                if (form is Report)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            Report reportPage= new Report();
            reportPage.MdiParent = this;
            reportPage.FormBorderStyle = FormBorderStyle.None;
            reportPage.Dock = DockStyle.Fill;          
            reportPage.Show();
            this.ResumeLayout();
        }
        /// <summary>
        /// Event handler for the resizing of the form page.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void mainPageBackGround_Resize(object sender, EventArgs e)
        {
            this.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.par;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
    }
}
