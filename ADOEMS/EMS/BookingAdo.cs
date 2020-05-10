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
    public class BookingAdo
    {
        public static List<Events> GetAllBookings()
        {
            List<Events> elist = new List<Events>();

            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getall_bookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Events uobj = new Events();
                    uobj.BookingId = Convert.ToInt32(sdr["booking_id"]);
                    uobj.EventId = Convert.ToInt32(sdr["event_id"]);
                    uobj.UserId = Convert.ToInt32(sdr["user_id"]);
                    uobj.BookingDate = Convert.ToDateTime(sdr["booking_date"]);
                    uobj.PaymentStatus = Convert.ToString(sdr["payment_status"]);
                    elist.Add(uobj);
                }
                con.Close();
            }
            return elist;
        }

        public static Events GetByIdBooking(int bid)
        {
            Events eobj = new Events();

            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getbyid_bookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookingid", bid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                    eobj.BookingId = Convert.ToInt32(sdr["booking_id"]);
                    eobj.EventId = Convert.ToInt32(sdr["event_id"]);
                    eobj.UserId = Convert.ToInt32(sdr["user_id"]);
                    eobj.BookingDate = Convert.ToDateTime(sdr["booking_date"]);
                    eobj.PaymentStatus = Convert.ToString(sdr["payment_status"]);

                }
                con.Close();
            }
            return eobj;
        }
        public static void InsertBookings(Events uobj)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_insert_bookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eventid", uobj.EventId);
                cmd.Parameters.AddWithValue("@userid", uobj.UserId);
                cmd.Parameters.AddWithValue("@bookingdate", uobj.BookingDate);
                cmd.Parameters.AddWithValue("@pstatus", uobj.PaymentStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void UpdatePayStatusBookings(string paystatus,int bid)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_updatepaystatus_bookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@paystatus", paystatus);
                cmd.Parameters.AddWithValue("@bookingid", bid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void RemoveBooking(int bid)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_boookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookingid", bid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
