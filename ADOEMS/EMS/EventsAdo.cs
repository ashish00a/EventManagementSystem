using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class EventsAdo
    {
        public static List<Events> GetAllEvents()
        {
            List<Events> elist = new List<Events>();

            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getall_events", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Events uobj = new Events();
                    uobj.EventId = Convert.ToInt32(sdr["event_id"]);
                    uobj.EventName = Convert.ToString(sdr["event_name"]);
                    uobj.EventType = Convert.ToString(sdr["event_type"]);
                    uobj.EventPrice = Convert.ToInt32(sdr["event_price"]);
                    uobj.EventConsultantPrice = Convert.ToInt32(sdr["event_consultant_price"]);
                    uobj.EventManagementPrice = Convert.ToInt32(sdr["event_managment_price"]);
                    uobj.EventWallet = Convert.ToInt32(sdr["event_wallet"]);
                    elist.Add(uobj);
                }
                con.Close();
            }
            return elist;
        }

        public static Events GetByIdevent(int eid)
        {
            Events eobj = new Events();

            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getbyid_events", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eventid", eid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                    eobj.EventId = Convert.ToInt32(sdr["event_id"]);
                    eobj.EventName = Convert.ToString(sdr["event_name"]);
                    eobj.EventType = Convert.ToString(sdr["event_type"]);
                    eobj.EventPrice = Convert.ToInt32(sdr["event_price"]);
                    eobj.EventConsultantPrice = Convert.ToInt32(sdr["event_consultant_price"]);
                    eobj.EventManagementPrice = Convert.ToInt32(sdr["event_manag" +
                        "ment_price"]);
                    eobj.EventWallet = Convert.ToInt32(sdr["event_wallet"]);

                }
                con.Close();
            }
            return eobj;
        }

        public static void InsertEvents(Events uobj)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_insert_events", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eventname", uobj.EventName);
                cmd.Parameters.AddWithValue("@eventtype", uobj.EventType);
                cmd.Parameters.AddWithValue("@eventprice", uobj.EventPrice);
                cmd.Parameters.AddWithValue("@ecprice", uobj.EventConsultantPrice);
                cmd.Parameters.AddWithValue("@emprice", uobj.EventManagementPrice);
                cmd.Parameters.AddWithValue("@ewallet", uobj.EventWallet);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void UpdatewalletEvents(int amount,int eid)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_updatewallet_events", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ewallet", amount);
                cmd.Parameters.AddWithValue("@eventid", eid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void RemoveEvent(int eid)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_events", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eventid", eid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
