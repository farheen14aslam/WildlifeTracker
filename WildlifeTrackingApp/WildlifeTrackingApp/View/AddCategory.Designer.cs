namespace WildlifeTrackingApp
{
    partial class AddCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategory));
            this.submit_button = new System.Windows.Forms.Button();
            this.name_label = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.color_textBox = new System.Windows.Forms.TextBox();
            this.selectColor_button = new System.Windows.Forms.Button();
            this.description_richTextBox = new System.Windows.Forms.RichTextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.mandatory_label1 = new System.Windows.Forms.Label();
            this.mandatory_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submit_button
            // 
            this.submit_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.submit_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submit_button.Location = new System.Drawing.Point(155, 234);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(75, 23);
            this.submit_button.TabIndex = 0;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = false;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(80, 74);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(35, 13);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Name";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(80, 168);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(60, 13);
            this.description_label.TabIndex = 3;
            this.description_label.Text = "Description";
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(209, 71);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(134, 20);
            this.name_textBox.TabIndex = 4;
            // 
            // color_textBox
            // 
            this.color_textBox.Location = new System.Drawing.Point(209, 116);
            this.color_textBox.Name = "color_textBox";
            this.color_textBox.ReadOnly = true;
            this.color_textBox.Size = new System.Drawing.Size(134, 20);
            this.color_textBox.TabIndex = 5;
            // 
            // selectColor_button
            // 
            this.selectColor_button.Location = new System.Drawing.Point(83, 114);
            this.selectColor_button.Name = "selectColor_button";
            this.selectColor_button.Size = new System.Drawing.Size(75, 23);
            this.selectColor_button.TabIndex = 6;
            this.selectColor_button.Text = "Select color";
            this.selectColor_button.UseVisualStyleBackColor = true;
            this.selectColor_button.Click += new System.EventHandler(this.selectColor_button_Click);
            // 
            // description_richTextBox
            // 
            this.description_richTextBox.Location = new System.Drawing.Point(209, 154);
            this.description_richTextBox.Name = "description_richTextBox";
            this.description_richTextBox.Size = new System.Drawing.Size(134, 63);
            this.description_richTextBox.TabIndex = 7;
            this.description_richTextBox.Text = "";
            // 
            // mandatory_label1
            // 
            this.mandatory_label1.AutoSize = true;
            this.mandatory_label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mandatory_label1.ForeColor = System.Drawing.Color.Red;
            this.mandatory_label1.Location = new System.Drawing.Point(331, 74);
            this.mandatory_label1.Name = "mandatory_label1";
            this.mandatory_label1.Size = new System.Drawing.Size(12, 15);
            this.mandatory_label1.TabIndex = 8;
            this.mandatory_label1.Text = "*";
            // 
            // mandatory_label
            // 
            this.mandatory_label.AutoSize = true;
            this.mandatory_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mandatory_label.ForeColor = System.Drawing.Color.Red;
            this.mandatory_label.Location = new System.Drawing.Point(331, 117);
            this.mandatory_label.Name = "mandatory_label";
            this.mandatory_label.Size = new System.Drawing.Size(12, 15);
            this.mandatory_label.TabIndex = 9;
            this.mandatory_label.Text = "*";
            // 
            // AddCategory
            // 
            this.AcceptButton = this.submit_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(384, 280);
            this.Controls.Add(this.mandatory_label);
            this.Controls.Add(this.mandatory_label1);
            this.Controls.Add(this.description_richTextBox);
            this.Controls.Add(this.selectColor_button);
            this.Controls.Add(this.color_textBox);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.submit_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCategory";
            this.Load += new System.EventHandler(this.AddCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.TextBox color_textBox;
        private System.Windows.Forms.Button selectColor_button;
        private System.Windows.Forms.RichTextBox description_richTextBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label mandatory_label1;
        private System.Windows.Forms.Label mandatory_label;
    }
}