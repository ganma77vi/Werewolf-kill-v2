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
        public Pingmin()
        {
            Rolename = "平民";
        }
    }
    class Langren : Roles
    {
        private List<int> killvotelist;//刀人投票给谁

        public List<int> Killvotelist { get => killvotelist; set => killvotelist = value; }

        public Langren()
        {
            Rolename = "狼人";
            Killvotelist = new List<int>();
        }

        public void SelfExplosion()//自爆方法
        {

        }
    }
    class Yuyanjia : Roles
    {
        private int roleCheck;//查验谁
        private List<int> checklist;//查验了哪些人

        public int RoleCheck { get => roleCheck; set => roleCheck = value; }
        public List<int> Checklist { get => checklist; set => checklist = value; }

        public void CheckRole()//查验方法
        {
        }
        public Yuyanjia()
        {
            Rolename = "预言家";
            Checklist = new List<int>();
        }
    }
    class Jingzhang : Roles
    {
        public Jingzhang()
        {
            Rolename = "警长";
        }
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
        public Nvwu()
        {
            Rolename = "女巫";
        }
    }
    class Lieren : Roles
    {
        public int shootSn;//射谁
        public Lieren()
        {
            Rolename = "猎人";
        }
    }
    class Baichi : Roles
    {
        public Baichi()
        {
            Rolename = "白痴";
        }
    }
}
