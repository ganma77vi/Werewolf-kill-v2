using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Werewolf_kill_v2.Model
{
    public class Controler//控制者，父类
    {
        private Roles role; //角色
        private int sn;//序号(从0开始)
        private bool isalive;     //是否存活
        private bool ifincampaign;//是否曾参与警察竞选
        private int campaignvoteSn;//上警投票给谁
        private int campaignvotes;//上警得票数
        private float dayvoteSn;//放逐投票给谁
        private float dayvotes;//被放逐得票数
        private int killvotes;//被杀投票数
        private bool iseyeopen;//是否睁眼
        private bool isAI;//是否AI
        private int deadday;//死亡时间
        public Roles Role { get => role; set => role = value; }
        public int Sn { get => sn; set => sn = value; }
        public bool Isalive { get => isalive; set => isalive = value; }
        public bool Ifincampaign { get => ifincampaign; set => ifincampaign = value; }
        public int CampaignvoteSn { get => campaignvoteSn; set => campaignvoteSn = value; }
        public int Campaignvotes { get => campaignvotes; set => campaignvotes = value; }
        public float DayvoteSn { get => dayvoteSn; set => dayvoteSn = value; }
        public float Dayvotes { get => dayvotes; set => dayvotes = value; }
        public int Killvotes { get => killvotes; set => killvotes = value; }
        public bool Iseyeopen { get => iseyeopen; set => iseyeopen = value; }
        public bool IsAI { get => isAI; set => isAI = value; }
        public int Deadday { get => deadday; set => deadday = value; }

        public  Controler(int sn_) //sn初始化赋值
        {
            Sn = sn_;
            Isalive = true;
            Deadday = -1;
        }
        public void Speak()
        {

        }
        public void Openeyes(TextBlock tb)
        {
            iseyeopen = true;
            tb.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        public void Closeeyes(TextBlock tb)
        {
            iseyeopen = false;
            tb.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
    public class AI : Controler//电脑AI
    {
        public AI(int sn_) :base(sn_)
        {
            IsAI = true;
        }
    }
    public class Player : Controler//玩家
    {
        public Player(int sn_) : base(sn_)
        {
            IsAI = false;
        }
    }
}
