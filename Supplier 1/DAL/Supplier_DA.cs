using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Supplier_1.DAL
{
    public class Supplier_DA
    {
        public static SqlDataReader getReader_ForAllPrograms()
        {
            string constr = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;

            SqlConnection con = new SqlConnection(constr);

            string cmdtext = "SELECT * FROM Service";

            SqlCommand cmd = new SqlCommand(cmdtext, con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }

        public static string getAllServices()
        {

            string sql = "SELECT * FROM Service";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["Supplier"].ToString());
            DataSet ds = new DataSet();
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);

        }

        public static List<int> getServiceIDs()
        {
            List<int> ids = new List<int>();

            string constr = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;

            SqlConnection con = new SqlConnection(constr);

            string cmdtext = "SELECT sID FROM Service";

            SqlCommand cmd = new SqlCommand(cmdtext, con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ids.Add(int.Parse(dr["sID"].ToString()));
            }

            con.Close();
            dr.Close();

            return ids;
        }

        public static string getServiceNames()
        {
            List<string> names = new List<string>();

            string constr = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;

            SqlConnection con = new SqlConnection(constr);

            string cmdtext = "SELECT sName FROM Service";

            SqlCommand cmd = new SqlCommand(cmdtext, con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                names.Add(dr["sName"].ToString());
            }

            con.Close();
            dr.Close();

            return JsonConvert.SerializeObject(names, Newtonsoft.Json.Formatting.Indented);
        }

        public static string getServiceID(string name)
        {

            string constr = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;

            SqlConnection con = new SqlConnection(constr);

            string cmdtext = "SELECT sID FROM Service WHERE sName = @name";

            SqlCommand cmd = new SqlCommand(cmdtext, con);
            cmd.Parameters.AddWithValue("@name", name);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            string json = "";
            if (dr.Read())
            {
                json = JsonConvert.SerializeObject(dr["sID"].ToString(), Newtonsoft.Json.Formatting.Indented);
            }

            con.Close();
            dr.Close();

            return json;
        }

        public static int addService(string sShortDesc, string sLongDesc, string sName)
        {
            string constr = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;

            SqlConnection con = new SqlConnection(constr);

            string cmdtext = "INSERT INTO Service(sName, sShortDesc, sLongDesc) VALUES (@a, @b, @c);";

            SqlCommand cmd = new SqlCommand(cmdtext, con);
            cmd.Parameters.AddWithValue("@a", sName);
            cmd.Parameters.AddWithValue("@b", sShortDesc);
            cmd.Parameters.AddWithValue("@c", sLongDesc);
          

            con.Open();
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        
    }
}