using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WildlifeTrackingApp.Delegates;
using WildlifeTrackingApp.Models;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Form class that loads map and locates the animals from given categories.
    /// </summary>
    public partial class LocateCategory : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public LocateCategory()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }

        /// <summary>
        /// Loads the Gmap.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void gMapControl_Load(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.Zoom = 4;
            gMapControl.Position = new PointLatLng(-30.5595, 22.9375);

        }

        /// <summary>
        /// Event handler for the activation of the form.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void locateCategory_Activated(object sender, EventArgs e)
        {
            
            List<Models.Category> allCategories = CategoryDelegate.GetAllCategories().ToList();
            Models.Category category = new Models.Category();
            category.categoryId = 0;
            category.categoryName = Constants.ALL;
            allCategories.Insert(0, category);
            category_comboBox.BindingContext = new BindingContext();
            category_comboBox.DataSource = allCategories;
            category_comboBox.ValueMember = Constants.CATEGORY_ID;
            category_comboBox.DisplayMember = Constants.CATEGORY_NAME;
            loadGoogleMapForAllCategory();
        }
        /// <summary>
        /// Locates total animals from all categoreies in Gmap.
        /// </summary>
        private void loadGoogleMapForAllCategory()
        {
            gMapControl.Overlays.Clear();
            try
            {

                List<TrackingInfo> trackingInfo = TrackingInfoDelegate.GetLatestPositionOfAllAnimal();
                var allAnimalsPerCategory = trackingInfo.GroupBy(category => category.categoryId);
                GMarkerGoogle marker;
                GMapOverlay markersOverlay = new GMapOverlay("markers");

                int colorIndex = 0;
                foreach (var allAnimal in allAnimalsPerCategory)
                {
                    foreach (TrackingInfo point in allAnimal)
                    {

                        GMarkerGoogleType MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), Constants.CategoryMapLocatorColor[colorIndex], true);
                        marker = new GMarkerGoogle(new PointLatLng(point.latitude, point.longitude), MarkerColor);
                        marker.ToolTipText = point.gpsDeviceId + Constants.COLON_CONSTANTS + point.categoryName;
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        markersOverlay.Markers.Add(marker);
                    }
                    colorIndex += 1;
                }
                gMapControl.Overlays.Add(markersOverlay);
                configureZoomingOfMap();
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error in viewing the map {0}", ex.Message));
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Locates animals from the selected category.
        /// </summary>
        private void loadGoogleMapPerCategory()
            {
            gMapControl.Overlays.Clear();
            Models.Category selectedCategory = (Models.Category)this.category_comboBox.Items[category_comboBox.SelectedIndex];
            int categoryId = selectedCategory.categoryId;

            try
            {                
                List<TrackingInfo> trackingInfo = TrackingInfoDelegate.GetLatestPositionOfAllAnimalPerCategory(categoryId);
                GMarkerGoogle marker;
                GMapOverlay markersOverlay = new GMapOverlay("markers");
                foreach (TrackingInfo point in trackingInfo)
                {
                    GMarkerGoogleType MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), Constants.GREEN_COLOR, true);
                    marker = new GMarkerGoogle(new PointLatLng(point.latitude, point.longitude), MarkerColor);
                    marker.ToolTipText = point.gpsDeviceId + Constants.COLON_CONSTANTS + point.categoryName;
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    markersOverlay.Markers.Add(marker);
                }
                gMapControl.Overlays.Add(markersOverlay);
                configureZoomingOfMap();
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error map view {0}", ex.Message));
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Event handler for the selection change of drop down menu.
        /// It locates the all animals from a particular categories or from all categories choosen based on drop down menu selection.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void locateSelectedCategory(object sender, EventArgs e)
        {
            gMapControl.Overlays.Clear();
            Models.Category selectedCategory = (Models.Category)this.category_comboBox.Items[category_comboBox.SelectedIndex];
            
            int categoryId = selectedCategory.categoryId;
            string categoryName = selectedCategory.categoryName;
            if(categoryName == Constants.ALL)
            {
                categoryName_label.Text = Constants.LOCATE_ANIMAL_HEADING_START  + selectedCategory.categoryName + Constants.LOCATE_ANIMAL_HEADING_END_ALL_CATEGORY;
                loadGoogleMapForAllCategory();
            }
            else
            {
                categoryName_label.Text = Constants.LOCATE_ANIMAL_HEADING_START + selectedCategory.categoryName + Constants.LOCATE_ANIMAL_HEADING_END_PER_CATEGORY;
                loadGoogleMapPerCategory();
            }
        }

        private void configureZoomingOfMap()
        {
            double zoomAtual = gMapControl.Zoom;
            gMapControl.Zoom = zoomAtual + 1;
            gMapControl.Zoom = zoomAtual;
        }
    }
}
