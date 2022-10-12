using TrueSoul.Items.Other;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items;
using TrueSoul.Dusts;
using System.Collections.Generic;
using System.Linq;


namespace TrueSoul.Items.Potions
{
	public class SpectralPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
			Tooltip.SetDefault("This disaster adds 4 mana regen, adds 100 max health, and buffs damage by 12 percent.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 2);
			Item.buffType = ModContent.BuffType<SpectralBuff>();
			Item.buffTime = 3600;

		}



		

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Waterleaf, 4);
			recipe.AddIngredient(ItemID.Deathweed, 2);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 21);
			recipe.AddIngredient(ItemID.LifeFruit, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
	public class SpectralBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral");
			Description.SetDefault("You feel... powerful...");

			Main.buffNoSave[Type] = false; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.manaRegen += 6;
			player.GetDamage(DamageClass.Generic) += 0.12f;
			player.manaRegen += 6;
			
		}
	}

	public class ScorchedFlameInBoss : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scorched Flames");
			Description.SetDefault("You feel your skin melting off...");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
		}
		int LifeTickDown = 0;
		int DeathRandomizer = 0;
		public override void Update(Player player, ref int buffIndex)
		{
			LifeTickDown++;
			
			if (LifeTickDown == 16)
            {
				
				player.statLife -= 1;
				LifeTickDown = 0;
				Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<OrangeSparkleFalling>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
			}
			
			if (player.statLife <= 1)
            {
				DeathRandomizer = Main.rand.Next(3, 6);
				if (DeathRandomizer == 3)
                {
					player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "'s body became a pile of ash."), 0.0, 0, pvp: false);
				}
				if (DeathRandomizer == 4)
                {
					player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "'s skin melted into oblivion."), 0.0, 0, pvp: false);
				}
				if (DeathRandomizer == 5)
                {
					player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "'s bones no longer are white."), 0.0, 0, pvp: false);
				}
				
			}

		}
	}
	public class ForgivenessArdent : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forgiveness");
			Description.SetDefault("The forgiveness in Ardent finds it's way into you.");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
		}
		int LifeTickDown = 0;
		int DeathRandomizer = 0;
		public override void Update(Player player, ref int buffIndex)
		{
			LifeTickDown++;

			if (LifeTickDown == 23)
			{

				player.statLife += 3;
				LifeTickDown = 0;
				Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<OrangeSparkleFalling>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
			}

			if (player.statLife <= 1)
			{


			}

		}
	}
	public class ScorchedFlame : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scorched Flames");
			Description.SetDefault("You feel your skin melting off...");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
		}
		int LifeTickDown = 0;
		public override void Update(NPC target, ref int buffIndex)
		{
			LifeTickDown++;
			if (LifeTickDown == 9)
			{
				target.life -= 1;
				LifeTickDown = 0;
			}



		}
	}

	public class TestPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
			Tooltip.SetDefault("Test.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 2);
			Item.buffType = ModContent.BuffType<ScorchedFlameInBoss>();
			Item.buffTime = 300;

		}





		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

	}
}
