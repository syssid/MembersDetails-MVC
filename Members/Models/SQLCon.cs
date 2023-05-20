using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Members.Models;

namespace Members.Models
{
	public class SQLCon
	{
		public static string cs = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
		public static List<Members> GetData()
		{
			List<Members> list = new List<Members>();
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("SP_VIEWALL", con);
			cmd.CommandType = CommandType.StoredProcedure;
			con.Open();
			SqlDataReader sdr = cmd.ExecuteReader();

			while (sdr.Read())
			{
				list.Add(new Members
				{
					ID =  Convert.ToInt32(sdr["ID"]),
					Name = sdr["Name"].ToString(),
					Phone = sdr["Phone"].ToString(),
					PAN_AADHAR = sdr["PAN_AADHAR"].ToString(),
					Members_ID = sdr["Member_ID"].ToString(),
					DOJ = sdr["DOJ"].ToString(),
					Photo = sdr["Photo"].ToString(),
					IdentificationType = sdr["Doc_Type"].ToString()
				});
			}
			con.Close();
			return list;
		}

		public static bool insertData(Members m)
		{
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("INSERTMEMBER", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@NAME", m.Name);
			cmd.Parameters.AddWithValue("@PHONE", m.Phone);
			cmd.Parameters.AddWithValue("@ADHAR", m.PAN_AADHAR);
			cmd.Parameters.AddWithValue("@DOJ", m.DOJ);
			cmd.Parameters.AddWithValue("@PHOTO", m.Photo);
			cmd.Parameters.AddWithValue("@IDTYPE", m.IdentificationType);
			bool isot;

			con.Open();
			int retval = 100;
			retval = cmd.ExecuteNonQuery();

			if (retval == 100)
			{
				isot = false;
			}
			else
			{
				isot = true;
			}
			con.Close();
			return isot;
		}

		public static List<Members> GetBYid(int id)
		{
			List<Members> list = new List<Members>();
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("GetMemberByID", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", id);
			con.Open();
			SqlDataReader sdr = cmd.ExecuteReader();

			while (sdr.Read())
			{
				list.Add(new Members
				{
					ID = Convert.ToInt32(sdr["ID"]),
					Name = sdr["Name"].ToString(),
					Phone = sdr["Phone"].ToString(),
					PAN_AADHAR = sdr["PAN_AADHAR"].ToString(),
					Members_ID = sdr["Member_ID"].ToString(),
					DOJ = sdr["DOJ"].ToString(),
					Photo = sdr["Photo"].ToString(),
					IdentificationType = sdr["Doc_Type"].ToString()
				});
			}
			con.Close();
			return list;
		}

		public static bool UpdateData(Members m)
		{
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("sp_update_member", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", m.ID);
			cmd.Parameters.AddWithValue("@NAME", m.Name);
			cmd.Parameters.AddWithValue("@PHONE", m.Phone);
			cmd.Parameters.AddWithValue("@ADHAR", m.PAN_AADHAR);
			cmd.Parameters.AddWithValue("@Doc", m.IdentificationType);
			bool isot;

			con.Open();
			int retval = 100;
			retval = cmd.ExecuteNonQuery();

			if (retval == 100)
			{
				isot = false;
			}
			else
			{
				isot = true;
			}

			con.Close();
			return isot;
		}

		public static bool DeleteData(dynamic id)
		{
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("sp_delete_member", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", id);
			con.Open();
			bool isot;
			int retval = 100;
			retval = cmd.ExecuteNonQuery();

			if (retval == 100)
			{
				isot = false;
			}
			else
			{
				isot = true;
			}
			con.Close();
			return isot;
		}
	}
}