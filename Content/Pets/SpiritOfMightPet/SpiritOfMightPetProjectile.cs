﻿using Terraria;
using Insanity.Content.Pets.SpiritOfMightPet;
using Terraria.ID;
using Terraria.ModLoader;

namespace Insanity.Content.Pets.SpiritOfMightPet
{
	public class SpiritOfMightPetProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Might Probe Pet");

			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ZephyrFish); // Copy the stats of the Zephyr Fish

			AIType = ProjectileID.ZephyrFish; // Copy the AI of the Zephyr Fish.
		}

		public override bool PreAI() {
			Player player = Main.player[Projectile.owner];

			player.zephyrfish = false; // Relic from aiType

			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<SpiritOfMightBuff>())) {
				Projectile.timeLeft = 2;
			}
		}
	}
}
