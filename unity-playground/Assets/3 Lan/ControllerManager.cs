using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketGameProtocol;
using System.Reflection;


namespace Assets._3_Lan
{
    class ControllerManager
    {
        Dictionary<RequestCode, BaseController> controllerDict = new Dictionary<RequestCode, BaseController>();
        LanServer server;

        public ControllerManager(LanServer server)
        {
            this.server = server;
            UserController userController = new UserController();
            controllerDict.Add(RequestCode.User, userController);
        }

        void HandleRequest(MainPack pack, LanClient client)
        {
            if (controllerDict.TryGetValue(pack.Requestcode, out BaseController controller))
            {
                string methodName = pack.Actioncode.ToString();
                MethodInfo method = controller.GetType().GetMethod(methodName);

                if (method == null)
                {
                    Console.WriteLine("找不到方法 {0}", methodName);
                    return;
                }


                object[] o = new object[] { server, client, pack };
                object ret = method.Invoke(controller, o);

                if (ret == null)
                    return;

                client.Send(ret as MainPack);
            }
            else
            {
                Console.WriteLine("找不到負責處理的 controller");
            }
        }
    }
}
