using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_kill_v2.Model
{
    public class Roles
    {
        public string Rolename;    //角色名称
        public string Isalive;     //是否存活

        public void setRoles(string rolename)
        {
            Rolename = rolename;
        }
    }
    class Cunmin : Roles
    {
        
    }
    class Langren : Roles
    {

    }
    class Yuyanjia : Roles
    {

    }
    class Jingzhang : Roles
    {

    }
    class Nvwu : Roles
    {

    }
    class Lieren : Roles
    {

    }
}
