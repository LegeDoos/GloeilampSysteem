using GloeilampSysteem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GloeilampSysteem.DataAccessLayer
{
    public interface iDataAccessLayer
    {
        // data access layer heeft weet van de BusinessLayer en kan daarom objecten uit het model gebruiken (zie ook usings)
        // interface geeft aan wat je in de DAL verwacht

        public Lamp CreateLamp(Lamp lamp);
        public Lamp GetLampById(int id);
        public Lamp UpdateLamp(Lamp lamp);
        public void DeleteLampById(Lamp lamp);

        public LightSwitch CreateLightSwitch(LightSwitch lightSwitch);
        public LightSwitch GetLightSwitchById(int id);
        public LightSwitch UpdateLightSwitch(LightSwitch lightSwitch);
        public void DeleteLightSwitch(LightSwitch lightSwitch);

        public List<LightSwitch> GetLightswitches();

    }
}
