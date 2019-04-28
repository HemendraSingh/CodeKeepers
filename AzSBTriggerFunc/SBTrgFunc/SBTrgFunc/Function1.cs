using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;

namespace SBTrgFunc
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("queue1", AccessRights.Manage, Connection = "SBConn")]string myQueueItem, TraceWriter log)
        {
            var json_obj = JsonConvert.DeserializeObject<UserAnswer>(myQueueItem);

            SqlConnection conn = new SqlConnection("Initial Catalog=HackathonDB;Data Source= hackathondbsrv.database.windows.net;User ID=Hackathon;Password=Danske@123");
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "insert into QuizAnswers(UserQuizId,QuestionId,Answer) values(" + json_obj.UserQuestionId + "," + json_obj.QuestionId + ",'" + json_obj.Answer + "')";
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
            }        
        }
        
        class UserAnswer
        { 
            public int UserQuestionId { get; set; }
            public int QuestionId { get; set; }
            public string Answer { get; set; }
        }
    }
}
