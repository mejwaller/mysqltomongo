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

namespace mysqltomongo
{
    public partial class Form1 : Form
    {

        MySqlConnection conn;
        string hostname;
        string db;
        string username;
        string password; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            hostname = hostname_entry.Text;
            db = db_entry.Text;
            username = username_entry.Text;
            password = passwd_entry.Text;

            //Console.WriteLine("Hostname: " + hostname + " Database: " + db + " Username: " + username + "Password: " + password);

            string connStr = "server=" + hostname+";user=" + username + ";database=" + db + ";password=" + password +";";

            conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("Connected successfully");
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

            string query = "select t.vernacular_name,t.order_name,t.family_name,t.subfamily_name,t.genus_name,t.species_name,t.subspecies_name,t.aberration_name,t.form_name,"
                + "e.record_date,e.record_type,e.grid_ref,e.notes,"
                + "r.count, r.notes "
                + "FROM taxon_data AS t, record_event AS e, record_data AS r "
                + "WHERE t.id=r.taxon_id "
                + "AND r.recevent_id = e.event_id;";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            dataReader.Read();

            //dataReader.
            for (var i = 0; i < dataReader.FieldCount; i++)
            {
                Console.WriteLine(dataReader[i]);
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
