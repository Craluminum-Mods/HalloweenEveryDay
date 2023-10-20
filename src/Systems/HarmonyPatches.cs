using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace HalloweenEveryDay;

public class HarmonyPatches : ModSystem
{
    public const string HarmonyID = "craluminum2413.HalloweenEveryDay";
    public static Harmony HarmonyInstance { get; set; } = new Harmony(HarmonyID);

    public override void StartServerSide(ICoreServerAPI api)
    {
        base.StartServerSide(api);
        HarmonyInstance.Patch(original: typeof(ItemChisel).GetMethod(nameof(ItemChisel.OnHeldInteractStart)), transpiler: typeof(PumpkingCarvingPatch).GetMethod(nameof(PumpkingCarvingPatch.Transpiler)));
    }

    public override void Dispose()
    {
        HarmonyInstance.Unpatch(original: typeof(ItemChisel).GetMethod(nameof(ItemChisel.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        base.Dispose();
    }
}