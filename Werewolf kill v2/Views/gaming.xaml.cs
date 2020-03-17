using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Werewolf_kill_v2.Model;
using Werewolf_kill_v2.UserControls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        #region 该页面中的全局变量定义
        List<Player> playerList;//玩家List
        List<AI> aiList;//AIList
        ObservableCollection<Controler> controlerlist;//控制者List
        ObservableCollection<Controler> langrenlist;//狼人控制者list
        List<Langren> langrenlist1;//狼人角色对象list
        ObservableCollection<Controler> pingminlist;//平民控制者list
        List<Pingmin> pingminlist1;//平民角色对象list
        Controler yuyanjia;//预言家的控制者对象
        Yuyanjia yuyanjia1;//预言家的角色对象
        Controler nvwu;//女巫的控制者对象
        Nvwu nvwu1;//女巫的角色对象
        Controler lieren;//猎人的控制者对象
        Lieren lieren1;//猎人的角色对象
        Controler baichi;//白痴的控制者对象
        Baichi baichi1;//白痴的角色对象
        int gamestatus;//游戏终止状态，详见Werewolf_kill_v2.Model.VictoryCondition
        bool werewolfWin;//狼人是否获胜
        bool humanWin;//人类是否获胜
        List<TextBlock> roletblist;//显示角色名称的textblock列表
        private TaskCompletionSource<object> continueClicked;
        Viewmodel.ControlerViewModel controlerViewModel;
        #endregion
        public gaming()
        {
            this.InitializeComponent();
            controlerViewModel = new Viewmodel.ControlerViewModel();
            this.DataContext = controlerViewModel;
            TheGame();
        }
        #region 游戏进程
        public async void TheGame() //整个游戏进程
        {
            GameInitialize((Application.Current as App).playernum, (Application.Current as App).controlernum);
            #region 游戏配置播报
            string a, b, c, d, e,f;
            if ((Application.Current as App).isSelfExplosion)
            {
                if((Application.Current as App).isSingleExplosion)
                    a = "本局游戏配置如下：\n狼人单爆\n";
                else
                    a = "本局游戏配置如下：\n狼人双爆\n";
            }
            else
                a = "本局游戏配置如下：\n狼人不可自爆\n";
            if ((Application.Current as App).isSelfAntidote)
                b = "女巫可自救\n";
            else
                b = "女巫不可自救\n";
            if ((Application.Current as App).isKillAll)
                c = "狼人获胜条件为屠城\n";
            else
                c = "狼人获胜条件为屠边\n";
            c = "两人平票时PK" + (Application.Current as App).PKnum.ToString() + "轮\n";
            d = "每人的发言时间为" + (Application.Current as App).speaktime.ToString() + "s\n";
            e = "警长发言时间为" + (Application.Current as App).sheriffspeaktime.ToString() + "s\n";
            f = "每人的遗言时间为" + (Application.Current as App).lastwordtime.ToString() + "s\n";
            recordTB.Text +=a+b+c+d+e+f;
            #endregion
            for (int i=0;;i++)//用无限循环来开始首夜直到游戏终止状态达成
            {
                if(i==0)//首夜
                {
                    await CallMessageDialog("首夜");
                    StartNight();
                }
                if(i==1)//第一天
                {
                    //第一天方法
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
        #endregion
        #region 游戏初始化方法
        public void GameInitialize(int playernum, int controlernum)
        {
            playerList = new List<Player>();   //获取玩家信息并存入List
            for (int i = 0; i < playernum; i++)
            {
                playerList.Add(new Player(i));
            }
            aiList = new List<AI>();//生成并获取AI信息并存入List
            for (int i = playernum; i < controlernum; i++)
            {
                aiList.Add(new AI(i));
            }

            roletblist = new List<TextBlock>();
            controlerlist = new ObservableCollection<Controler>();//将所有控制者信息存入一个List
            for (int i = 0; i < playerList.Count; i++)
            {
                controlerlist.Add(playerList[i]);
            }
            for (int i = 0; i < controlernum - playernum; i++)
            {
                controlerlist.Add(aiList[i]);
            }
            controlerViewModel.Controlers=controlerlist;

            RandomRoleAssign(controlerlist, controlernum);//分配控制者角色
        }
        #endregion
        #region 随机分配控制者角色并进行所有角色对象初始化方法
        public void RandomRoleAssign(ObservableCollection<Controler> controlers,int playernum)
        {
            Random random = new Random();
            List<Controler> newList = new List<Controler>();//List初始化
            for(int i=0;i<controlers.Count;i++)
            {
                newList.Insert(random.Next(newList.Count+1), controlers[i]);//随机插入newlist，接下来进行角色分配
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
                    newList[4].Role = new Pingmin();
                    newList[5].Role = new Pingmin();
                    newList[6].Role = new Pingmin();
                    newList[7].Role = new Pingmin();
                    newList[8].Role = new Yuyanjia();
                    yuyanjia = newList[8];
                    newList[9].Role = new Nvwu();
                    nvwu = newList[9];
                    newList[10].Role = new Lieren();
                    lieren = newList[10];
                    newList[11].Role = new Baichi();
                    baichi = newList[11];
                    break;
            }
            for(int i=0;i<newList.Count;i++)
            {
                controlers[newList[i].Sn]=newList[i];
            }
            controlerlist= controlers;//分配完成职业并重新排序好的控制者列表获取引用
            langrenlist = new ObservableCollection<Controler>();
            pingminlist = new ObservableCollection<Controler>();
            langrenlist1 = new List<Langren>();
            pingminlist1 = new List<Pingmin>();
            yuyanjia1 = new Yuyanjia();
            lieren1 = new Lieren();
            nvwu1 = new Nvwu();
            lieren1 = new Lieren();


            /*通过随机分配完成并排序好的控制者List中
             * 获取狼人列表以及平民列表的应用
             * 获得按sn排列的狼人与平民list以及狼人平民角色list*/
            foreach (Controler item in controlers)
            {
                if (item.Role is Langren)
                {
                    langrenlist.Add(item);
                    langrenlist1.Add((Langren)item.Role);
                }
                if (item.Role is Pingmin)
                {
                    pingminlist.Add(item);
                    pingminlist1.Add((Pingmin)item.Role);
                }
                if (item.Role is Yuyanjia)
                {
                    yuyanjia1 = (Yuyanjia)item.Role;
                }
                if (item.Role is Nvwu)
                {
                    nvwu1 = (Nvwu)item.Role;
                }
                if (item.Role is Lieren)
                {
                    lieren1 = (Lieren)item.Role;
                }
                if (item.Role is Baichi)
                {
                    baichi1 = (Baichi)item.Role;
                }
            }
        }
        #endregion
        #region 首夜方法
        public async void StartNight( )
        {
            recordTB.Text += "首夜开始\n";
            //预言家行动
            await CallMessageDialog("预言家请睁眼");
            foreach (TextBlock item in roletblist)
            {
                if (item.Text == "预言家")
                {
                    item.Opacity = 1;
                }
            }
            await CallMessageDialog("请选择要查验的人");
            await GetResults("查验");
            //此处查人。给所有玩家添加属性，是否被查
            await CallMessageDialog("查验完成，他的身份是"+controlerlist[yuyanjia1.RoleCheck].Role.Rolename);
            foreach (TextBlock item in roletblist)
            {
                if (item.Text == "预言家")
                {
                    item.Opacity = 0;
                }
            }
            await CallMessageDialog("所有狼人睁眼");
            //狼人行动
            foreach (TextBlock item in roletblist)
            {
                if (item.Text == "狼人")
                {
                    item.Opacity = 1;
                }
            }
            await CallMessageDialog("狼人依次发言");
            foreach (Controler item in langrenlist)
            {
                await CallMessageDialog(item.Sn+1+"号为狼人，请发言");
                item.Speak();
            }
            await CallMessageDialog("狼人投票杀人");
            foreach (TextBlock item in roletblist)
            {
                if (item.Text == "狼人")
                {
                    item.Opacity = 0;
                }
            }
            //女巫行动
            await CallMessageDialog("女巫请睁眼");
            foreach (TextBlock item in roletblist)
            {
                if (item.Text == "女巫")
                {
                    item.Opacity = 1;
                }
            }
            await CallMessageDialog("今晚" + "" + "死了，你要救吗？要使用毒药吗？");
            foreach (TextBlock item in roletblist)
            {
                if (item.Text == "女巫")
                {
                    item.Opacity = 0;
                }
            }
        }
        #endregion
        #region 上警方法
        public void PoliceCampaign()
        {
            //狼人行动
            //女巫行动
            //预言家行动
        }
        #endregion

        private void rolenameTB_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            roletblist.Add(tb);
        }
        public async Task CallMessageDialog(string message)
        {
            MyPopup popup = new MyPopup(message);
            await popup.ShowAPopup();
        }
        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (continueClicked != null)
                continueClicked.TrySetResult(null);
        }
        private async Task GetResults(string buttoncontent)//异步等待方法
        {
            continueClicked = new TaskCompletionSource<object>();
            chooseCB.Opacity = 1;
            confirmButton.Opacity = 1;
            confirmButton.Content = buttoncontent;
            await continueClicked.Task;
            chooseCB.Opacity = 1;
            confirmButton.Opacity =0;
        }

        private void chooseCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            yuyanjia1.RoleCheck = comboBox.SelectedIndex;
        }
    }
    public class Converter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return ((int)value + 1);
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            return ((int)value -1);
        }
    }//值转换器
    public class Converter0 : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            if ((bool)value)
                return "AI";
            else
                return "玩家";
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }//值转换器
}
