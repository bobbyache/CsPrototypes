using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace JsonGenerator
{
    public partial class Form1 : Form
    {
        // Binary download: http://json.codeplex.com/
        // http://stackoverflow.com/questions/5554472/create-json-string-from-sqldatareader
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // ... SQL connection and command set up, only querying 1 row from the table
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsonWriter = new JsonTextWriter(sw);
            jsonWriter.Formatting = Formatting.Indented;

            try
            {
                using (SqlConnection theSqlConnection = new SqlConnection("Server=[test_server];Database=[test_database];User Id=sa;Password=admin"))
                {
                    //SqlCommand sqlCommand = new SqlCommand("MSDF_DM.dbo.pFE_Entity_GetWellnessDetails 'DevUser', 1002, 2014, 3, 0", theSqlConnection);
                    SqlCommand sqlCommand = new SqlCommand("test_database.dbo.pFE_Entity_GetDetails", theSqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter userNameParam = new SqlParameter("UserName", "DevUser");
                    userNameParam.Direction = ParameterDirection.Input;
                    userNameParam.DbType = DbType.String;

                    SqlParameter entityIdParam = new SqlParameter("EntityId", 1541);
                    entityIdParam.Direction = ParameterDirection.Input;
                    entityIdParam.DbType = DbType.Int32;

                    SqlParameter yearIdParam = new SqlParameter("YearId", 2014);
                    yearIdParam.Direction = ParameterDirection.Input;
                    yearIdParam.DbType = DbType.Int32;

                    SqlParameter quarterIdParam = new SqlParameter("QuarterId", 3);
                    quarterIdParam.Direction = ParameterDirection.Input;
                    quarterIdParam.DbType = DbType.Int32;

                    //SqlParameter gradeIdParam = new SqlParameter("GradeId", 0);
                    //gradeIdParam.Direction = ParameterDirection.Input;
                    //gradeIdParam.DbType = DbType.Int32;

                    SqlParameter phaseIdParam = new SqlParameter("PhaseId", 0);
                    phaseIdParam.Direction = ParameterDirection.Input;
                    phaseIdParam.DbType = DbType.Int32;

                    SqlParameter phaseSubjectIdParam = new SqlParameter("PhaseSubjectId", 0);
                    phaseSubjectIdParam.Direction = ParameterDirection.Input;
                    phaseSubjectIdParam.DbType = DbType.Int32;

                    sqlCommand.Parameters.Add(userNameParam);
                    sqlCommand.Parameters.Add(entityIdParam);
                    sqlCommand.Parameters.Add(yearIdParam);
                    sqlCommand.Parameters.Add(quarterIdParam);
                    sqlCommand.Parameters.Add(phaseIdParam);
                    sqlCommand.Parameters.Add(phaseSubjectIdParam);

                    //sqlCommand.Parameters.Add(new SqlParameter("UserName",

                    //SqlParameter param1 = new SqlParameter("Dev
                    theSqlConnection.Open(); // open the connection

                    // read the row from the table
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int fieldcount = reader.FieldCount; // count how many columns are in the row
                        object[] values = new object[fieldcount]; // storage for column values
                        reader.GetValues(values); // extract the values in each column

                        jsonWriter.WriteStartObject();
                        for (int index = 0; index < fieldcount; index++)
                        { // iterate through all columns

                            jsonWriter.WritePropertyName(reader.GetName(index)); // column name
                            jsonWriter.WriteValue(values[index]); // value in column

                        }
                        jsonWriter.WriteEndObject();
                        //jsonWriter.Write
                        jsonWriter.WriteWhitespace(Environment.NewLine);
                    }
                    reader.Close();
                }
            }
            catch (SqlException sqlException)
            { // exception
                //context.Response.ContentType = "text/plain";
                //context.Response.Write("Connection Exception: ");
                //context.Response.Write(sqlException.ToString() + "\n");
            }
            finally
            {
                //theSqlConnection.Close(); // close the connection
            }
            richTextBox1.Text = sw.ToString();
            // END of method
            // the above method returns sb and another uses it to return as HTTP Response...
            //StringBuilder theTicket = getInfo(context, ticketID);
            //context.Response.ContentType = "application/json";
            //context.Response.Write(theTicket);
        }
    }
}
