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
            InitialReadData();
        }

        private void InitialReadData()
        {
            var switches = Lightswitch.Read();
            lightswitchDataGridView.DataSource = null;
            lampsDataGridView.DataSource = null;
            selectedLightswitch = null;
            selectedLamp = null;
            lightswitchDataGridView.DataSource = switches;
            RefreshDataSource();
        }

        private void RefreshDataSource()
        {
            if (lightswitchDataGridView.Rows.Count > 0
                && (lightswitchDataGridView.SelectedRows.Count > 0 || lightswitchDataGridView.SelectedCells.Count > 0))
            {
                // update selected lightswitch
                if (selectedLightswitch != lightswitchDataGridView.CurrentRow.DataBoundItem as Lightswitch)
                {
                    selectedLightswitch = lightswitchDataGridView.CurrentRow.DataBoundItem as Lightswitch;
                    lampsDataGridView.DataSource = null;
                    lampsDataGridView.DataSource = selectedLightswitch?.Lamps;
                }
            }

            if (lampsDataGridView.Rows.Count > 0
                && (lampsDataGridView.SelectedRows.Count > 0 || lampsDataGridView.SelectedCells.Count > 0))
            {
                // update selected lamp
                selectedLamp = lampsDataGridView.CurrentRow?.DataBoundItem as Lamp;
            }

            createLampButton.Enabled = selectedLightswitch != null;
            deleteLampButton.Enabled = selectedLightswitch != null;
        }

        private void RefreshLampGridData()
        {
            lampsDataGridView.DataSource = null;
            lampsDataGridView.DataSource = selectedLightswitch.Lamps;
        }

        private void CreateLightSwitchButton_Click(object sender, EventArgs e)
        {
            var dialog = new GetNameDialog();
            dialog.ShowDialog();
            if (!String.IsNullOrEmpty(dialog.EnteredName))
            {
                Lightswitch newLightswitch = new Lightswitch(dialog.EnteredName);
                newLightswitch.Create();
                InitialReadData();
            }
        }

        private void CreateLampButton_Click(object sender, EventArgs e)
        {
            var dialog = new GetNameDialog();
            dialog.ShowDialog();
            string name = dialog.EnteredName;
            
            if (!String.IsNullOrEmpty(name))
            {
                Lamp newLamp = new Lamp(name);
                newLamp.LightSwitch = selectedLightswitch;
                newLamp.IsOn = selectedLightswitch.IsOn;
                newLamp.Create();
                RefreshLampGridData();
            }
            
        }

        private void LightswitchDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void LightswitchDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDataSource();
        }

        private void DeleteLightswitchButton_Click(object sender, EventArgs e)
        {
            selectedLightswitch.Delete();
            InitialReadData();
        }

        private void DeleteLampButton_Click(object sender, EventArgs e)
        {
            //remove the lamp from the switch
            selectedLightswitch.Lamps.Remove(selectedLamp);
            //persist removal of lamp
            selectedLamp.Delete();
            //refresh the grid            
            RefreshLampGridData();
        }

        private void LampsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDataSource();
        }

        private void LampsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void ToggleLightswitchButton_Click(object sender, EventArgs e)
        {
            selectedLightswitch.Toggle();
            selectedLightswitch.Update();
            InitialReadData();
        }
    }
}