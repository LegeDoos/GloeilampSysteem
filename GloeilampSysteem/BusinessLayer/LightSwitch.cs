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
    public class Lightswitch
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public bool IsOn { get; set; } = false;

        public List<Lamp>? Lamps { get; set; }

        /// <summary>
        /// Default constructor. Do not use. Needed for deserialization of json files
        /// </summary>
        public Lightswitch()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The unique identifier of a lightswitch</param>
        /// <param name="name">The name of the lightswitch</param>
        public Lightswitch(int id, string name)
        {
            Lamps = new List<Lamp>();
            this.Id = id;
            this.Name = name;
            IsOn = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the lightswitch</param>
        public Lightswitch(string name)
        {
            Lamps = new List<Lamp>();
            this.Name = name;
            IsOn = false;
        }

        /// <summary>
        /// Connect the lamp to the lightswitch and create relation in both directions
        /// </summary>
        /// <param name="theLamp">The lamp to connect to the lightswitch</param>
        public void ConnectLamp(Lamp theLamp)
        {
            Lamps?.Add(theLamp);
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
                    lamp.TurnOff();
                }
                else
                {
                    lamp.TurnOn();
                }
            }
            this.IsOn = !this.IsOn;
        }

        // Data access:
        
        /// <summary>
        /// Persist this lightswitch in datalayer
        /// </summary>
        public void Create()
        {
            // controles zouden hier plaats moeten vinden
            if (Id != 0)
            {
                throw new Exception("Kan geen schakelaar aanmaken als de schakelaar al een id heeft (schakelaar bestaat al?)");
            }

            // business model heeft weet van de DAL en kan deze ook benaderen (zie ook usings)

            IDataAccessLayer dal = DAL.Instance; // dit is nu een singleton maar kan een nieuwe instantie van de DAL zijn.
            var result = dal.CreateLightswitch(this);
            this.Id = result.Id;
        }

        /// <summary>
        /// Get all lightswitches from datalayer
        /// </summary>
        /// <returns>A list with all lightswitches</returns>
        public static List<Lightswitch> Read()
        {
            IDataAccessLayer dal = DAL.Instance; 
            return dal.ReadLightswitches();
        }

        /// <summary>
        /// Get specific lightswitch from database
        /// </summary>
        /// <param name="id">The id of the specific lightswitch</param>
        /// <returns>The specific lightswitch</returns>
        public static Lightswitch Read(int id)
        {
            IDataAccessLayer dal = DAL.Instance;
            return dal.ReadLightswitch(id);
        }

        /// <summary>
        /// Persist the changes on the lightswitch in the datalayer (update)
        /// </summary>
        /// <returns>The updated lightswitch</returns>
        public Lightswitch Update()
        {
            IDataAccessLayer dal = DAL.Instance;
            return dal.UpdateLightswitch(this);
        }

        /// <summary>
        /// Delete this lightswitch from the datalayer
        /// </summary>
        public void Delete()
        {
            IDataAccessLayer dal = DAL.Instance;
            dal.DeleteLightswitch(this);
        }
    }
}
