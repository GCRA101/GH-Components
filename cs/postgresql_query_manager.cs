using Npgsql;

public class Script_Instance_postgresql_query_manager : GH_ScriptInstance
{
    public void RunScript(
        string x,
        bool y,
        ref object A)
    {
        if (!trigger) return;
        
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=Burjkhalifa828@()@;Database=buroHappold";
            List<string> output = new List<string>();
        
            try
            {
              NpgsqlConnection connection = new NpgsqlConnection(connString);
        
              connection.Open();
              NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
              NpgsqlDataReader reader = cmd.ExecuteReader();
        
              while (reader.Read())
              {
                var row = "";
                for (int i = 0; i < reader.FieldCount; i++)
                  row += reader.GetValue(i).ToString() + (i < reader.FieldCount - 1 ? ", " : "");
                output.Add(row);
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine("Error: " + ex.Message);
            }
        
            data = output;
            return;
    }
}