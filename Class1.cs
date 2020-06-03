using System;
using GTA;
using GTA.Native;
using GTA.Math;


namespace PlayerReliveNoReModel
{
    public class ReliveNoReModel : Script   //继承“Script”类
    {
        Ped player;//设player是主角
        Timer dead_timer = new Timer();
        public ReliveNoReModel()
        {
            Tick += OnTick;
        }
        void OnTick(object sender, EventArgs e)
        {
            player = Game.Player.Character;
            bool isExist = Function.Call<bool>(Hash.DOES_ENTITY_EXIST, player);//人物是否存在，如果不存在有可能是在加载游戏
            if (isExist)
            {
                if ( player.IsDead == false&&this.dead_timer.IsOverTime && Game.IsScreenFadedOut && Function.Call<int>(Hash.GET_TIME_SINCE_LAST_DEATH) < 10000 && Function.Call<int>(Hash.GET_TIME_SINCE_LAST_ARREST) < 10000)
                {
                    this.dead_timer.Set(1000);
                    Game.FadeScreenIn(5000);
                }
            }
            else
            {
                return;
            }
        }
    }
}