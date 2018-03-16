using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;

namespace NPGeek.Web.DALS
{
    public class SurveyResultDAL : ISurveyResultDAL
    {
        string connectionString;

        public SurveyResultDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<string> GetParkCodeByVote()
        {
            List<string> parkReturn = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select count(parkCode) as 'count', parkCode from survey_result group by parkCode order by count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        parkReturn.Add(Convert.ToString(reader["parkCode"]));
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return parkReturn;
        }
    }
}