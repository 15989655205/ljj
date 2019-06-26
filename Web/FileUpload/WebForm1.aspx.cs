using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.FileUpload
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string i;
            int[][] a = new int[][] { { 1 }, { 1, 2 } };
            for(int i = 0; i<a.Length; i++){      for(int j = 0; j<a[i].Length; j++){     i+= a[i][j];      }  }
        }
    }
}