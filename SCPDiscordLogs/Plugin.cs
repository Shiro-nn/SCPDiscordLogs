﻿using GameCore;
using System.Threading;
using Events = Qurre.Events;
using Version = System.Version;
namespace SCPDiscordLogs
{
    public class Plugin : Qurre.Plugin
    {
        #region Peremens
        public override string Developer => "Qurre Team (fydne)";
        public override string Name => "SCP Discord Logs";
        public override Version Version => new(1, 4, 1);
        public override Version NeededQurreVersion => new(1, 13, 0);
        public override int Priority => -100000;
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        public int MaxPlayers = ConfigFile.ServerConfig.GetInt("max_players", 100);
        private EventHandlers EventHandlers;
        private bool FirstEnable = true;
        internal static Translate Translate;
        #endregion
        #region Events
        public void RegisterEvents()
        {
            Translate = new();
            CustomConfigs.Add(Translate);
            Cfg.LoadReloadCfg();
            if (FirstEnable)
            {
                new Thread(() => Enumerator()).Start();
                new Thread(() => ThreadSendMsg()).Start();
                FirstEnable = false;
            }
            Events.Round.Waiting += Cfg.LoadReloadCfg;
            EventHandlers = new EventHandlers();
            Events.Map.LczDecon += EventHandlers.Decon;
            Events.Scp079.GeneratorActivate += EventHandlers.GeneratorActivate;
            Events.Alpha.Starting += EventHandlers.AlphaStart;
            Events.Alpha.Stopping += EventHandlers.AlphaStop;
            Events.Alpha.Detonated += EventHandlers.Detonation;
            Events.Scp914.Upgrade += EventHandlers.Upgrade;

            Events.Server.SendingRA += EventHandlers.SendingRA;
            Events.Round.Waiting += EventHandlers.Waiting;
            Events.Server.SendingConsole += EventHandlers.SendingConsole;
            Events.Round.Start += EventHandlers.RoundStart;
            Events.Round.End += EventHandlers.RoundEnd;
            Events.Round.TeamRespawn += EventHandlers.TeamRespawn;
            Events.Report.Cheater += EventHandlers.ReportCheater;

            Events.Player.ItemUsed += EventHandlers.ItemUsed;
            Events.Player.PickupItem += EventHandlers.Pickup;
            Events.Player.InteractGenerator += EventHandlers.InteractGenerator;
            Events.Scp079.GetLVL += EventHandlers.GetLVL;
            Events.Scp079.GetEXP += EventHandlers.GetEXP;
            Events.Scp106.PocketEscape += EventHandlers.PocketEscape;
            Events.Scp106.PocketEnter += EventHandlers.PocketEnter;
            Events.Scp106.PortalCreate += EventHandlers.PortalCreate;
            Events.Alpha.EnablePanel += EventHandlers.EnableAlphaPanel;
            Events.Player.TeslaTrigger += EventHandlers.TeslaTrigger;
            Events.Player.ThrowItem += EventHandlers.ThrowItem;
            Events.Player.Damage += EventHandlers.Damage;
            Events.Player.Dies += EventHandlers.Dies;
            Events.Player.Dead += EventHandlers.Dead;
            Events.Player.Banned += EventHandlers.Banned;
            Events.Player.InteractDoor += EventHandlers.InteractDoor;
            Events.Player.InteractLift += EventHandlers.InteractLift;
            Events.Player.InteractLocker += EventHandlers.InteractLocker;
            Events.Player.Cuff += EventHandlers.Cuff;
            Events.Player.UnCuff += EventHandlers.UnCuff;
            Events.Scp106.PortalUsing += EventHandlers.PortalUsing;
            Events.Scp106.FemurBreakerEnter += EventHandlers.Femur;
            Events.Player.RechargeWeapon += EventHandlers.RechargeWeapon;
            Events.Player.DropItem += EventHandlers.Drop;
            Events.Player.Join += EventHandlers.Join;
            Events.Player.Leave += EventHandlers.Leave;
            Events.Player.RoleChange += EventHandlers.RoleChange;
            Events.Player.Escape += EventHandlers.Escape;
            Events.Player.GroupChange += EventHandlers.GroupChange;
            Events.Player.ItemChange += EventHandlers.ItemChange;
            Events.Scp914.Activating += EventHandlers.Activating;
            Events.Scp914.KnobChange += EventHandlers.KnobChange;
            Events.Scp106.Contain += EventHandlers.Contain;
            Events.Map.LczAnnounce += EventHandlers.LczAnnounce;
            Events.Player.Heal += EventHandlers.Heal;
            Events.Player.FlashExplosion += EventHandlers.Explosion;
            Events.Player.FragExplosion += EventHandlers.Explosion;
            Events.Player.Flashed += EventHandlers.Flash;
            Events.Player.InteractScp330 += EventHandlers.Scp330;
            Events.Player.EatingScp330 += EventHandlers.Scp330;

            Events.Player.Banned += EventHandlers.Ban;
            Events.Player.Kick += EventHandlers.Kick;

            Send.Init();
        }
        public void UnregisterEvents()
        {
            CustomConfigs.Clear();
            Events.Round.Waiting -= Cfg.LoadReloadCfg;

            Events.Map.LczDecon -= EventHandlers.Decon;
            Events.Scp079.GeneratorActivate -= EventHandlers.GeneratorActivate;
            Events.Alpha.Starting -= EventHandlers.AlphaStart;
            Events.Alpha.Stopping -= EventHandlers.AlphaStop;
            Events.Alpha.Detonated -= EventHandlers.Detonation;
            Events.Scp914.Upgrade -= EventHandlers.Upgrade;

            Events.Server.SendingRA -= EventHandlers.SendingRA;
            Events.Round.Waiting -= EventHandlers.Waiting;
            Events.Server.SendingConsole -= EventHandlers.SendingConsole;
            Events.Round.Start -= EventHandlers.RoundStart;
            Events.Round.End -= EventHandlers.RoundEnd;
            Events.Round.TeamRespawn -= EventHandlers.TeamRespawn;
            Events.Report.Cheater -= EventHandlers.ReportCheater;

            Events.Player.ItemUsed -= EventHandlers.ItemUsed;
            Events.Player.PickupItem -= EventHandlers.Pickup;
            Events.Player.InteractGenerator -= EventHandlers.InteractGenerator;
            Events.Scp079.GetLVL -= EventHandlers.GetLVL;
            Events.Scp079.GetEXP -= EventHandlers.GetEXP;
            Events.Scp106.PocketEscape -= EventHandlers.PocketEscape;
            Events.Scp106.PocketEnter -= EventHandlers.PocketEnter;
            Events.Scp106.PortalCreate -= EventHandlers.PortalCreate;
            Events.Alpha.EnablePanel -= EventHandlers.EnableAlphaPanel;
            Events.Player.TeslaTrigger -= EventHandlers.TeslaTrigger;
            Events.Player.ThrowItem -= EventHandlers.ThrowItem;
            Events.Player.Damage -= EventHandlers.Damage;
            Events.Player.Dies -= EventHandlers.Dies;
            Events.Player.Dead -= EventHandlers.Dead;
            Events.Player.Banned -= EventHandlers.Banned;
            Events.Player.InteractDoor -= EventHandlers.InteractDoor;
            Events.Player.InteractLift -= EventHandlers.InteractLift;
            Events.Player.InteractLocker -= EventHandlers.InteractLocker;
            Events.Player.Cuff -= EventHandlers.Cuff;
            Events.Player.UnCuff -= EventHandlers.UnCuff;
            Events.Scp106.PortalUsing -= EventHandlers.PortalUsing;
            Events.Scp106.FemurBreakerEnter -= EventHandlers.Femur;
            Events.Player.RechargeWeapon -= EventHandlers.RechargeWeapon;
            Events.Player.DropItem -= EventHandlers.Drop;
            Events.Player.Join -= EventHandlers.Join;
            Events.Player.Leave -= EventHandlers.Leave;
            Events.Player.RoleChange -= EventHandlers.RoleChange;
            Events.Player.Escape -= EventHandlers.Escape;
            Events.Player.GroupChange -= EventHandlers.GroupChange;
            Events.Player.ItemChange -= EventHandlers.ItemChange;
            Events.Scp914.Activating -= EventHandlers.Activating;
            Events.Scp914.KnobChange -= EventHandlers.KnobChange;
            Events.Scp106.Contain -= EventHandlers.Contain;
            Events.Map.LczAnnounce -= EventHandlers.LczAnnounce;
            Events.Player.Heal -= EventHandlers.Heal;
            Events.Player.FlashExplosion -= EventHandlers.Explosion;
            Events.Player.FragExplosion -= EventHandlers.Explosion;
            Events.Player.Flashed -= EventHandlers.Flash;
            Events.Player.InteractScp330 -= EventHandlers.Scp330;
            Events.Player.EatingScp330 -= EventHandlers.Scp330;

            Events.Player.Banned -= EventHandlers.Ban;
            Events.Player.Kick -= EventHandlers.Kick;
            EventHandlers = null;

            Send.Disconnect();
        }
        private void Enumerator()
        {
            Thread.Sleep(1000);
            for (; ; )
            {
                try { Send.PlayersInfo(); } catch { }
                try { EventHandlers.UpdateServerStatus(); } catch { }
                Thread.Sleep(1000);
            }
        }
        private void ThreadSendMsg()
        {
            Thread.Sleep(1000);
            for (; ; )
            {
                try { Send.FatalMsg(); } catch { }
                Thread.Sleep(5000);
            }
        }
        #endregion
    }
}