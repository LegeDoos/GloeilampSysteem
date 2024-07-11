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
    public class DapperDAL : IDataAccessLayer
    {
        string connectionString = "Server=.;Database=RobsHouseLightning; Integrated Security = True";
        //string connectionString = "Data Source =.; Initial Catalog = GloeilampSysteem; Integrated Security = True";
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
                var parameters = new DynamicParameters();
                parameters.Add("Name", lightSwitch.Name);
                parameters.Add("ison", lightSwitch.IsOn);
                parameters.Add("id", dbType: DbType.Int32, direction: ParameterDirection.Output);                
                connection.Execute("dbo.InsertLightSwitch", parameters, commandType: CommandType.StoredProcedure);
                // set right id for the LightSwitch from db
                var id = parameters.Get<int>("id");
                lightSwitch.Id = id;    
                foreach (var l in lightSwitch.Lamps)
                {
                    var lamppar = new DynamicParameters();
                    lamppar.Add("LSId", id);
                    lamppar.Add("Name", l.Name);
                    lamppar.Add("ison", l.IsOn);
                    lamppar.Add("Lid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.InsertLampsOfLightSwitch", lamppar, commandType: CommandType.StoredProcedure);
                    
                    // connect Lightswitch to correct lamps from db by getting right lampid
                    var Lid = lamppar.Get<int>("Lid");
                    l.Id = Lid;
                }
                return lightSwitch;
            }                                    
        }
        
        public Lightswitch ReadLightswitch(int id) 
        { 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {               
                var lightswitch = connection.QueryFirst<Lightswitch>("dbo.GetLightSwitchById @id", new {id = id});
                //connect lamps to lightswitch
                lightswitch.Lamps = ConnectLampsToLightswitches(lightswitch);
                return lightswitch;
            }    
        }

        public Lightswitch UpdateLightswitch(Lightswitch lightSwitch)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {  
                // UpdateLightSwitch zal ook de bijbehorende lampen aanzetten
                connection.Execute("dbo.UpdateLightSwitch @Id, @Ison", new { Id = lightSwitch.Id, IsOn = lightSwitch.IsOn});
                return ReadLightswitch(lightSwitch.Id);                
            }              
        }
        public void DeleteLightswitch(Lightswitch lightSwitch)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {                                               
                // DeleteLightASwitch will also delete the attached lamps if not change SP DeleteLightSwitch
                connection.Execute("dbo.DeleteLightSwitch @Id", new { Id = lightSwitch.Id} );                 
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
                var lamps = connection.Query<Lamp>("dbo.GetLampsForLightSwitches @LSId", new { LSId = lightSwitch.Id}).ToList();
                return lamps;
            }
        }

        public Lamp CreateLamp(Lamp lamp)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var newlamp = new DynamicParameters();                
                newlamp.Add("Name", lamp.Name);
                newlamp.Add("ison", lamp.IsOn);
                newlamp.Add("LSid", lamp.LightSwitch.Id);
                newlamp.Add("Lid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.InsertLamp", newlamp, commandType: CommandType.StoredProcedure);

                // connect Lightswitch to correct lamps from db by getting right lampid
                var Lid = newlamp.Get<int>("Lid");
                lamp.Id = Lid;
            }
            return lamp;
        }
    }
}
