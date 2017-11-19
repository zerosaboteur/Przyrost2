using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;

namespace ZapisXmlJsonSql
{
    class Program
    {
        static void Main(string[] args)
        {
            int last = Ktoreostatnio();

            //zapis jesli json byl ostatnio
            if (last == 0)
            {
                StreamReader r = new StreamReader("testowe.json");
                string json = r.ReadToEnd();

                string json1 = "{\\root\\:" + json + "}";
                string json2 = json1.Replace(@"\", "");

                XNode node = JsonConvert.DeserializeXNode(json);
                File.WriteAllText(@"json.xml", node.ToString());
            }
            //zapis jesli xml byl ostatnio
            if (last == 1)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load("json.xml");
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                File.WriteAllText(@"testowe.json", jsonText.ToString());
                Console.WriteLine("xml byl ostatnio");
            }
            //zapis jesli sql byl ostatnio, problemy z polaczeniem sie do bazy danych
            /*
            if (last == 2)
            {
                const string strSql = "SELECT * FROM Albumy";

                using (SqlCommand sqlComm = new SqlCommand(strSql,conn) { CommandType = CommandType.Text })
                {
                    SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ds.Tables[0].WriteXml(@"text.xml");
                }
            }*/

            Console.ReadLine();
        }

        private static int Ktoreostatnio()
        {
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
 