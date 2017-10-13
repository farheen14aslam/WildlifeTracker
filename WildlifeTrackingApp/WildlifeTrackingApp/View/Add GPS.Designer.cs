namespace WildlifeTrackingApp
{
    partial class Add_GPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_GPS));
            this.name_label = new System.Windows.Forms.Label();
            this.category_label = new System.Windows.Forms.Label();
            this.submit_button = new System.Windows.Forms.Button();
            this.animalName_text = new System.Windows.Forms.TextBox();
            this.gpsId_label = new System.Windows.Forms.Label();
            this.gpsDeviceId_Text = new System.Windows.Forms.TextBox();
            this.category_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(74, 65);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(35, 13);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Name";
            // 
            // category_label
            // 
            this.category_label.AutoSize = true;
            this.category_label.Location = new System.Drawing.Point(74, 134);
            this.category_label.Name = "category_label";
            this.category_label.Size = new System.Drawing.Size(49, 13);
            this.category_label.TabIndex = 2;
            this.category_label.Text = "Category";
            // 
            // submit_button
            // 
            this.submit_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.submit_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submit_button.Location = new System.Drawing.Point(136, 186);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(75, 23);
            this.submit_button.TabIndex = 6;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = false;
            this.submit_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // animalName_text
            // 
            this.animalName_text.Location = new System.Drawing.Point(165, 58);
            this.animalName_text.Name = "animalName_text";
            this.animalName_text.Size = new System.Drawing.Size(112, 20);
            this.animalName_text.TabIndex = 7;
            // 
            // gpsId_label
            // 
            this.gpsId_label.AutoSize = true;
            this.gpsId_label.Location = new System.Drawing.Point(74, 103);
            this.gpsId_label.Name = "gpsId_label";
            this.gpsId_label.Size = new System.Drawing.Size(41, 13);
            this.gpsId_label.TabIndex = 8;
            this.gpsId_label.Text = "GPS Id";
            // 
            // gpsDeviceId_Text
            // 
            this.gpsDeviceId_Text.Location = new System.Drawing.Point(165, 100);
            this.gpsDeviceId_Text.Name = "gpsDeviceId_Text";
            this.gpsDeviceId_Text.Size = new System.Drawing.Size(112, 20);
            this.gpsDeviceId_Text.TabIndex = 9;
            // 
            // category_comboBox
            // 
            this.category_comboBox.FormattingEnabled = true;
            this.category_comboBox.Location = new System.Drawing.Point(165, 134);
            this.category_comboBox.Name = "category_comboBox";
            this.category_comboBox.Size = new System.Drawing.Size(112, 21);
            this.category_comboBox.TabIndex = 10;
            // 
            // Add_GPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(351, 249);
            this.Controls.Add(this.category_comboBox);
            this.Controls.Add(this.gpsDeviceId_Text);
            this.Controls.Add(this.gpsId_label);
            this.Controls.Add(this.animalName_text);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.category_label);
            this.Controls.Add(this.name_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Add_GPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_GPS";
            this.Activated += new System.EventHandler(this.addGPS_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label category_label;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.TextBox animalName_text;
        private System.Windows.Forms.Label gpsId_label;
        private System.Windows.Forms.TextBox gpsDeviceId_Text;
        private System.Windows.Forms.ComboBox category_comboBox;
    }
}