using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Werewolf_kill_v2.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Werewolf_kill_v2.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class gaming : Page
    {
        List<Player> playerList;//玩家List
        List<AI> aiList;//AIList
        List<Controler> controlerlist;//控制者List
        int gamestatus;//游戏状态，详见Werewolf_kill_v2.Model.VictoryCondition
        bool werewolfWin;//狼人狼人是否获胜
        bool humanWin;//人类是否获胜
        int playernum;//玩家人数
        int controlernum;//总游戏人数
        public gaming()
        {
            this.InitializeComponent();
        }
        public void TheGame() //整个游戏进程
        {
            GameInitialize(playernum,controlernum);
            for(int i=0;;i++)//用无限循环来开始首夜直到游戏终止状态达成
            {
                if(i==0)//首夜
                {
                    //首夜操作()
                }
                if(i==1)//第一天
                {
                    //
                }
                if (i == 2)//第二天
                {
                    //
                }


                if (gamestatus ==(int)VictoryCondition.Gamestatus.所有狼人死亡)
                {
                    humanWin = true;
                    break;
                }
                if (gamestatus == (int)VictoryCondition.Gamestatus.所有平民死亡||
                    gamestatus == (int)VictoryCondition.Gamestatus.所有神民死亡||
                    gamestatus == (int)VictoryCondition.Gamestatus.剩余狼人数大于人类数)
                {
                    humanWin = true;
                    break;
                }
            }
        }
        public void GameInitialize(int playernum, int controlernum)//游戏初始化
        {
            playerList = new List<Player>();   //获取玩家信息并存入List
            aiList = new List<AI>();//生成并获取AI信息并存入List


            controlerlist = new List<Controler>();//将所有控制者信息存入一个List
            for (int i = 0; i < playerList.Count - 1; i++)
            {
                controlerlist[i] = playerList[i];
            }
            for (int i = controlerlist.Count; i < aiList.Count - 1; i++)
            {
                controlerlist[i] = aiList[i];
            }


            controlerlist = RandomRoleAssign(controlerlist, controlernum);//分配控制者角色
        }
        public List<Controler> RandomRoleAssign(List<Controler> controlers,int playernum)//随机分配控制者角色方法
        {
            Random random = new Random();
            List<Controler> newList = new List<Controler>();
            foreach (Controler item in controlers)
            {
                newList.Insert(random.Next(newList.Count), item);
            }
            switch (playernum)//随机分散后的控制者角色分配
            {
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    newList[0].Role = new Langren();
                    newList[1].Role = new Langren();
                    newList[2].Role = new Langren();
                    newList[3].Role = new Langren();
                    newList[4].Role = new Cunmin();
                    newList[5].Role = new Cunmin();
                    newList[6].Role = new Cunmin();
                    newList[7].Role = new Cunmin();
                    newList[8].Role = new Yuyanjia();
                    newList[9].Role = new Jingzhang();
                    newList[10].Role = new Nvwu();
                    newList[11].Role = new Lieren();
                    break;
            }
            for(int i=0;i<newList.Count-1;i++)
            {
                controlers[newList[i].Sn]=newList[i];
            }
            return controlers;
        }
        public void StartNight(List<Controler> controlers)//首夜方法
        {

        }
    }
}
