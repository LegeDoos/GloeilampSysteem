﻿using GloeilampSysteem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.DataAccessLayer
{
    public class SQLDAL : iDataAccessLayer
    {
        string connectionString = "Data Source=.;Initial Catalog=GloeilampSysteem;Integrated Security=True";
        //string connectionString = "Server=LB1908062\\MSSQLSERVER2019;Database=RobsHouseLightning;Integrated Security=True";
        
        List<Lightswitch> lightSwitches = new List<Lightswitch>();

        public SQLDAL()
        {
        }

        public List<Lightswitch> ReadLightswitches()
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
                            var lightSwitch = new Lightswitch(Int32.Parse(reader[0].ToString()),
                                reader[1].ToString());
                            lightSwitch.IsOn = Int32.Parse(reader[2].ToString()) == 1 ? true : false;
                            lightSwitches.Add(lightSwitch);
                        }
                    }
                }

                foreach (var lightSwitch in lightSwitches)
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select id, name, state, ison from Lamp where lightswitchid = @lsid";
                        command.Parameters.AddWithValue("lsid", lightSwitch.Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var lamp = new Lamp(Int32.Parse(reader[0].ToString()), reader[1].ToString());
                                lamp.State = reader[2].ToString();
                                lamp.IsOn = Int32.Parse(reader[3].ToString()) == 1 ? true : false;
                                lightSwitch.ConnectLamp(lamp);
                            }
                        }
                    }

                }
            }            
            return lightSwitches;
        }

        public Lightswitch CreateLightswitch(Lightswitch lightswitch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO LightSwitch(Name, IsOn) VALUES (@name, @ison)";
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", lightswitch.Name);
                    if (lightswitch.IsOn)
                    {
                        command.Parameters.AddWithValue("@ison", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ison", 0);
                    }
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT CAST(@@Identity as INT);";
                    int addId = (int)command.ExecuteScalar();
                    lightswitch.Id = addId;

                }
             
                foreach (var lamp in lightswitch.Lamps)
                {
                    sql = "INSERT INTO Lamp(Name, IsOn, LightSwitchId) VALUES (@name, @ison, @lightswitchid)";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", lamp.Name);
                        if (lightswitch.IsOn)
                        {
                            command.Parameters.AddWithValue("@ison", 1);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ison", 0);
                        }
                        command.Parameters.AddWithValue("@lightswitchid", lightswitch.Id);
                        command.ExecuteNonQuery();

                        command.CommandText = "SELECT CAST(@@Identity as INT);";
                        int addId = (int)command.ExecuteScalar();
                        lamp.Id = addId;
                    }
                }
            }
            return lightswitch;
        }

        public void DeleteLamp(Lamp lamp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM LAMP WHERE ID = @lampid";
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@lampid", lamp.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLightswitch(Lightswitch lightSwitch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // first delete lamps
                string sql = "DELETE FROM LAMP WHERE lightswitchid = @lichtswitchid";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@lichtswitchid", lightSwitch.Id);
                    command.ExecuteNonQuery();
                }

                // finally delete switch
                sql = "DELETE FROM lightswitch WHERE ID = @lightswitchid";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@lightswitchid", lightSwitch.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Lamp ReadLamp(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Haal de lightswitch uit de lijst op basis van het id
        /// </summary>
        /// <param name="id">Het id van de lightswitch</param>
        /// <returns>De gevonden lightswitch</returns>
        public Lightswitch ReadLightswitch(int id)
        {
            Lightswitch toDelete = lightSwitches.Find(ls => ls.Id == id);
            lightSwitches.Remove(toDelete);

            return lightSwitches.Find(ls => ls.Id == id);
        }

        public Lamp UpdateLamp(Lamp lamp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"update lamp set [Name] = @name, IsOn = @ison, State = @state, Lightswitchid = @lightswitchid where id = @id;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", lamp.Name);
                    command.Parameters.AddWithValue("@ison", lamp.IsOn ? 1 : 0);
                    command.Parameters.AddWithValue("@state", lamp.State);
                    command.Parameters.AddWithValue("@lightswitchid", lamp.LightSwitch.Id);
                    command.Parameters.AddWithValue("@id", lamp.Id);
                    command.ExecuteNonQuery();
                }
            }
            return lamp;
        }

        public Lightswitch UpdateLightswitch(Lightswitch lightSwitch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"update LightSwitch set [Name] = @name, IsOn = @ison where id = @id;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", lightSwitch.Name);
                    command.Parameters.AddWithValue("@ison", lightSwitch.IsOn ? 1 : 0);
                    command.Parameters.AddWithValue("@id", lightSwitch.Id);
                    command.ExecuteNonQuery();
                }
                foreach (var lamp in lightSwitch.Lamps)
                {
                    this.UpdateLamp(lamp);
                }
            }
            return lightSwitch;
        }

        public Lamp CreateLamp(Lamp lamp)
        {
            throw new NotImplementedException();
        }
    }
}
