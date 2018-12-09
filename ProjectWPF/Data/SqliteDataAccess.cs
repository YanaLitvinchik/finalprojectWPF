using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPF
{
    class SqliteDataAccess
    {
        public static ObservableCollection<Alcohol> LoadAlcohol()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Alcohol>("select * from AlcoholItemFinal", new DynamicParameters());
                return new ObservableCollection<Alcohol>(output);
            }
            
        }

        public static void UpdateItem(Alcohol alc)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string cmd = $@"update AlcoholItemFinal 
                                set Name = {alc.Name}, Manufacturer={alc.Manufacturer},Year={alc.Year},Type={alc.Type}
                                where Id={alc.Id};";
                cnn.Execute(cmd);
            }
        }
        public static void SaveItem(Alcohol alcohol)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into AlcoholItemFinal (Image,Name,Manufacturer,Year,Type) values (@Image,@Name,@Manufacturer,@Year,@Type)", alcohol);
            }
        }
        public static void DeleteItem(Alcohol alcohol)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"delete from AlcoholItemFinal where Id = {alcohol.Id};");
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
