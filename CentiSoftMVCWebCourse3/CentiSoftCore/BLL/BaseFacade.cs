using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.BLL
{
    public class BaseFacade
    {
        protected int clientId;

        public BaseFacade(int clientId)
        {
            this.clientId = clientId;
        }
    }
}
