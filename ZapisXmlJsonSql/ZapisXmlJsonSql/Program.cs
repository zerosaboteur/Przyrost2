using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft;
using System.IO;
using System.Xml.Linq;
using System.Data;
namespace ZapisXmlJsonSql
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = 2;
            do
            {
                Console.WriteLine("Czy chesz zaktualizować po bazie sql?(1-tak/0-nie)");
                string temp = Console.ReadLine();
                test = Int32.Parse(temp);
            } while (test > 1);

            if (test == 0)
            {
                int last = Ktoreostatnio();

                //zapis jesli json byl ostatnio
                if (last == 0)
                {
                    //plik wczytania json
                    StreamReader r = new StreamReader("testowe.json");
                    string json = r.ReadToEnd();

                    string json1 = "{\\root\\:" + json + "}";
                    string json2 = json1.Replace(@"\", "");

                    XNode node = JsonConvert.DeserializeXNode(json);
                    //plik zapisu xml
                    File.WriteAllText(@"json.xml", node.ToString());
                }
                //zapis jesli xml byl ostatnio
                else if (last == 1)
                {

                    XmlDocument doc = new XmlDocument();
                    //plik wczytania xml
                    doc.Load("json.xml");
                    string jsonText = JsonConvert.SerializeXmlNode(doc);
                    //plik zapisu json
                    File.WriteAllText(@"testowe.json", jsonText.ToString());
                }
            }
            //zapis jesli sql byl ostatnio
            else
            {
                //W pierwszym string nalezy uzyskac połaczeie ze swoja baza dabych mozna to zrobic poprzez tool/connect to database a nastepnie w prawym dolnym rogu pobrac connection string
                string connectionString = "Data Source=localhost;Initial Catalog=pracowniapo;Integrated Security=True";
                //Należy wybrać tabelę, która chcemy zaisać do xml
                string queryString = "SELECT * FROM Pracownicy;";
                const string strSql = "SELECT * FROM Pracownicy";
                SqlConnection con = new SqlConnection(connectionString);
                using (SqlCommand sqlComm = new SqlCommand(queryString, con) { CommandType = CommandType.Text })
                {
                    SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //plik zapisu xml
                    ds.Tables[0].WriteXml(@"json.xml");
                }
                XmlDocument doc = new XmlDocument();
                //plik wczytania xml
                doc.Load("json.xml");
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                //plik zapisu json
                File.WriteAllText(@"testowe.json", jsonText.ToString());
            }

            Console.ReadLine();
        }

        private static int Ktoreostatnio()
        {
            //pliki wczytania json i xml
            DateTime json = File.GetLastWriteTime(@"testowe.json");
            DateTime xml = File.GetLastWriteTime(@"json.xml");
            if (json > xml)
            {
                return 0;
            }
            else if (xml > json)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
 