using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_kill_v2.Model
{
    public class Controler//控制者，父类
    {
        private Roles role; //角色
        public Roles Role { get => role; set => role = value; }
        private int sn;//序号(从0开始)
        public int Sn { get => sn; set => sn = value; }
        public  Controler(Roles role_,int sn_) //角色初始化
        {
            Role = role_;
            Sn = sn_;
            if (Role.Rolename == "Cunmin")
            {
                Role = new Cunmin();
            }
            if (Role.Rolename == "Langren")
            {
                Role = new Langren();
            }
            if (Role.Rolename == "Yuyanjia")
            {
                Role = new Yuyanjia();
            }
            if (Role.Rolename == "Jingzhang")
            {
                Role = new Jingzhang();
            }
            if (Role.Rolename == "Nvwu")
            {
                Role = new Nvwu();
            }
            if (Role.Rolename == "Lieren")
            {
                Role = new Lieren();
            }
        }
    }
    public class AI : Controler//电脑AI
    {
        public AI(Roles role_, int sn_) :base(role_, sn_)
        {
            
        }
    }
    public class Player : Controler//玩家
    {
        public Player(Roles role_, int sn_) : base(role_, sn_)
        {

        }
    }
}
