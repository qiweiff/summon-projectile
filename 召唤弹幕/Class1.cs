using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using MySql.Data.MySqlClient.Authentication;
using Terraria.UI;
using System.Linq.Expressions;

namespace 物品技能
{
    [ApiVersion(2, 1)]//api版本
    public class 召唤弹幕 : TerrariaPlugin
    {
        /// 插件作者
        public override string Author => "奇威复反";
        /// 插件说明
        public override string Description => "召唤弹幕";
        /// 插件名字
        public override string Name => "召唤弹幕";
        /// 插件版本
        public override Version Version => new Version(1, 0, 0, 0);
        /// 插件处理
        public 召唤弹幕(Main game) : base(game)
        {
        }
        /// 插件启动时，用于初始化各种狗子
        public override void Initialize()
        {
            ServerApi.Hooks.GameInitialize.Register(this, OnInitialize);//钩住游戏初始化时
        }
        /// 插件关闭时
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Deregister hooks here
                ServerApi.Hooks.GameInitialize.Deregister(this, OnInitialize);//销毁游戏初始化狗子

            }
            base.Dispose(disposing);
        }

        private void OnInitialize(EventArgs args)//游戏初始化的狗子
        {
            //第一个是权限，第二个是子程序，第三个是名字

            Commands.ChatCommands.Add(
                new Command("召唤弹幕", _召唤弹幕, "召唤弹幕")
                {
                });
            Commands.ChatCommands.Add(
                new Command("召唤弹幕", _召唤弹幕2, "召唤弹幕2")
                {
                });
        }
        private void _召唤弹幕(CommandArgs args)
        {
            try
            {
                string 弹幕 = args.Parameters[0];
                string 位置x = args.Parameters[1];
                string 位置y = args.Parameters[2];
                string 速度x = args.Parameters[3];
                string 速度y = args.Parameters[4];
                string 伤害 = args.Parameters[5];
                string 击退 = args.Parameters[6];
                int 弹幕2 = Convert.ToInt32(弹幕);
                int 位置x2 = 16 * Convert.ToInt32(位置x);
                int 位置y2 = 16 * Convert.ToInt32(位置y);
                int 速度x2 = Convert.ToInt32(速度x);
                int 速度y2 = Convert.ToInt32(速度y);
                int 伤害2 = Convert.ToInt32(伤害);
                int 击退2 = Convert.ToInt32(击退);
                int index = Terraria.Projectile.NewProjectile(null, 位置x2, 位置y2, 速度x2, 速度y2, 弹幕2, 伤害2, 击退2, args.Player.Index);
                TSPlayer.All.SendData(PacketTypes.ProjectileNew, "", index);
                args.Player.SendSuccessMessage($"释放成功");
            }
            catch
            {
                args.Player.SendSuccessMessage($"正确指令：/召唤弹幕 弹幕ID 位置X 位置Y 速度X 速度Y 伤害 击退");
                args.Player.SendSuccessMessage($"正确指令：/召唤弹幕2 弹幕ID 偏移位置X 偏移位置Y 速度X 速度Y 伤害 击退");
            }
        }
        private void _召唤弹幕2(CommandArgs args)
        {
            try
            {
                string 弹幕 = args.Parameters[0];
                string 位置x = args.Parameters[1];
                string 位置y = args.Parameters[2];
                string 速度x = args.Parameters[3];
                string 速度y = args.Parameters[4];
                string 伤害 = args.Parameters[5];
                string 击退 = args.Parameters[6];
                int 弹幕2 = Convert.ToInt32(弹幕);
                int 位置x2 = 16 * Convert.ToInt32(位置x);
                int 位置y2 = 16 * Convert.ToInt32(位置y);
                int 速度x2 = Convert.ToInt32(速度x);
                int 速度y2 = Convert.ToInt32(速度y);
                int 伤害2 = Convert.ToInt32(伤害);
                int 击退2 = Convert.ToInt32(击退);
                int index = Terraria.Projectile.NewProjectile(null, 16 * args.Player.TileX + 位置x2, 16 * args.Player.TileY + 位置y2, 速度x2, 速度y2, 弹幕2, 伤害2, 击退2, args.Player.Index);
                TSPlayer.All.SendData(PacketTypes.ProjectileNew, "", index);
                args.Player.SendSuccessMessage($"释放成功");
            }
            catch
            {
                args.Player.SendSuccessMessage($"正确指令：/召唤弹幕 弹幕ID 位置X 位置Y 速度X 速度Y 伤害 击退");
                args.Player.SendSuccessMessage($"正确指令：/召唤弹幕2 弹幕ID 偏移位置X 偏移位置Y 速度X 速度Y 伤害 击退");
            }
        }
    }
}
