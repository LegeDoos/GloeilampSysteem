using GloeilampSysteem.BusinessLayer;

namespace LampUI
{
    public partial class LightswitchAndLampForm : Form
    {
        Lightswitch selectedLightswitch;
        Lamp selectedLamp;

        public LightswitchAndLampForm()
        {
            InitializeComponent();
            currentDalStatusLabel.Text = $"Current DAL: {new DataAccessLayerInfo().DALName}";
            ReadData();
        }

        private void ReadData()
        {
            var switches = Lightswitch.Read();
            lightswitchDataGridView.DataSource = switches;
            RefreshData();
        }

        private void RefreshData()
        {

            if (lightswitchDataGridView.Rows.Count > 0
                && (lightswitchDataGridView.SelectedRows.Count > 0 || lightswitchDataGridView.SelectedCells.Count > 0))
            {
                // update selected lightswitch
                if (selectedLightswitch != lightswitchDataGridView.CurrentRow.DataBoundItem as Lightswitch)
                {
                    selectedLightswitch = lightswitchDataGridView.CurrentRow.DataBoundItem as Lightswitch;
                    lampsDataGridView.DataSource = selectedLightswitch.Lamps;
                }
            }

            if (lampsDataGridView.Rows.Count > 0
                && (lampsDataGridView.SelectedRows.Count > 0 || lampsDataGridView.SelectedCells.Count > 0))
            {
                // update selected lamp
                selectedLamp = lampsDataGridView.CurrentRow.DataBoundItem as Lamp;
            }

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

        private void lightswitchDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void lightswitchDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshData();
        }

        private void deleteLightswitchButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{selectedLightswitch.Name}");
        }

        private void deleteLampButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{selectedLamp.Name}");
        }

        private void lampsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshData();
        }

        private void lampsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}