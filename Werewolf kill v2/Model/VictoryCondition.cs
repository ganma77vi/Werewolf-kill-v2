using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_kill_v2.Model
{
    public class VictoryCondition
    {
        public enum Gamestatus:int
        {
            所有狼人死亡,
            所有平民死亡,
            所有神民死亡,
            剩余狼人数大于人类数
        }
    }
}
