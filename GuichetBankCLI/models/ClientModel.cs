using System.Diagnostics;
using GuichetBanque_HelioBank.controllers;
using GuichetBanque_HelioBank.controllers.parsers;
using GuichetBanque_HelioBank.kernel;
using MySql.Data.MySqlClient;
 
namespace GuichetBanque_HelioBank.models;

public class ClientModel: Factory
{
    // Accessible uniquement au root !
    public void GetClients()
    {
        
    }

    public Client GetClient(string selector, string selectorValue, string valuesToRetrieve)
    {
        //string query = "SELECT" +valuesToRetrieve+ " FROM client ";
        string query = "SELECT * FROM client ";
        switch (selector)
        {
            case "id":
                query += "WHERE id = " + selectorValue;
                break;
            case "email":
                query += " WHERE email = '" + selectorValue + "'"; 
                break;
            default:
                //trouvez un moyen propre de régler cet posibilités
                return null; 
                break;
        }
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        string[] values = new string[6];
        if (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                values[i] = reader.GetString(i);
            }
            return ClientParser.Parse(values);
        }
        closeReader(reader);
        return null;
    }
    
    public bool CreateClient()
    {
        return false;
    }
    
    public bool UpdateClient()
    {
        return false;
    }
    
    public bool RemoveClient()
    {
        return false;
    }
}