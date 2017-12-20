
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace hello_ewallet.Models
{
    internal class Messages
    {
        public int Id { get; set; }
        public string Message { get; set; }

       [JsonIgnore]
		public AppDb Db { get; set; }

		public Messages(AppDb db=null)
		{
			Db = db;
		}
    }
}