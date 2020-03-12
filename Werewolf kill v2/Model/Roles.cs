using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_kill_v2.Model
{
    public class Roles
    {
        private string rolename;    //角色名称

        public string Rolename { get => rolename; set => rolename = value; }
    }
    class Pingmin : Roles
    {
        
    }
    class Langren : Roles
    {
        private int killvoteSn;//刀人投票给谁

        public int KillvoteSn { get => killvoteSn; set => killvoteSn = value; }

        public void SelfExplosion()//自爆方法
        {

        }
    }
    class Yuyanjia : Roles
    {
        private int roleCheck;//查验谁

        public int RoleCheck { get => roleCheck; set => roleCheck = value; }
        public void CheckRole()//查验方法
        {

        }
    }
    class Jingzhang : Roles
    {

    }
    class Nvwu : Roles
    {
        private int poisonSn;//毒谁
        private int antidoteSn;//救谁
        private bool ispoisonused;//毒药是否被使用
        private bool isantidoteused;//解药是否被使用
        private bool isselfantidote;//是否可自救

        public int PoisonSn { get => poisonSn; set => poisonSn = value; }
        public int AntidoteSn { get => antidoteSn; set => antidoteSn = value; }
        public bool Ispoisonused { get => ispoisonused; set => ispoisonused = value; }
        public bool Isantidoteused { get => isantidoteused; set => isantidoteused = value; }
        public bool Isselfantidote { get => isselfantidote; set => isselfantidote = value; }
        public void UsePoison()//毒药方法
        {

        }
        public void UseAntidote()//解药方法
        {

        }
    }
    class Lieren : Roles
    {
        public int shootSn;//射谁
    }
    class Baichi : Roles
    {

    }
}
