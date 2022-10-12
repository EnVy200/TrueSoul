using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace TrueSoul.Projectiles.Tiles
{
    internal class MagmaiteOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 50;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 600;

            AddMapEntry(new Color(255, 40, 40), CreateMapEntryName());

            DustType = DustID.Clentaminator_Red;
            ItemDrop = ModContent.ItemType<Items.Placeables.MagmiteOre>();
            HitSound = SoundID.Tink;

            MineResist = 2.5f;
            MinPick = 98;
        }
    }
}
