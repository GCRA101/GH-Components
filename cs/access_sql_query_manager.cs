using System.Data.OleDb;

public class Script_Instance_access_sql_query_manager : GH_ScriptInstance
{
    public void RunScript(
        string query,
        bool trigger,
        ref object A)
    {
        if (!trigger) return;
        
            // Update the path to your Access database file
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\Users\galbieri\Desktop\WORK\GST Sports Boulevard\2025-07-07 M72 - BMU Left Top Corner\accessFiles\gst_hyperflex.accdb;";
            List<string> output = new List<string>();
        
            try
            {
              using (OleDbConnection connection = new OleDbConnection(connString))
              {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataReader reader = cmd.ExecuteReader();
        
                while (reader.Read())
                {
                  var row = "";
                  for (int i = 0; i < reader.FieldCount; i++)
                    row += reader.GetValue(i).ToString() + (i < reader.FieldCount - 1 ? ", " : "");
                  output.Add(row);
                }
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