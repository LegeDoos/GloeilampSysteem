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
    public class JsonDAL : IDataAccessLayer
    {
        List<Lightswitch> lightswitches = new List<Lightswitch>();
        readonly string lightswitchesFileName = "lightswitches.json";

        public JsonDAL()
        {
            this.GetFromFile();
            if (lightswitches.Count == 0)
            {
                // create dummydata
                this.CreateDummyData();        
            }
        }

        private void GetFromFile()
        {
            try
            {
                lightswitches = JsonSerializer.Deserialize<List<Lightswitch>>(File.ReadAllText(lightswitchesFileName));
            }
            catch (Exception)
            {
                lightswitches?.Clear();
            }
        }
        
        private void SaveToFile()
        {
            File.WriteAllText(lightswitchesFileName, JsonSerializer.Serialize(lightswitches));

        }
        private void CreateDummyData()
        {
            Lightswitch lightswitch = new Lightswitch(1, "Lightswitch 1");
            lightswitch.ConnectLamp(new Lamp(1, "Lamp 1"));
            lightswitch.ConnectLamp(new Lamp(2, "Lamp 2"));
            lightswitch.ConnectLamp(new Lamp(3, "Lamp 3"));
            lightswitch.ConnectLamp(new Lamp(4, "Lamp 4"));
            lightswitches.Add(lightswitch);

            Lightswitch lightswitch2 = new Lightswitch(2, "Lightswitch 2");
            lightswitch2.ConnectLamp(new Lamp(5, "Lamp 5"));
            lightswitch2.ConnectLamp(new Lamp(6, "Lamp 6"));
            lightswitches.Add(lightswitch2);

            this.SaveToFile();
        }


        public Lightswitch CreateLightswitch(Lightswitch lightswitch)
        {
            // create ids
            int maxId = lightswitches.Count == 0 ? 1 : lightswitches.Max(l => l.Id) + 1;
            lightswitch.Id = maxId++;
            if (lightswitch.Lamps?.Count > 0)
            {
                maxId = lightswitch.Lamps.Max(l => l.Id) + 1;
                foreach (var lamp in lightswitch.Lamps)
                {
                    lamp.Id = maxId++;
                }
            }

            lightswitches.Add(lightswitch);
            this.SaveToFile();
            return lightswitch;
        }

        public void DeleteLamp(Lamp lamp)
        {
            // get the lightswitch
            lamp.LightSwitch?.Lamps?.Remove(lamp);
            this.SaveToFile();
        }

        public void DeleteLightswitch(Lightswitch lightSwitch)
        {
            lightswitches.Remove(lightSwitch);
            this.SaveToFile();
        }

        public Lamp ReadLamp(int id)
        {
            throw new NotImplementedException("Not implemented");
        }

        public Lightswitch ReadLightswitch(int id)
        {
            return lightswitches.Find(x => x.Id == id);
        }

        public List<Lightswitch> ReadLightswitches()
        {
            return lightswitches; 
        }

        public Lamp UpdateLamp(Lamp lamp)
        {
            throw new NotImplementedException("Not implemented");
        }

        public Lightswitch UpdateLightswitch(Lightswitch lightSwitch)
        {
            // replace the lightswitch
            var toDelete = lightswitches.Find(x => x.Id == lightSwitch.Id);
            lightswitches.Remove(toDelete);
            lightswitches.Add(lightSwitch);

            this.SaveToFile();
            return lightSwitch;
        }

        public Lamp CreateLamp(Lamp lamp)
        {
            // Add the lamp to the list of lamps of the lightswitch if not exists
            if (lamp.LightSwitch == null)
            {
                throw new Exception("Geen lichtschakelaar ingesteld!");
            }
            else
            {
                if (lamp.LightSwitch.Lamps == null)
                {
                    lamp.LightSwitch.Lamps = new List<Lamp>();
                }
                if (!lamp.LightSwitch.Lamps.Contains(lamp))
                {
                    // create id
                    lamp.Id = lamp.LightSwitch.Lamps.Count == 0 ? 1 : lamp.LightSwitch.Lamps.Max(l => l.Id) + 1;
                    // add to lightswitch
                    lamp.LightSwitch.Lamps.Add(lamp);
                }
            }
            this.SaveToFile();
            return lamp;
        }
    }
}
