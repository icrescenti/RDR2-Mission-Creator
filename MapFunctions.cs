using RDR2;
using RDR2.Math;
using RDR2.Native;

namespace RDR2_Mission_Creator
{
    class MapFunctions : Script
    {
        public static Blip CreateBlip(Vector3 position, BlipType btype, uint sprite, string name, float size = 1.0f, bool flash = false)
        {
            int blip = Function.Call<int>((Hash)0x554D9D53F696D002, (uint)btype, position.X, position.Y, position.Z);
            Blip blipObj = new Blip(blip);
            Function.Call<int>(Hash.SET_BLIP_SPRITE, blipObj, sprite, true);
            blipObj.Label = name;
            blipObj.IsFlashing = flash;
            blipObj.Scale = new Vector2(size, size);
            return blipObj;
        }

    }
}
