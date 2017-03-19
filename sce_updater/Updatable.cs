using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace SCE_Updater
{
   public interface Updatable
    {
        string ApplicationName { get; }
        string ApplicationId { get; }
        Assembly ApplicationAssembly { get; }
        Icon ApplicationIcon { get; }
        Uri UpdateXmlLocation { get; }
        Form Context { get; }


    }
}
