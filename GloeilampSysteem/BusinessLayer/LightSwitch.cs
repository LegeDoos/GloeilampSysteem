using GloeilampSysteem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    /// <summary>
    /// Represents a lightswitch
    /// </summary>
    public class LightSwitch
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public List<Lamp> Lamps { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The unique identifier of a lightswitch</param>
        /// <param name="name">The name of the lightswitch</param>
        public LightSwitch(int id, string name)
        {
            Lamps = new List<Lamp>();
            this.Id = id;
            this.Name = name;
            IsOn = false;
        }

        /// <summary>
        /// Connect the lamp to the lightswitch and create relation in both directions
        /// </summary>
        /// <param name="theLamp">The lamp to connect to the lightswitch</param>
        public void ConnectLamp(Lamp theLamp)
        {
            Lamps.Add(theLamp);
            theLamp.ConnectLightswitch(this);
        }

        /// <summary>
        /// Toggle the lightswitch
        /// </summary>
        public void Toggle()
        {
            // zet de lampen aan
            foreach (var lamp in Lamps)
            {
                if (lamp.IsOn)
                {
                    lamp.Uitzetten();
                }
                else
                {
                    lamp.Aanzetten();
                }
            }
        }

        // Data access:
        
        /// <summary>
        /// Persist this lightswitch in datalayer
        /// </summary>
        public void Create()
        {
            // controles zouden hier plaats moeten vinden
            
            // business model heeft weet van de DAL en kan deze ook benaderen (zie ook usings)

            iDataAccessLayer dal = DAL.Instance; // dit is nu een singleton maar kan een nieuwe instantie van de DAL zijn.
            var result = dal.CreateLightSwitch(this);
            this.Id = result.Id;
        }

        /// <summary>
        /// Get all lightswitches from datalayer
        /// </summary>
        /// <returns>A list with all lightswitches</returns>
        public static List<LightSwitch> Read()
        {
            iDataAccessLayer dal = DAL.Instance; // Todo singleton pattern toepassen
            return dal.GetLightswitches();
        }

        /// <summary>
        /// Get specific lightswitch from database
        /// </summary>
        /// <param name="id">The id of the specific lightswitch</param>
        /// <returns>The specific lightswitch</returns>
        public static LightSwitch Read(int id)
        {
            iDataAccessLayer dal = DAL.Instance;
            return dal.GetLightSwitchById(id);
        }

        /// <summary>
        /// Persist the changes on the lightswitch in the datalayer (update)
        /// </summary>
        /// <returns>The updated lightswitch</returns>
        public LightSwitch Update()
        {
            iDataAccessLayer dal = DAL.Instance;
            return dal.UpdateLightSwitch(this);
        }

        /// <summary>
        /// Delete this lightswitch from the datalayer
        /// </summary>
        public void Delete()
        {
            iDataAccessLayer dal = DAL.Instance;
            dal.DeleteLightSwitch(this);
        }
    }
}
