namespace WildlifeTrackingApp
{
    partial class Category
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
            this.category_dataGridView = new System.Windows.Forms.DataGridView();
            this.add_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.editCategory_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.category_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // category_dataGridView
            // 
            this.category_dataGridView.AllowUserToAddRows = false;
            this.category_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.category_dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.category_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.category_dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.category_dataGridView.Location = new System.Drawing.Point(12, 59);
            this.category_dataGridView.MultiSelect = false;
            this.category_dataGridView.Name = "category_dataGridView";
            this.category_dataGridView.Size = new System.Drawing.Size(683, 321);
            this.category_dataGridView.TabIndex = 0;
            // 
            // add_button
            // 
            this.add_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.add_button.Location = new System.Drawing.Point(35, 12);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 1;
            this.add_button.Text = "Add";
            this.add_button.UseVisualStyleBackColor = false;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.delete_button.Location = new System.Drawing.Point(125, 12);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(75, 23);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // editCategory_button
            // 
            this.editCategory_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.editCategory_button.Location = new System.Drawing.Point(217, 12);
            this.editCategory_button.Name = "editCategory_button";
            this.editCategory_button.Size = new System.Drawing.Size(75, 23);
            this.editCategory_button.TabIndex = 4;
            this.editCategory_button.Text = "Edit";
            this.editCategory_button.UseVisualStyleBackColor = false;
            this.editCategory_button.Click += new System.EventHandler(this.editCategory_button_Click);
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WildlifeTrackingApp.Properties.Resources.light_green_background_2;
            this.ClientSize = new System.Drawing.Size(707, 389);
            this.ControlBox = false;
            this.Controls.Add(this.editCategory_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.category_dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Category";
            this.Text = "Category";
            this.Activated += new System.EventHandler(this.Category_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.category_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView category_dataGridView;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button editCategory_button;
    }
}