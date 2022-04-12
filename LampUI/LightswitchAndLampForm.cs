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

        private void RefreshLampGridData()
        {
            lampsDataGridView.DataSource = null;
            lampsDataGridView.DataSource = selectedLightswitch.Lamps;
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
            string name = dialog.EnteredName;
            
            if (!String.IsNullOrEmpty(name))
            {
                Lamp newLamp = new Lamp(name);
                newLamp.LightSwitch = selectedLightswitch;
                newLamp.Create();
                RefreshLampGridData();
            }
            
        }

        private void lightswitchDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void lightswitchDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDataSource();
        }

        private void deleteLightswitchButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{selectedLightswitch.Name}");
        }

        private void deleteLampButton_Click(object sender, EventArgs e)
        {
            //remove the lamp from the switch
            selectedLightswitch.Lamps.Remove(selectedLamp);
            //persist removal of lamp
            selectedLamp.Delete();
            //refresh the grid            
            RefreshLampGridData();
        }

        private void lampsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDataSource();
        }

        private void lampsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDataSource();
        }        
    }
}