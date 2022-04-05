﻿using GloeilampSysteem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    /// <summary>
    /// Represents a lamp
    /// </summary>
    public class Lamp
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public string State { get; set; }

        [System.Text.Json.Serialization.JsonIgnore] // json serializer loop error voorkomen
        public LightSwitch? LightSwitch { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The unique identifier of the lamp</param>
        /// <param name="name">The name of the lamp</param>
        public Lamp(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Turn on the lamp
        /// </summary>
        public virtual void TurnOn()
        {
            IsOn = true;
            State = "Aan";
        }

        /// <summary>
        /// Turn off the lamp
        /// </summary>
        public virtual void TurnOff()
        {
            IsOn = false;
            State = "Uit";
        }

        /// <summary>
        /// Connect the lightswitch to this lamp
        /// </summary>
        /// <param name="theSwitch">The lightswitch to connect to</param>
        public void ConnectLightswitch(LightSwitch theSwitch)
        {
            this.LightSwitch = theSwitch;
        }

        // Data access:

        /// <summary>
        /// Persist this lamp in datalayer
        /// </summary>
        public void Create()
        {
            // controles zouden hier plaats moeten vinden

            // business model heeft weet van de DAL en kan deze ook benaderen (zie ook usings)

            iDataAccessLayer dal = DAL.Instance; // dit is nu een singleton maar kan een nieuwe instantie van de DAL zijn.
            var result = dal.CreateLamp(this);
            this.Id = result.Id;
        }

        /// <summary>
        /// Read a specific lamp from the datalayer
        /// </summary>
        /// <param name="id">The id of the specific lamp</param>
        /// <returns>The specific lamp</returns>
        public static Lamp Read(int id)
        {
            iDataAccessLayer dal = DAL.Instance;
            return dal.GetLampById(id);
        }

        /// <summary>
        /// Persist the changes on the lamp in the datalayer (update)
        /// </summary>
        /// <returns>The updated lamp</returns>
        public Lamp Update()
        {
            iDataAccessLayer dal = DAL.Instance;
            return dal.UpdateLamp(this);
        }

        /// <summary>
        /// Delete this lamp from the datalayer
        /// </summary>
        public void Delete()
        {
            iDataAccessLayer dal = DAL.Instance;
            dal.DeleteLampById(this);
        }
    }
}
