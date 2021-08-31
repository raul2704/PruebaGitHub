using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{   
    public class cgestionarpickiu
    {
        public string NoVuelo { get; set; }
        public DateTime FechaVuelo { get; set; }
        public string Ciudad { get; set; }
        public string NoGuia { get; set; }
        public int Origen { get; set; }
        public string GetOrigen
        {
            get 
            {
                using (DBPickiuEntities db = new DBPickiuEntities())
                {
                    Origenes temporigen = db.Origenes.FirstOrDefault(o=>o.id==Origen);
                    if (temporigen != null)
                        return temporigen.Origen;
                    return "";
                } 
            }
        }
    }
}
