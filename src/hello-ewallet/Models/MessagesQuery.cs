using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace hello_ewallet.Models
{
    public class MessagesQuery
    {
        public readonly AppDb Db;
		public MessagesQuery(AppDb db)
		{
			Db = db;
		}

        internal Messages FindOne(int id)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT `Id`, `Message` FROM `Messages` WHERE `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = ReadAll(cmd.ExecuteReader());
            return result.Count > 0 ? result[0] : null;
        }

        private List<Messages> ReadAll(DbDataReader reader)
        {
            var messages = new List<Messages>();
            using (reader)
            {
                while (reader.Read())
                {
                    var message = new Messages(Db)
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Message = reader.GetFieldValue<string>(1),
                    };
                    messages.Add(message);
                }
            }
            return messages;
        }
    }
}