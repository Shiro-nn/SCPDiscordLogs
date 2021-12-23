﻿using Qurre.API.Addons;
namespace SCPDiscordLogs
{
	public class Translate : IConfig
	{
		public string Name { get; set; } = "SCPDiscordLogs-Translate";
		public string Kick { get; set; } = "Kick";
		public string Ban { get; set; } = "Ban";
		public string KickWebHook { get; set; } = "%kicked% has been kicked by %kicker%. Reason: %reason%";
		public string BanWebHook { get; set; } = "%banned% has been banned by %banner%. Reason: %reason%\nUntil %to%";
		public string RoundInfo { get; set; } = "Players online: %players%. Round duration: %time% min. Players alive: %alive%. SCPs alive: %scps%. %alpha% IP: %ip%";
		public string PickupItem { get; set; } = "%player% picked up %item%.";
		public string DropItem { get; set; } = "%player% dropped %item%.";
		public string ChangeItem { get; set; } = "%player% changed the item in hand: %olditem% -> %newitem%.";
		public string RoundEnd { get; set; } = ":stop_button: Round ended: %players% players online.";
		public string RoundStart { get; set; } = ":arrow_forward: Round started: %players% players online.";
		public string Waiting { get; set; } = ":hourglass: Waiting for players...";
		public string Kill { get; set; } = ":skull_crossbones: **%killer% killed %target% using %tool%.**";
		public string TeamKill { get; set; } = ":o: **%killer% teamkilled %target% using %tool%.**";
		public string Damage { get; set; } = "%attacker% damaged %target% for %amount%, using %tool%.";
		public string TeamDamage { get; set; } = ":crossed_swords: **%attacker% damaged teamate %target% for %amount%, using %tool%.**";
		public string Console { get; set; } = "%player% used console command [`]: %command%";
		public string Ra { get; set; } = ":keyboard: %player% used command: %command%";
		public string Spawn { get; set; } = "%player% spawned as %role%.";
		public string Escape { get; set; } = "%player% has escaped, his new role is: %role%.";
		public string UseItem { get; set; } = "%player% used %item%.";
		public string ThrowItem { get; set; } = "%player% threw the %item%.";
		public string TeamSpawn { get; set; } = "%team% team arrived with number of %players% units.";
		public string LczDecon { get; set; } = ":biohazard: **Light Containment zone decontamination sequence has been started**";
		public string AdminRoleChange { get; set; } = "%player% has changed his role to: **%group%**.";
		public string Cuff { get; set; } = ":lock: %target% has been cuffed by %cuffer%";
		public string UnCuff { get; set; } = ":unlock: %target% has been uncuffed by %uncuffer%";
		public string Leave { get; set; } = ":arrow_left: **%player% leaved from the server.**";
		public string Join { get; set; } = ":arrow_right: **%player% connected to the server.**";
		public string Upgrade914 { get; set; } = "SCP 914 upgraded:\nPlayers:%players%.\nItems:%items%.";
		public string Change914 { get; set; } = "%player% changed SCP 914 settings to %setting%.";
		public string Activate914 { get; set; } = "%player% activated SCP 914, on settings: %state%.";
		public string InteractDoorOpen { get; set; } = "%player% opened door: %door%.";
		public string InteractDoorClose { get; set; } = "%player% close door: %door%.";
		public string InteractLift { get; set; } = "%player% called elevator.";
		public string InteractTesla { get; set; } = "%player% trigered tesla gate.";
		public string InteractLocker { get; set; } = "%player% оpened locker.";
		public string WeaponReload { get; set; } = "%player% reloaded weapon: %weapon%.";
		public string GetLvl079 { get; set; } = "%player% get %lvl% SCP 079 level.";
		public string GetXp079 { get; set; } = "%player% get %exp% for %type%.";
		public string Contain106 { get; set; } = "%player% succesfuly recontained SCP 106.";
		public string FemurEnter { get; set; } = "%player% sacrificed himself in SCP 106 cell.";
		public string PocketEscape { get; set; } = "%player% escaped from pocket dimension.";
		public string PocketEnter { get; set; } = "%player% hit the pocket dimension.";
		public string PortalUse { get; set; } = "%player% used portal.";
		public string PortalCreate { get; set; } = "%player% created portal.";
		public string ReportCheater { get; set; } = "**Cheater has been reported  by: %sender%. Reported player - %target%. Reason: %reason%.**";
		public string Banned { get; set; } = ":no_entry: %player% was banned %issuer% for %reason%. Until: %time%";
		public string GeneratorEjected { get; set; } = "%player% ejected weapon tablet from generator.";
		public string GeneratorClose { get; set; } = "%player% closed generator.";
		public string GeneratorUnlock { get; set; } = "%player% unlocked generator.";
		public string GeneratorOpen { get; set; } = "%player% opened generator.";
		public string GeneratorInject { get; set; } = "%player% insert weapon tablet to generator.";
		public string GeneratorActivate { get; set; } = "Generator has been activated";
		public string AlphaPanel { get; set; } = "%player% got access to the alpha warhead detonation button cover.";
		public string AlphaStop { get; set; } = "***%player% actvivated the Alpha-warhead.***";
		public string AlphaStart { get; set; } = ":radioactive: **Alpha-warhed has been activated, %time% seconds to detonation.**";
		public string AlphaDetonation { get; set; } = ":radioactive: **The Alpha warhead was successfully detonated**";
		public string AlphaNotDetonated { get; set; } = "Alpha-warhead not detonated.";
		public string AlphaActive { get; set; } = "Alpha-warhead has been activated.";
		public string AlphaDetonated { get; set; } = "Alpha-warhead has been detonated.";
	}
}