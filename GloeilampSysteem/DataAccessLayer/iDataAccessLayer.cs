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
        public Lamp ReadLamp(int id);
        public Lamp UpdateLamp(Lamp lamp);
        public void DeleteLamp(Lamp lamp);

        public Lightswitch CreateLightswitch(Lightswitch lightSwitch);
        public Lightswitch ReadLightswitch(int id);
        public Lightswitch UpdateLightswitch(Lightswitch lightSwitch);
        public void DeleteLightswitch(Lightswitch lightSwitch);

        public List<Lightswitch> ReadLightswitches();

    }
}
