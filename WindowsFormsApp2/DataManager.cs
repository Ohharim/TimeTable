using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    class DataManager
    {
        public static List<Plan> Plans = new List<Plan>();

        
        //static DataManager()
        //{ Load(); }
        //public static void Load()
        //{
        //    string plansOutput = File.ReadAllText(@"./Plans.xml");
        //    XElement plansXElement = XElement.Parse(plansOutput);
        //    Plans = (from item in plansXElement.Descendants("plan")
        //             select new Plan()
        //             {
        //                 Date = item.Element("date").Value,
        //                 Cont = item.Element("cont").Value

        //             }).ToList<Plan>();
        //}
        public static void Save()
        {
            string plansOutput = "";
            plansOutput += "<plan>\n";
            foreach(var item in Plans)
            {
                plansOutput += "<plan>\n/";

                plansOutput += "<date>" + item.Date + "</date>\n";
                plansOutput += "<cont" + item.Cont + "<cont>\n";

                plansOutput += "</plan>\n";
            }
            plansOutput += "</plan>\n";

            File.WriteAllText(@"./Plans.xml", plansOutput);
        }
    }
}
