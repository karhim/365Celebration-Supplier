using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Supplier_1.DAL
{
    public class Service
    {
        private string connStr = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;
        private string sID, sName, sShortDesc, sLongDesc, image, status;


        private int sTypeID, vendorID, quantity;
        private decimal price;
        private DateTime datetime;

        public Service()
        {

        }
       

        public Service(string image)
        {
            this.image = image;
        }

        public Service(string sID, string sName, string image, string sShortDesc, decimal price)
        {
            this.sID = sID;
            this.sName = sName;
            this.image = image;
            this.sShortDesc = sShortDesc;
            this.price = price;
        }

        public Service(string sID, string sName, string image, string sShortDesc, string sLongDesc, decimal price)
        {
            this.sID = sID;
            this.sName = sName;
            this.image = image;
            this.sLongDesc = sLongDesc;
            this.sShortDesc = sShortDesc;
            this.price = price;
        }

        public Service(string sName, string sShortDesc, decimal price, string image)
        {
            this.sName = sName;
            this.sShortDesc = sShortDesc;
            this.price = price;
            this.image = image;
        }

        public Service(string sID, string sShortDesc, int quantity, decimal price)
        {
            this.sID = sID;
            this.sShortDesc = sShortDesc;
            this.quantity = quantity;
            this.price = price;
        }

        public Service(string sID, string sName, int quantity, decimal price, DateTime datetime, string status)
        {
            this.sID = sID;
            this.sName = sName;
            this.quantity = quantity;
            this.price = price;
            this.datetime = datetime;
            this.status = status;
        }

        public Service(int sTypeID, int vendorID, string sName, string sShortDesc, string sLongDesc, int quantity, decimal price, string status)
        {
            this.sTypeID = sTypeID;
            this.vendorID = vendorID;
            this.sName = sName;
            this.sShortDesc = sShortDesc;
            this.sLongDesc = sLongDesc;
            this.quantity = quantity;
            this.price = price;
            this.status = status;
        }

        public DateTime gsDatetime
        {
            get { return datetime; }
            set { datetime = value; }
        }

        public string gsImage
        {
            get { return image; }
            set { image = value; }
        }

        public string gssID
        {
            get { return sID; }
            set { sID = value; }
        }

        public int gssTypeID
        {
            get { return sTypeID; }
            set { sTypeID = value; }
        }
        public int gsvendorID
        {
            get { return vendorID; }
            set { vendorID = value; }
        }
        public string gssName
        {
            get { return sName; }
            set { sName = value; }
        }

        public string gssShortDesc
        {
            get { return sShortDesc; }
            set { sShortDesc = value; }
        }

        public string gssLongDesc
        {
            get { return sLongDesc; }
            set { sLongDesc = value; }
        }

        public int gsQuantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string gsStatus
        {
            get { return status; }
            set { status = value; }
        }

        public decimal gsPrice
        {
            get { return price; }
            set { price = value; }
        }

        public List<Service> serviceSearch(string name)
        {
            List<Service> servList = new List<Service>();
            string sName, status, sID;
            DateTime pDateAdded;
            int quantity;
            decimal price;

            string queryStr = "SELECT * FROM Service WHERE sName LIKE '%' + @sName + '%'";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@sName", name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sID = dr["sID"].ToString();
                sName = dr["sName"].ToString();
                quantity = int.Parse(dr["sQuantity"].ToString());
                price = decimal.Parse(dr["sPrice"].ToString());
                pDateAdded = DateTime.Parse(dr["sDateAdded"].ToString());
                status = dr["sStatus"].ToString();

                Service serv = new Service(sID, sName, quantity, price, pDateAdded, status);
                servList.Add(serv);
            }
            con.Close();
            dr.Close();
            dr.Dispose();

            return servList;
        }

        public int ServiceDelete(string id)
        {
            string queryStr = "";
            queryStr = "DELETE FROM ServiceImage WHERE sID = @sID";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@sID", id);
            con.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            queryStr = "DELETE FROM Service WHERE sID = @sID";
            cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@sID", id);
            nofRow += cmd.ExecuteNonQuery();
            con.Close();
            return nofRow;
        }
        public int ServiceStatusUpdate(string prodid, int status)
        {
            string queryStr = "UPDATE Service SET sStatus = @sStatus WHERE sID = @sID";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@sID", prodid);
            cmd.Parameters.AddWithValue("@sStatus", status);
            con.Open();
            int nOfRow = 0;
            nOfRow = cmd.ExecuteNonQuery();
            con.Close();
            return nOfRow;
        }

        public int ServiceUpdate(string id, string sName, int quantity, decimal price)
        {
            string queryStr = "UPDATE Service SET sName = @sName, sQuantity = @sQuantity, sPrice = @sPrice WHERE sID = @sID";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@sID", id);
            cmd.Parameters.AddWithValue("@sName", sName);
            cmd.Parameters.AddWithValue("@sQuantity", quantity);
            cmd.Parameters.AddWithValue("@sPrice", price);

            con.Open();
            int nOfRow = 0;
            nOfRow = cmd.ExecuteNonQuery();
            con.Close();
            return nOfRow;
        }

        public int ServiceInsert(int id)
        {
            int result = 0;

            string queryStr = "INSERT INTO Service(sTypeID,sName, sShortDesc, sLongDesc, sQuantity, sPrice, sDateAdded, sStatus) VALUES(@sTypeID, @sName, @sShortDesc, @sLongDesc, @sQuantity, @sPrice, @sDateAdded, @sStatus)";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);

            cmd.Parameters.AddWithValue("@sTypeID", this.sTypeID);

            cmd.Parameters.AddWithValue("@sName", this.sName);
            cmd.Parameters.AddWithValue("@sShortDesc", this.sShortDesc);
            cmd.Parameters.AddWithValue("@sLongDesc", this.sLongDesc);
            cmd.Parameters.AddWithValue("@sQuantity", this.quantity);
            cmd.Parameters.AddWithValue("@sPrice", this.price);
            cmd.Parameters.AddWithValue("@sDateAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@sStatus", this.status);

            con.Open();
            result += cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int ServiceImageInsert()
        {
            int result = 0;
            string queryStr = "INSERT INTO ServiceImage(sID, sImage) VALUES((SELECT MAX(sID) FROM Service), @sImage)";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue(@"sImage", this.image);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public Service getService(string sid)
        {
            Service serv = null;
            string sName, sShortDesc, sID, sImage, sLongdesc;
            decimal price;

            string queryStr = "SELECT s.sID, s.sName, s.sShortDesc, s.sLongDesc, si.sImage, s.sPrice FROM Service s INNER JOIN ServiceImage si ON s.sID = si.sID WHERE s.sID = @sID";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@sID", sid);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                sID = dr["sID"].ToString();
                sName = dr["sName"].ToString();
                sImage = dr["sImage"].ToString();
                sShortDesc = dr["sShortDesc"].ToString();
                sLongdesc = dr["sLongDesc"].ToString();
                price = decimal.Parse(dr["sPrice"].ToString());

                serv = new Service(sID, sName, sImage, sShortDesc, sLongdesc, price);
            }
            else
            {
                serv = null;
            }
            con.Close();
            dr.Close();
            dr.Dispose();
            return serv;
        }

        public List<Service> getAllService(int id)
        {
            List<Service> servList = new List<Service>();
            string sName, sID, status;
            DateTime sDateAdded;
            int quantity;
            decimal price;

            string queryStr = "SELECT sID, sName, sQuantity, sPrice, sDateAdded, sStatus FROM Service WHERE vendorID = @vendorID";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@vendorID", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sID = dr["sID"].ToString();
                sName = dr["sName"].ToString();
                quantity = int.Parse(dr["sQuantity"].ToString());
                price = decimal.Parse(dr["sPrice"].ToString());
                sDateAdded = DateTime.Parse(dr["sDateAdded"].ToString());
                status = dr["sStatus"].ToString();

                Service serv = new Service(sID, sName, quantity, price, sDateAdded, status);
                servList.Add(serv);
            }
            con.Close();
            dr.Close();
            dr.Dispose();

            return servList;
        }
    }
}