using GloeilampSysteem.BusinessLayer;

namespace LampUI
{
    public partial class LightswitchAndLampForm : Form
    {
        public LightswitchAndLampForm()
        {
            InitializeComponent();
            currentDalStatusLabel.Text = $"Current DAL: {new DataAccessLayerInfo().DALName}";
        }
    }
}