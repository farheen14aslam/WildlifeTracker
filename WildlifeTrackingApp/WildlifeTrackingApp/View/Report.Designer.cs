namespace WildlifeTrackingApp
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.fromDate_label = new System.Windows.Forms.Label();
            this.toDate_label = new System.Windows.Forms.Label();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.generate_button = new System.Windows.Forms.Button();
            this.reportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // fromDate_label
            // 
            this.fromDate_label.AutoSize = true;
            this.fromDate_label.BackColor = System.Drawing.Color.Transparent;
            this.fromDate_label.Location = new System.Drawing.Point(12, 58);
            this.fromDate_label.Name = "fromDate_label";
            this.fromDate_label.Size = new System.Drawing.Size(56, 13);
            this.fromDate_label.TabIndex = 0;
            this.fromDate_label.Text = "From Date";
            // 
            // toDate_label
            // 
            this.toDate_label.AutoSize = true;
            this.toDate_label.BackColor = System.Drawing.Color.Transparent;
            this.toDate_label.Location = new System.Drawing.Point(12, 104);
            this.toDate_label.Name = "toDate_label";
            this.toDate_label.Size = new System.Drawing.Size(46, 13);
            this.toDate_label.TabIndex = 1;
            this.toDate_label.Text = "To Date";
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.CustomFormat = "";
            this.fromDatePicker.Location = new System.Drawing.Point(81, 52);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(132, 20);
            this.fromDatePicker.TabIndex = 2;
            this.fromDatePicker.ValueChanged += new System.EventHandler(this.fromDatePicker_ValueChanged);
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(81, 104);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(132, 20);
            this.toDatePicker.TabIndex = 3;
            this.toDatePicker.ValueChanged += new System.EventHandler(this.toDatePicker_ValueChanged);
            // 
            // generate_button
            // 
            this.generate_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.generate_button.Location = new System.Drawing.Point(43, 149);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(113, 23);
            this.generate_button.TabIndex = 7;
            this.generate_button.Text = "Generate";
            this.generate_button.UseVisualStyleBackColor = false;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // reportChart
            // 
            this.reportChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportChart.BackColor = System.Drawing.Color.Honeydew;
            chartArea1.Name = "ChartArea1";
            this.reportChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.reportChart.Legends.Add(legend1);
            this.reportChart.Location = new System.Drawing.Point(233, 35);
            this.reportChart.Name = "reportChart";
            this.reportChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Count";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.reportChart.Series.Add(series1);
            this.reportChart.Size = new System.Drawing.Size(437, 367);
            this.reportChart.TabIndex = 8;
            this.reportChart.Text = "reportChart";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.light_green_background_2;
            this.ClientSize = new System.Drawing.Size(682, 414);
            this.ControlBox = false;
            this.Controls.Add(this.reportChart);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.toDate_label);
            this.Controls.Add(this.fromDate_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report";
            this.Text = "Report";
            this.Activated += new System.EventHandler(this.reportGeneration_Activated);
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fromDate_label;
        private System.Windows.Forms.Label toDate_label;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
    }
}