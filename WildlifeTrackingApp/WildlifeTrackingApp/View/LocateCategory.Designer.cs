namespace WildlifeTrackingApp
{
    partial class LocateCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.category_comboBox = new System.Windows.Forms.ComboBox();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.selectCategory_label = new System.Windows.Forms.Label();
            this.categoryName_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // category_comboBox
            // 
            this.category_comboBox.FormattingEnabled = true;
            this.category_comboBox.Location = new System.Drawing.Point(130, 12);
            this.category_comboBox.Name = "category_comboBox";
            this.category_comboBox.Size = new System.Drawing.Size(121, 21);
            this.category_comboBox.TabIndex = 0;
            this.category_comboBox.SelectedIndexChanged += new System.EventHandler(this.locateSelectedCategory);
            // 
            // gMapControl
            // 
            this.gMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(35, 39);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 18;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(669, 365);
            this.gMapControl.TabIndex = 8;
            this.gMapControl.Zoom = 2D;
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load);
            // 
            // selectCategory_label
            // 
            this.selectCategory_label.BackColor = System.Drawing.Color.Transparent;
            this.selectCategory_label.Location = new System.Drawing.Point(32, 13);
            this.selectCategory_label.Name = "selectCategory_label";
            this.selectCategory_label.Size = new System.Drawing.Size(92, 23);
            this.selectCategory_label.TabIndex = 9;
            this.selectCategory_label.Text = "Select Category";
            // 
            // categoryName_label
            // 
            this.categoryName_label.AutoSize = true;
            this.categoryName_label.BackColor = System.Drawing.Color.Transparent;
            this.categoryName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryName_label.Location = new System.Drawing.Point(359, 12);
            this.categoryName_label.Name = "categoryName_label";
            this.categoryName_label.Size = new System.Drawing.Size(0, 20);
            this.categoryName_label.TabIndex = 10;
            // 
            // LocateCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.light_green_background_2;
            this.ClientSize = new System.Drawing.Size(739, 407);
            this.ControlBox = false;
            this.Controls.Add(this.categoryName_label);
            this.Controls.Add(this.selectCategory_label);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.category_comboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocateCategory";
            this.Text = "LocateCategory";
            this.Activated += new System.EventHandler(this.locateCategory_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox category_comboBox;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Label selectCategory_label;
        private System.Windows.Forms.Label categoryName_label;
    }
}