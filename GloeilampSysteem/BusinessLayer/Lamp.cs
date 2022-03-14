using GloeilampSysteem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    public class Lamp
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public string State { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public LightSwitch? LightSwitch { get; set; }

        
        public Lamp(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public virtual void Aanzetten()
        {
            IsOn = true;
            State = "Aan";
            Console.WriteLine($"Lamp {this.Name} staat {this.State}!");
        }

        public virtual void Uitzetten()
        {
            IsOn = false;
            State = "Uit";
            Console.WriteLine($"Lamp {this.Name} staat {this.State}!");

        }
        public void ConntectLightSwitch(LightSwitch theSwitch)
        {
            this.LightSwitch = theSwitch;
        }

        // Data access:
        public static Lamp GetLightswitchByIdFromDb(int id)
        {
            iDataAccessLayer dal = new InMemoryDAL();
            return dal.GetLampById(id);
        }

        public void DeleteInDb()
        {
            iDataAccessLayer dal = new InMemoryDAL();
            dal.DeleteLampById(this);
        }
    }
}
