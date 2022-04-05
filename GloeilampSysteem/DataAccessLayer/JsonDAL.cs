using GloeilampSysteem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GloeilampSysteem.DataAccessLayer
{
    /// <summary>
    /// Dit zou in een betere vorm een singleton worden (singleton pattern) om te voorkomen dat er telkens een nieuwe instance wordt gemaakt!
    /// </summary>
    public class JsonDAL : iDataAccessLayer
    {
        List<Lightswitch> lightSwitches = new List<Lightswitch>();
        string lightSwitchesFileName = "lightswitches.json";

        public JsonDAL()
        {
            this.GetFromFile();
            if (lightSwitches.Count == 0)
            {
                // create dummydata
                this.CreateDummyData();        
            }
        }

        private void GetFromFile()
        {
            try
            {
                lightSwitches = JsonSerializer.Deserialize<List<Lightswitch>>(File.ReadAllText(lightSwitchesFileName));
            }
            catch (Exception)
            {
                lightSwitches.Clear();
            }
        }
        
        private void SaveToFile()
        {
            File.WriteAllText(lightSwitchesFileName, JsonSerializer.Serialize(lightSwitches));

        }
        private void CreateDummyData()
        {
            Lightswitch lightswitch = new Lightswitch(1, "Lightswitch 1");
            lightswitch.ConnectLamp(new Lamp(1, "Lamp 1"));
            lightswitch.ConnectLamp(new Lamp(2, "Lamp 2"));
            lightswitch.ConnectLamp(new Lamp(3, "Lamp 3"));
            lightswitch.ConnectLamp(new Lamp(4, "Lamp 4"));
            lightSwitches.Add(lightswitch);

            Lightswitch lightswitch2 = new Lightswitch(2, "Lightswitch 2");
            lightswitch2.ConnectLamp(new Lamp(5, "Lamp 5"));
            lightswitch2.ConnectLamp(new Lamp(6, "Lamp 6"));
            lightSwitches.Add(lightswitch2);

            this.SaveToFile();
        }


        public Lightswitch CreateLightswitch(Lightswitch lightSwitch)
        {
            lightSwitches.Add(lightSwitch);
            this.SaveToFile();
            return lightSwitch;
        }

        public void DeleteLamp(Lamp lamp)
        {
            // get the lightswitch
            lamp.LightSwitch.Lamps.Remove(lamp);
            this.SaveToFile();
        }

        public void DeleteLightswitch(Lightswitch lightSwitch)
        {
            lightSwitches.Remove(lightSwitch);
            this.SaveToFile();
        }

        public Lamp ReadLamp(int id)
        {
            throw new NotImplementedException("Not implemented");
        }

        public Lightswitch ReadLightswitch(int id)
        {
            return lightSwitches.Find(x => x.Id == id);
        }

        public List<Lightswitch> ReadLightswitches()
        {
            return lightSwitches; 
        }

        public Lamp UpdateLamp(Lamp lamp)
        {
            throw new NotImplementedException("Not implemented");
        }

        public Lightswitch UpdateLightswitch(Lightswitch lightSwitch)
        {
            // replace the lightswitch
            var toDelete = lightSwitches.Find(x => x.Id == lightSwitch.Id);
            lightSwitches.Remove(toDelete);
            lightSwitches.Add(lightSwitch);

            this.SaveToFile();
            return lightSwitch;
        }

        public Lamp CreateLamp(Lamp lamp)
        {
            throw new NotImplementedException();
        }
    }
}
