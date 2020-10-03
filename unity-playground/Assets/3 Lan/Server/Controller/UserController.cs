using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketGameProtocol;

namespace Assets._3_Lan
{
    class UserController : BaseController
    {
        public UserController()
        {
            requestCode = RequestCode.User;
            
        }
        public MainPack Logon(LanServer server, LanClient client, MainPack pack)
        {
            if (client.Logon(pack))
            {
                pack.Returncode = ReturnCode.Success;                
            }
            else
            {
                pack.Returncode = ReturnCode.Fail;                
            }
            return pack;
        }
    }
}
