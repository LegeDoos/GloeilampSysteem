using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.DataAccessLayer
{
    /// <summary>
    /// Singleton class for the DAL
    /// More info: https://en.wikipedia.org/wiki/Singleton_pattern
    /// </summary>
    public sealed class DALSingleton
    {
        private static IDataAccessLayer instance = null;
        private static readonly object padlock = new object();

        public DALSingleton()
        {
        }

        public static IDataAccessLayer Instance
        {
            get
            {
                lock(padlock)
                {
                    if (instance == null)
                    {
                        //instance = new JsonDAL();
                        instance = new DapperDAL();
                        //instance = new SQLDAL();
                    }
                    return instance;
                }
            }
        }

    }
}
