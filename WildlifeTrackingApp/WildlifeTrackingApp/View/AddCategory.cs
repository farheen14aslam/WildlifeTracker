using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp
{
    /// <summary>
    /// Form class that accepts datas of new category to be added.
    /// </summary>
    public partial class AddCategory : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public string colorHexCode;
        public string categoryName;
        public string colorHexValue;
        public string description;

        public AddCategory()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }
        /// <summary>
        /// Event handler for submit button click.It accepts input fields and store in client.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void submit_button_Click(object sender, EventArgs e)
        {
            if (!(name_textBox.Text == "" | colorHexCode == null))
            {
                categoryName = this.name_textBox.Text;
                colorHexValue = Constants.HASH_CONSTANT + this.colorHexCode;
                description = this.description_richTextBox.Text;
                this.Dispose();
            }
            else
            {
                PopUp popUP = new PopUp(Constants.MANDATORY_FIELD_ERROR_MESSAGE);
                popUP.ShowDialog(); 
            }
        }
        /// <summary>
        /// Event handler for select color button click.
        /// Color dialog box will pop up.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void selectColor_button_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.colorHexCode = (colorDialog.Color.ToArgb() & 0x00FFFFFF).ToString(Constants.X86_CONSTANT);
            }
            this.color_textBox.BackColor = colorDialog.Color;
        }

      
        private void AddCategory_Load(object sender, EventArgs e)
        {
            Color color = ColorTranslator.FromHtml(this.colorHexValue);
            this.color_textBox.BackColor = color;
            this.colorHexCode = (color.ToArgb() & 0x00FFFFFF).ToString(Constants.X86_CONSTANT);
            this.name_textBox.Text = this.categoryName;
            this.description_richTextBox.Text = this.description;
            
        }
    }
   
        
}
