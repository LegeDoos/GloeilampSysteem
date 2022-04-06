using GloeilampSysteem.BusinessLayer;

namespace LampUI
{
    public partial class LightswitchAndLampForm : Form
    {
        public LightswitchAndLampForm()
        {
            InitializeComponent();
            currentDalStatusLabel.Text = $"Current DAL: {new DataAccessLayerInfo().DALName}";
            ReadData();
        }

        private void ReadData()
        {
            lightswitchDataGridView.DataSource = Lightswitch.Read();
            
        }

        private void createLightSwitchButton_Click(object sender, EventArgs e)
        {
            var dialog = new GetNameDialog();
            dialog.ShowDialog();

        }

        private void createLampButton_Click(object sender, EventArgs e)
        {
            var dialog = new GetNameDialog();
            dialog.ShowDialog();
        }
    }
}