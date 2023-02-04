using AssesmentProject.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AssesmentProject.Services
{
    public class Response { 
        public bool status { get; set; }
        public string Message { get; set; }
    }
    public class ContactSvc
    {
        private static Response Result;

        public Response GetResponse() {
            return Result;
        }
        public List<Contact> GetContactsList()
        {
            List<Contact> contactsList = new List<Contact>();
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("usp_Contactmaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetContactsParameters("SELECT", ref cmd, null);
                    using (MySqlDataAdapter adp = new MySqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                        Contact obj;
                        foreach (DataRow dr in dt.Rows)
                        {
                            obj = new Contact();
                            obj.ContactID = AppCommon.IntNullCheck(dr["ContactID"], 0);
                            obj.FirstName = AppCommon.StringNullCheck(dr["FirstName"], "");
                            obj.LastName = AppCommon.StringNullCheck(dr["LastName"], "");
                            obj.Email = AppCommon.StringNullCheck(dr["Email"], "");
                            obj.PhoneNumber = AppCommon.StringNullCheck(dr["PhoneNumber"], "");
                            obj.Address = AppCommon.StringNullCheck(dr["Address"], "");
                            obj.City = AppCommon.StringNullCheck(dr["City"], "");
                            obj.State = AppCommon.StringNullCheck(dr["State"], "");
                            obj.Country = AppCommon.StringNullCheck(dr["Country"], "");
                            obj.PostalCode = AppCommon.StringNullCheck(dr["PostalCode"], "");
                            obj.GeoLat = AppCommon.StringNullCheck(dr["GeoLat"], "");
                            obj.GeoLong = AppCommon.StringNullCheck(dr["GeoLong"], "");
                            obj.CreatedBy = AppCommon.IntNullCheck(dr["CreatedBy"], 0);
                            obj.UpdatedBy = AppCommon.IntNullCheck(dr["UpdatedBy"], 0);
                            contactsList.Add(obj);
                        }
                    }
                    cmd.Dispose();
                    con.Close(); con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Result.status = false;
                Result.Message= ex.Message;
            }

            return contactsList;
        }

        public List<ContactInMap> GetContactsListInMap()
        {
            List<ContactInMap> contactsListInMap = new List<ContactInMap>();
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("usp_Contactmaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetContactsParameters("SELECT_MAP", ref cmd, null);
                    using (MySqlDataAdapter adp = new MySqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                        ContactInMap obj;
                        foreach (DataRow dr in dt.Rows)
                        {
                            obj = new ContactInMap();
                            obj.ContactID = AppCommon.IntNullCheck(dr["ContactID"], 0);
                            obj.FirstName = AppCommon.StringNullCheck(dr["FirstName"], "");
                            obj.PlaceName = AppCommon.StringNullCheck(dr["PlaceName"], "");
                            obj.GeoLat = AppCommon.StringNullCheck(dr["GeoLat"], "");
                            obj.GeoLong = AppCommon.StringNullCheck(dr["GeoLong"], "");
                            contactsListInMap.Add(obj);
                        }
                    }
                    cmd.Dispose();
                    con.Close(); con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Result.status = false;
                Result.Message = ex.Message;
            }

            return contactsListInMap;
        }

        public Contact GetContactsObj(int ContactID)
        {
            Contact contactObj = new Contact();
            contactObj.ContactID = ContactID;
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("usp_Contactmaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetContactsParameters("EDIT", ref cmd, contactObj);
                    using (MySqlDataAdapter adp = new MySqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                        DataRow dr = null; 
                        if (dt.Rows.Count > 0)
                            dr = dt.Rows[0];
                        if (dr != null) {
                            contactObj = new Contact();
                            contactObj.ContactID = AppCommon.IntNullCheck(dr["ContactID"], 0);
                            contactObj.FirstName = AppCommon.StringNullCheck(dr["FirstName"], "");
                            contactObj.LastName = AppCommon.StringNullCheck(dr["LastName"], "");
                            contactObj.Email = AppCommon.StringNullCheck(dr["Email"], "");
                            contactObj.PhoneNumber = AppCommon.StringNullCheck(dr["PhoneNumber"], "");
                            contactObj.Address = AppCommon.StringNullCheck(dr["Address"], "");
                            contactObj.City = AppCommon.StringNullCheck(dr["City"], "");
                            contactObj.State = AppCommon.StringNullCheck(dr["State"], "");
                            contactObj.Country = AppCommon.StringNullCheck(dr["Country"], "");
                            contactObj.PostalCode = AppCommon.StringNullCheck(dr["PostalCode"], "");
                            contactObj.GeoLat = AppCommon.StringNullCheck(dr["GeoLat"], "");
                            contactObj.GeoLong = AppCommon.StringNullCheck(dr["GeoLong"], "");
                            contactObj.CreatedBy = AppCommon.IntNullCheck(dr["CreatedBy"], 0);
                            contactObj.UpdatedBy = AppCommon.IntNullCheck(dr["UpdatedBy"], 0);
                        }
                    }
                    cmd.Dispose();
                    con.Close(); con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Result.status = false;
                Result.Message = ex.Message;
            }

            return contactObj;
        }

        public Response InsertUpdate(ref Contact contactObj)
        {
            Result = new Response();
            Result.status = false;
            Result.Message = "";
            string Mode = contactObj.ContactID == -1 ? "INSERT" : "UPDATE";
            try {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("usp_Contactmaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetContactsParameters(Mode, ref cmd, contactObj);
                    int result = cmd.ExecuteNonQuery();

                    if (Mode == "INSERT")
                    {
                        cmd = new MySqlCommand("usp_Contactmaster", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        GetContactsParameters("MAXID", ref cmd, null);
                        contactObj.ContactID = (int)cmd.ExecuteScalar();
                    }

                    Result.status = result == 1 ? true : false;

                    cmd.Dispose();
                    con.Close(); con.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Uniq_Email"))
                    Result.Message = "Email ID already Exists";
                if (ex.Message.Contains("Uniq_PhNo"))
                    Result.Message = "Phone Number already Exists";
            }
            return Result;
        }

        public Response Delete(Contact contactObj)
        {
            Result = new Response();
            Result.status = false;
            Result.Message = "";
            string Mode =  "DELETE";
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("usp_Contactmaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                GetContactsParameters(Mode, ref cmd, contactObj);
                int result = cmd.ExecuteNonQuery();
                Result.status = result == 1 ? true : false;
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return Result;
        }

        private void GetContactsParameters(string Mode,ref MySqlCommand cmd, Contact contactObj)
        {
            if (contactObj == null)
                contactObj = new Contact();

            cmd.Parameters.Add(new MySqlParameter("?in_Mode", Mode));
            cmd.Parameters.Add(new MySqlParameter("?in_ContactID", contactObj.ContactID));
            cmd.Parameters.Add(new MySqlParameter("?in_FirstName", contactObj.FirstName));
            cmd.Parameters.Add(new MySqlParameter("?in_LastName", contactObj.LastName));
            cmd.Parameters.Add(new MySqlParameter("?in_Email", contactObj.Email));
            cmd.Parameters.Add(new MySqlParameter("?in_PhoneNumber", contactObj.PhoneNumber));
            cmd.Parameters.Add(new MySqlParameter("?in_Address", contactObj.Address));
            cmd.Parameters.Add(new MySqlParameter("?in_City", contactObj.City));
            cmd.Parameters.Add(new MySqlParameter("?in_State", contactObj.State));
            cmd.Parameters.Add(new MySqlParameter("?in_Country", contactObj.Country));
            cmd.Parameters.Add(new MySqlParameter("?in_PostalCode", contactObj.PostalCode));
            cmd.Parameters.Add(new MySqlParameter("?in_GeoLat", contactObj.GeoLat));
            cmd.Parameters.Add(new MySqlParameter("?in_GeoLong", contactObj.GeoLong));
            cmd.Parameters.Add(new MySqlParameter("?in_CreatedBy", contactObj.CreatedBy));
            cmd.Parameters.Add(new MySqlParameter("?in_UpdatedBy", contactObj.UpdatedBy));

        }
    }
}