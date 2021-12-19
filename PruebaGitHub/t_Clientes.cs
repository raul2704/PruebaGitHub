using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
   public partial class Clientes
   {
        public Image Foto
        {
            get 
            {
                if (!string.IsNullOrEmpty(urlfoto) && System.IO.File.Exists(urlfoto))
                    return Image.FromFile(urlfoto);
                return null;
            }
        }
         
   }
}
