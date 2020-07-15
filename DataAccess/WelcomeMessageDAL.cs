using System;
using System.Collections.Generic;
using System.Text;
using Entities.WelcomeMessage;
using System.Linq;

namespace DataAccess
{
    public class WelcomeMessageDAL
    {
        private static StringBuilder _sqlBuilder = new StringBuilder();

        public static WelcomeMessage Load(DayOfWeek dayOfWeek)
        {
            _sqlBuilder.Clear();
            _sqlBuilder.AppendLine("SELECT DayOfWeek, MessageEN, MessageFR, MessageDE, ImageBase64");
            _sqlBuilder.AppendLine("FROM WelcomeMessage");
            _sqlBuilder.AppendLine($"WHERE DayOfWeek = '{(int)dayOfWeek}'");

            var query = _sqlBuilder.ToString();

            var welcomeMessage = SqlDataAccess.LoadData<WelcomeMessage>(query).FirstOrDefault();

            if (welcomeMessage == null)
            {
                DevHelper.ResetDBData(); // fills the DB with default data if empty --> DEBUG ONLY
                welcomeMessage = SqlDataAccess.LoadData<WelcomeMessage>(query).FirstOrDefault();
            }

            return welcomeMessage;
        }

        public static int Save(WelcomeMessage welcomeMessage)
        {
            _sqlBuilder.Clear();
            _sqlBuilder.AppendLine("INSERT INTO WelcomeMessage");
            _sqlBuilder.AppendLine("(DayOfWeek, MessageEN, MessageFR, MessageDE, ImageBase64)");
            _sqlBuilder.AppendLine("VALUES (@DayOfWeek, @MessageEN, @MessageFR, @MessageDE, @ImageBase64)");

            var query = _sqlBuilder.ToString();

            return SqlDataAccess.SaveData(query, welcomeMessage);
        }

        public static int DeleteAll()
        {
            var query = "DELETE FROM WelcomeMessage";

            return SqlDataAccess.ExecuteQuery(query);
        }
    }
}
