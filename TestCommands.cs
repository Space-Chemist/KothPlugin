using NLog;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Blocks;
using Sandbox.Game.Entities.Cube;
using Sandbox.ModAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Torch.Commands;
using Torch.Commands.Permissions;
using VRage.Game;
using VRage.Game.ModAPI;
using VRageMath;

namespace KothPlugin
{
    [Category("Koth")]
    public class TestCommands : CommandModule
    {
        private static readonly Logger Log = LogManager.GetLogger("Koth");

        public KothPlugin.TestPlugin Plugin
        {
            get
            {
                return (KothPlugin.TestPlugin)this.Context.Plugin;
            }
        }

        [Command("clearscores", "This clears koth scores", null)]
        [Permission(MyPromoteLevel.Admin)]
        public void ClearScores()
        {
            Communication.Message();
            this.Context.Respond("Koth plugin reset koth scores");
        }
    }
}
