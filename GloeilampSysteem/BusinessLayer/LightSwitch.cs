using GloeilampSysteem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    public class LightSwitch
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public List<Lamp> Lamps { get; set; }
        
        public LightSwitch(int id, string name)
        {
            Lamps = new List<Lamp>();
            this.Id = id;
            this.Name = name;
            IsOn = false;
        }

        public void ConnectLamp(Lamp theLamp)
        {
            Lamps.Add(theLamp);
            theLamp.ConntectLightSwitch(this);
        }

        public void Toggle()
        {
            // zet de lampen aan
            foreach (var lamp in Lamps)
            {
                lamp.Aanzetten();
            }
        }

        // Data access:
        public void CreateInDb()
        {
            iDataAccessLayer dal = new InMemoryDAL(); // Todo singleton pattern toepassen
            var result = dal.CreateLightSwitch(this);
            this.Id = result.Id;
        }

        public static List<LightSwitch> GetLightSwitchesFromDb()
        {
            iDataAccessLayer dal = new InMemoryDAL(); // Todo singleton pattern toepassen
            return dal.GetLightswitches();
        }

        public static LightSwitch GetLightswitchByIdFromDb(int id)
        {
            iDataAccessLayer dal = new InMemoryDAL();
            return dal.GetLightSwitchById(id);
        }

        public void DeleteInDb()
        {
            iDataAccessLayer dal = new InMemoryDAL();
            dal.DeleteLightSwitchById(this);
        }
    }
}
