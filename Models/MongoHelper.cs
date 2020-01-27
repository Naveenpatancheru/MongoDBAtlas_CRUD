using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
namespace Crud_MongoDB.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb+srv://naveenpatancheru:Ericcartman9985@clustertest-pgxht.mongodb.net/test?retryWrites=true&w=majority";
        public static string MongoDatabase = "crud_mongodb";
        public static IMongoCollection<Models.Docket> dockets_collection{ get; set; }
        internal static void ConnectionToMongo()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception ex)
            { 
            }
        }
    }
}