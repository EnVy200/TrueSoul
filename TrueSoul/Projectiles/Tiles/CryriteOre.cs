using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace TrueSoul.Projectiles.Tiles
{
    internal class CryiteOre : ModTile
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

            AddMapEntry(new Color(175, 229, 255), CreateMapEntryName());

            DustType = DustID.GemDiamond;
            ItemDrop = ModContent.ItemType<Items.Placeables.MagmiteOre>();
            HitSound = SoundID.Tink;

            MineResist = 2.5f;
            MinPick = 98;
        }
    }
}
