using InterviewQuestions.Model;  
using Microsoft.Extensions.Configuration;  
using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;  
namespace InterviewQuestions.DAL  
{  
public class FooDAL  
{  
   private string _connectionString;  
   public FooDAL(IConfiguration iconfiguration)  
   {  
      _connectionString = iconfiguration.GetConnectionString("Default");  
   }  

   public string GetConnectionString(){
      return string.IsNullOrEmpty(_connectionString)?"Got no connection string" : $"Connection string is: {_connectionString}";
   }
   public List<FooModel> GetFooUsersWithAllEvents(){
      var listFooModel = new List<FooModel>();  
      try  
      {  
         using (SqlConnection con = new SqlConnection(_connectionString))  
         {  
               var query = "use MsProblems; " +
                           "select distinct a.UserId from foo a " +
                           "inner join (select count(*)cnt, UserId from foo " +
                           "where Event in ('Launch', 'Checked','Submit') " +
                           "group by UserId " +
                           "having count(*) = 3)b on a.UserId = b.UserId";

               SqlCommand cmd = new SqlCommand(query, con);  
               cmd.CommandType = CommandType.Text;  
               con.Open();  
               SqlDataReader rdr = cmd.ExecuteReader();  
               while (rdr.Read())  
               {  
                  listFooModel.Add(new FooModel  
                  {  
                     UserId = rdr[0].ToString(),  
                  });  
               }                 
            }  
         }  
         catch (Exception ex)  
         {  
            Console.WriteLine("");
            Console.WriteLine("Exception Thrown: ");
            Console.WriteLine(ex.Message);  
            Console.WriteLine(""); 
         }  
         return listFooModel;  
   }
   
   public List<FooModel>ListFooTable(){
       var listFooModel = new List<FooModel>();
      try  
      {  
         using (SqlConnection con = new SqlConnection(_connectionString))  
         {  
               var query = "use MsProblems; " +
                           "select UserId, Event from foo;";

               SqlCommand cmd = new SqlCommand(query, con);  
               cmd.CommandType = CommandType.Text;  
               con.Open();  
               SqlDataReader rdr = cmd.ExecuteReader();  
               while (rdr.Read())  
               {  
                  listFooModel.Add(new FooModel  
                  {  
                     UserId = rdr[0].ToString(),
                     Event = rdr[1].ToString()  
                  });  
               }                 
            }  
         }  
         catch (Exception ex)  
         {  
            Console.WriteLine("");
            Console.WriteLine("Exception Thrown: ");
            Console.WriteLine(ex.Message);  
            Console.WriteLine("");
         }  
         return listFooModel;      
   }
   public List<FooModel> GetList()  
   {  
      var listFooModel = new List<FooModel>();  
      try  
      {  
         using (SqlConnection con = new SqlConnection(_connectionString))  
         {  
               SqlCommand cmd = new SqlCommand("SP_COUNTRY_GET_LIST", con);  
               cmd.CommandType = CommandType.StoredProcedure;  
               con.Open();  
               SqlDataReader rdr = cmd.ExecuteReader();  
               while (rdr.Read())  
            {  
                  listFooModel.Add(new FooModel  
                   {  
                     Event = "",  
                     UserId = "" 
                  });  
               }                 
            }  
         }  
         catch (Exception ex)  
         {  
               throw ex;  
         }  
         return listFooModel;  
      }  
   }  
}  