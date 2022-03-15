using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.DataAccessLayer
{
    public sealed class DAL
    {
        private static iDataAccessLayer instance = null;
        private static readonly object padlick = new object();

        public DAL()
        {
        }

        public static iDataAccessLayer Instance
        {
            get
            {
                lock(padlick)
                {
                    if (instance == null)
                    {
                        instance = new JsonDAL();
                    }
                    return instance;
                }
            }
        }
    }
}
