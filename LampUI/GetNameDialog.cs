using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LampUI
{
    /// <summary>
    /// Represents a dialog to get userinput (name)
    /// </summary>
    public partial class GetNameDialog : Form
    {
        public string EnteredName { get; set; } = string.Empty;

        public GetNameDialog()
        {
            InitializeComponent();
            nameTextbox.Text = EnteredName;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            EnteredName = nameTextbox.Text;
            this.Close();
        }
    }
}
