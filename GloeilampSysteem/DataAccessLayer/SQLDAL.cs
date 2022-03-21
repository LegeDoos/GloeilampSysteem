using GloeilampSysteem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.DataAccessLayer
{
    public class SQLDAL 
        : iDataAccessLayer
    {
        string connectionString = "Data Source=.;Initial Catalog=GloeilampSysteem;Integrated Security=True";
        List<LightSwitch> lightSwitches = new List<LightSwitch>();

        public SQLDAL()
        {
        }

        public List<LightSwitch> GetLightswitches()
        {
            lightSwitches.Clear();            

            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select id, name, ison from LightSwitch";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var lightSwitch = new LightSwitch(Int32.Parse(reader[0].ToString()),
                                reader[1].ToString());
                            lightSwitch.IsOn = Int32.Parse(reader[0].ToString()) == 1 ? true : false;
                            lightSwitches.Add(lightSwitch);
                        }
                    }
                }
            }

            
            return lightSwitches;
        }


        public LightSwitch CreateLightSwitch(LightSwitch lightSwitch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO LightSwitch(Name, IsOn) VALUES (@name, @ison)";
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", lightSwitch.Name);
                    if (lightSwitch.IsOn)
                    {
                        command.Parameters.AddWithValue("@ison", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ison", 0);
                    }
                    command.ExecuteNonQuery();
                }
            }
            return lightSwitch;
        }

        public void DeleteLampById(Lamp lamp)
        {

            throw new NotImplementedException();

        }

        public void DeleteLightSwitchById(LightSwitch lightSwitch)
        {
            throw new NotImplementedException();
        }

        public Lamp GetLampById(int id)
        {
            throw new NotImplementedException();
        }

        public LightSwitch GetLightSwitchById(int id)
        {
            throw new NotImplementedException();
        }

        public Lamp UpdateLamp(Lamp lamp)
        {
            throw new NotImplementedException();
        }

        public LightSwitch UpdateLightSwitch(LightSwitch lightSwitch)
        {
            throw new NotImplementedException();
        }


    }
}
