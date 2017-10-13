namespace WildlifeTrackingApp
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.title_Panel = new System.Windows.Forms.Panel();
            this.name_label = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.report_label = new System.Windows.Forms.Label();
            this.locate_label = new System.Windows.Forms.Label();
            this.gpsDevice_Label = new System.Windows.Forms.Label();
            this.report_toolStrip = new System.Windows.Forms.ToolStrip();
            this.locate_toolStrip = new System.Windows.Forms.ToolStrip();
            this.GPSDevice_toolstrip = new System.Windows.Forms.ToolStrip();
            this.category__label = new System.Windows.Forms.Label();
            this.category_toolStrip = new System.Windows.Forms.ToolStrip();
            this.title_Panel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_Panel
            // 
            this.title_Panel.BackColor = System.Drawing.Color.White;
            this.title_Panel.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.green;
            this.title_Panel.Controls.Add(this.name_label);
            this.title_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_Panel.Location = new System.Drawing.Point(179, 0);
            this.title_Panel.Name = "title_Panel";
            this.title_Panel.Size = new System.Drawing.Size(585, 63);
            this.title_Panel.TabIndex = 1;
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(16, 19);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(530, 26);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "WILDLIFE RESERVE TRACKING TOOL";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.light_green;
            this.mainPanel.Controls.Add(this.report_label);
            this.mainPanel.Controls.Add(this.locate_label);
            this.mainPanel.Controls.Add(this.gpsDevice_Label);
            this.mainPanel.Controls.Add(this.report_toolStrip);
            this.mainPanel.Controls.Add(this.locate_toolStrip);
            this.mainPanel.Controls.Add(this.GPSDevice_toolstrip);
            this.mainPanel.Controls.Add(this.category__label);
            this.mainPanel.Controls.Add(this.category_toolStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(179, 469);
            this.mainPanel.TabIndex = 0;
            // 
            // report_label
            // 
            this.report_label.BackColor = System.Drawing.Color.Transparent;
            this.report_label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.report_label.Location = new System.Drawing.Point(6, 211);
            this.report_label.Name = "report_label";
            this.report_label.Size = new System.Drawing.Size(173, 70);
            this.report_label.TabIndex = 7;
            this.report_label.Text = "Report";
            this.report_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.report_label.Click += new System.EventHandler(this.report_label_Click);
            // 
            // locate_label
            // 
            this.locate_label.BackColor = System.Drawing.Color.Transparent;
            this.locate_label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locate_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.locate_label.Location = new System.Drawing.Point(6, 141);
            this.locate_label.Name = "locate_label";
            this.locate_label.Size = new System.Drawing.Size(173, 68);
            this.locate_label.TabIndex = 6;
            this.locate_label.Text = "Locate Category";
            this.locate_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.locate_label.Click += new System.EventHandler(this.locate_label_Click);
            // 
            // gpsDevice_Label
            // 
            this.gpsDevice_Label.BackColor = System.Drawing.Color.Transparent;
            this.gpsDevice_Label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpsDevice_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gpsDevice_Label.Location = new System.Drawing.Point(6, 71);
            this.gpsDevice_Label.Name = "gpsDevice_Label";
            this.gpsDevice_Label.Size = new System.Drawing.Size(173, 68);
            this.gpsDevice_Label.TabIndex = 5;
            this.gpsDevice_Label.Text = "GPS Device";
            this.gpsDevice_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gpsDevice_Label.Click += new System.EventHandler(this.gpsDevice_Label_Click);
            // 
            // report_toolStrip
            // 
            this.report_toolStrip.AutoSize = false;
            this.report_toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.report_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.report_toolStrip.Location = new System.Drawing.Point(0, 210);
            this.report_toolStrip.Margin = new System.Windows.Forms.Padding(1);
            this.report_toolStrip.Name = "report_toolStrip";
            this.report_toolStrip.Size = new System.Drawing.Size(179, 70);
            this.report_toolStrip.TabIndex = 4;
            this.report_toolStrip.Text = "report";
            // 
            // locate_toolStrip
            // 
            this.locate_toolStrip.AutoSize = false;
            this.locate_toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.locate_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.locate_toolStrip.Location = new System.Drawing.Point(0, 140);
            this.locate_toolStrip.Margin = new System.Windows.Forms.Padding(1);
            this.locate_toolStrip.Name = "locate_toolStrip";
            this.locate_toolStrip.Size = new System.Drawing.Size(179, 70);
            this.locate_toolStrip.TabIndex = 3;
            this.locate_toolStrip.Text = "locate";
            // 
            // GPSDevice_toolstrip
            // 
            this.GPSDevice_toolstrip.AutoSize = false;
            this.GPSDevice_toolstrip.BackColor = System.Drawing.Color.Transparent;
            this.GPSDevice_toolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.GPSDevice_toolstrip.Location = new System.Drawing.Point(0, 70);
            this.GPSDevice_toolstrip.Margin = new System.Windows.Forms.Padding(1);
            this.GPSDevice_toolstrip.Name = "GPSDevice_toolstrip";
            this.GPSDevice_toolstrip.Size = new System.Drawing.Size(179, 70);
            this.GPSDevice_toolstrip.TabIndex = 2;
            this.GPSDevice_toolstrip.Text = "GPSDevice";
            // 
            // category__label
            // 
            this.category__label.BackColor = System.Drawing.Color.Transparent;
            this.category__label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category__label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.category__label.Location = new System.Drawing.Point(6, 0);
            this.category__label.Name = "category__label";
            this.category__label.Size = new System.Drawing.Size(173, 69);
            this.category__label.TabIndex = 1;
            this.category__label.Text = "Category";
            this.category__label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.category__label.Click += new System.EventHandler(this.category__label_Click);
            // 
            // category_toolStrip
            // 
            this.category_toolStrip.AutoSize = false;
            this.category_toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.category_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.category_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.category_toolStrip.Margin = new System.Windows.Forms.Padding(1);
            this.category_toolStrip.Name = "category_toolStrip";
            this.category_toolStrip.Size = new System.Drawing.Size(179, 70);
            this.category_toolStrip.TabIndex = 0;
            this.category_toolStrip.Text = "Category";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.par;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(764, 469);
            this.Controls.Add(this.title_Panel);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wildlife Tracking Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.mainPageBackGround_Resize);
            this.title_Panel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel title_Panel;
        private System.Windows.Forms.Label category__label;
        private System.Windows.Forms.ToolStrip category_toolStrip;
        private System.Windows.Forms.Label report_label;
        private System.Windows.Forms.Label locate_label;
        private System.Windows.Forms.Label gpsDevice_Label;
        private System.Windows.Forms.ToolStrip locate_toolStrip;
        private System.Windows.Forms.ToolStrip GPSDevice_toolstrip;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.ToolStrip report_toolStrip;
    }
}

