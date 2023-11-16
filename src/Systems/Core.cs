using Vintagestory.API.Common;
using Vintagestory.GameContent;

[assembly: ModInfo(name: "Halloween Every Day", modID: "halloweeneveryday", Side = "Server")]

namespace HalloweenEveryDay;

public class Core : ModSystem
{
    public override void StartPre(ICoreAPI api)
    {
        base.StartPre(api);
        ItemChisel.carvingTime = true;
        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }
}