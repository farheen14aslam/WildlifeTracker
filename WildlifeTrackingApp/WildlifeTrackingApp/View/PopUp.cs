﻿using System;
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
    /// Form class for showing pop ups.
    /// </summary>
    public partial class PopUp : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public PopUp(string message)
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            this.popUp_label.Text = message;
        }
        /// <summary>
        /// Event handler for the Ok button click of pop up.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument</param>
        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
