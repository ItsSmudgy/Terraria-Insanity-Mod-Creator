﻿using Microsoft.Xna.Framework;
using Insanity.Content.Pets.SpiritOfMightPet;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Insanity.Content.Pets.SpiritOfMightPet
{
	public class SpiritOfMightBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Might Probe");
			Description.SetDefault("A friendly Might Probe is following you!");

			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) { // This method gets called every frame your buff is active on your player.
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<SpiritOfMightPetProjectile>();

			// If the player is local, and there hasn't been a pet projectile spawned yet - spawn it.
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) {
				var entitySource = player.GetSource_Buff(buffIndex);
				
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}
