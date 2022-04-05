using GloeilampSysteem.BusinessLayer;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GloeilampSysteem.DataAccessLayer
{
    public class DapperDAL : iDataAccessLayer
    {
        //string connectionString = "Server=LB1908062\\MSSQLSERVER2019;Database=RobsHouseLightning;User Id=Party;Password=Feest123;";
        string connectionString = "Data Source =.; Initial Catalog = GloeilampSysteem; Integrated Security = True";
        List<Lightswitch> lightSwitches = new List<Lightswitch>();

        public DapperDAL()
        {
                
        }

        public Lamp ReadLamp(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {               
                //Via SQL statement op de volgende manier
                //var output = connection.QueryFirst<Lamp>($"select * from lamp where id = { id }");

                //Via Stored Procedure op SQL server op de volgende manier
                var output = connection.QueryFirst<Lamp>("dbo.GetLampById @id", new {id = id});
                return output;
            }    
        }
        public Lamp UpdateLamp(Lamp lamp)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {                                               
                connection.Execute("dbo.UpdateLamp @Id, @Ison, @State",new { Id = lamp.Id, IsOn = lamp.IsOn, @State = lamp.State});
                return lamp; // waarom??
            }         
        }
        public void DeleteLamp(Lamp lamp)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {                                               
                connection.Execute("dbo.DeleteLamp @Id", new { Id = lamp.Id} );                
            }  
        }

        public Lightswitch CreateLightswitch(Lightswitch lightSwitch)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {               
                List<Lightswitch> newLightSwitch = new List<Lightswitch>();
                newLightSwitch.Add(new Lightswitch(lightSwitch.Id, lightSwitch.Name));
                connection.Execute("dbo.InsertLightSwitch @Id, @Name, @ison", newLightSwitch);
                return lightSwitch;
            }                        
        }
        
        public Lightswitch ReadLightswitch(int id) 
        { 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {               
                var output = connection.QueryFirst<Lightswitch>("dbo.GetLightSwitchById @id", new {id = id});
                //Todo: create lamps
                return output;
            }    
        }

        public Lightswitch UpdateLightswitch(Lightswitch lightSwitch)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {                                               
                connection.Execute("dbo.UpdateLightSwitch @Id, @Ison", new { Id = lightSwitch.Id, IsOn = lightSwitch.IsOn});                
                return lightSwitch; 
            }  
        }
        public void DeleteLightswitch(Lightswitch lightSwitch)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {                                               
                connection.Execute("dbo.DeleteLightSwitch @Id", new { Id = lightSwitch.Id} ); 
                //Todo: delete lamps!
            }  
        }

        public List<Lightswitch> ReadLightswitches()
        {
            lightSwitches.Clear();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {            
                var lightSwitches = connection.Query<Lightswitch>("dbo.GetAllLightSwitches").ToList();
                foreach (var LS in lightSwitches)
                {
                    LS.Lamps = ConnectLampsToLightswitches(LS);
                }
                return lightSwitches;
            }
        }

        public List<Lamp> ConnectLampsToLightswitches(Lightswitch lightSwitch)
        {            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {                
                var lamps = connection.Query<Lamp>("dbo.GetLampsForLightSwitches @id", new { id = lightSwitch.Id}).ToList();
                return lamps;
            }
        }

        public Lamp CreateLamp(Lamp lamp)
        {
            throw new NotImplementedException();
        }
    }
}
