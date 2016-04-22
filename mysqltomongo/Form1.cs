using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

using MongoDB.Bson;
using MongoDB.Driver; 

namespace mysqltomongo
{
    public partial class Form1 : Form
    {

        MySqlConnection conn;
        MongoClient mong;
        //MongoServer mongserver;
        IMongoDatabase mongdb;
        string mysqlhostname;
        string mysqldb;
        string mysqlusername;
        string mysqlpassword; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mysqlhostname = hostname_entry.Text;
            mysqldb = db_entry.Text;
            mysqlusername = username_entry.Text;
            mysqlpassword = passwd_entry.Text;

            //Console.WriteLine("Hostname: " + hostname + " Database: " + db + " Username: " + username + "Password: " + password);

            string connStr = "server=" + mysqlhostname+";user=" + mysqlusername + ";database=" + mysqldb + ";password=" + mysqlpassword +";";

            conn = new MySqlConnection(connStr);
            mong = new MongoClient();
            //mongserver = mong.GetServer();

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("Connected to MySQL successfully");
                Console.WriteLine("Connecting to MongodDB..");
                //mong.GetDatabase("mongmoths");
                mongdb = mong.GetDatabase("test2");

                Console.WriteLine("Connected to MongoDB successfully");
                getRecords();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            

            conn.Close();
            Console.WriteLine("Done");


        }

        private void getRecords()
        {
            //Doesn't select empty record events! (i.e. dates where trap was run but nothing caught) 
            string query = "select t.vernacular_name,t.order_name,t.family_name,t.subfamily_name,t.genus_name,t.species_name,t.subspecies_name,t.aberration_name,t.form_name,"
                + "e.record_date,e.record_type,e.grid_ref,e.notes,"
                + "r.count, r.notes "
                + "FROM taxon_data AS t, record_event AS e, record_data AS r "
                + "WHERE t.id=r.taxon_id "
                + "AND r.recevent_id = e.event_id;";

            string recev_query = "select * from record_event;";

            /*
             var doc = new BsonDocument
             {
                {"date", new DateTime(YYYY,MM,DD,0,0,0, DateTimeKind.Utc)}, //from e.record_date,
                {"type", "descriptive string"}, //from e.record_type
                {"grid_ref", "grid ref string"}, //from e.grid_ref, may not be present
                {"notes", "notes string"}, //from e.record_notes, may not be present
                {"species", new BsonArray //entry for each species caught, may be empty for dates where nohting was caught
                    {
                        new BsonDocument
                        {
                            {"vernacular name", "common name string"},//from t.vernacular_name - may not be present
                            {"order","order string"},//from t.order_name
                            {"family","family string"}, //from t.family_name
                            {"sub-family","subfamily string"}, //from t.subfamily_name - may not be present
                            {"genus","genus string"}, //from t.genus_name
                            {"species","species string"}, //from t.species_name
                            {"sub-species","subspeciees string"}, //from t.subspecies_name - may not be present
                            {"aberration","aberration string"}, //from t.aberration_name - may not be present
                            {"form","form string"}, //from t.form_name - may not be present
                            {"count", count }, //from r.count
                            {"notes","notes string"} from r.notes - may not be present
                        },
                        new BsonDocument
                        {
                            ...etc
                        }
                    }
                }
            }
            */          
                

            MySqlCommand cmd = new MySqlCommand(recev_query, conn);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<int> recevent_ids = new List<int>();

            var collection = mongdb.GetCollection<BsonDocument>("records");

            //empty the database
            var empty = new BsonDocument();
            collection.DeleteMany(empty);

            while (dataReader.Read())
            {                

                int id_as_int = 0;

                bool isInt = int.TryParse(dataReader[0].ToString(), out id_as_int);

                if(isInt)
                {
                    recevent_ids.Add(id_as_int);
                }
                else
                {
                    Console.WriteLine("ERROR: Cannot convert record event id " + dataReader[0] + " to an int!");
                    return;
                }

                string date = dataReader[1].ToString();

                DateTime dt;
                // Specify exactly how to interpret the string.
                IFormatProvider culture = new System.Globalization.CultureInfo("en-GB", true);
                
                try 
                {
                    dt = Convert.ToDateTime(date);
                    Console.WriteLine("Year: {0}, Month: {1}, Day: {2}",dt.Year, dt.Month, dt.Day);
                }
                catch(FormatException)
                {
                    Console.WriteLine("ERROR: Couldn't convert {0} to a DateTime",dataReader[1]);
                    return;
                }
                              
                
                //dataReader.
                for (var i = 0; i < dataReader.FieldCount; i++)
                {
                    
                    if(dataReader[i].ToString().Length > 0){ 
                        Console.WriteLine(dataReader.GetName(i) + " : " + dataReader[i]);
                    }                    
                }

                BsonDocument doc = new BsonDocument {
                        {"Date",dt},
                        {"Type",dataReader[2].ToString()},
                        {"Grid Ref",dataReader[3].ToString()},
                        {"Notes",dataReader[4].ToString()}
                    };

                Console.WriteLine(doc.ToString());

                collection.InsertOne(doc);
                //await collection.InsertOneAsync(doc);

                /*foreach(int item in recevent_ids)
                {
                    Console.WriteLine(item.ToString());
                }*/


            }

            dataReader.Close();
            

            /*
            select t.vernacular_name, 
                t.order_name,
                t.family_name,  
                t.subfamily_name,
                t.genus_name, 
                t.species_name, 
                t.subspecies_name, 
                t.aberration_name, 
                t.form_name, 

                e.record_date, 
                e.record_type, 
                e.grid_ref,
                e.notes,

                r.count, r.notes 
                
                FROM taxon_data AS t, record_event AS e, record_data AS r 
                    
                WHERE t.id=r.taxon_id 
            
                AND r.recevent_id = e.event_id 
            
                AND e.record_date > '2014-12-31' AND e.record_date < '2016-01-01' 
            
                INTO outfile '2015recevents1.csv' fields terminated by ',' enclosed by '"' lines terminated by '\n';
             * */


        }
    }
}
