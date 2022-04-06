using GloeilampSysteem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    /// <summary>
    /// Wrapper to get DAL info
    /// </summary>
    public class DataAccessLayerInfo
    {
        public string DALName 
        { 
            get
            {
                return DAL.Instance.GetType().Name;
            }
        }
    }
}
