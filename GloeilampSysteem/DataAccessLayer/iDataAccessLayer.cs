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
        public Lamp GetLampById(int id);
        public Lamp UpdateLamp(Lamp lamp);
        public void DeleteLampById(Lamp lamp);

        public LightSwitch CreateLightSwitch(LightSwitch lightSwitch);
        public LightSwitch GetLightSwitchById(int id);
        public LightSwitch UpdateLightSwitch(LightSwitch lightSwitch);
        public void DeleteLightSwitchById(LightSwitch lightSwitch);

        public List<LightSwitch> GetLightswitches();

    }
}
