using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
    class BaseRepository
    {
        protected CentiSoftDBContext dbContext;

        public BaseRepository()
        {
            dbContext = new CentiSoftDBContext();
        }
    }
}
