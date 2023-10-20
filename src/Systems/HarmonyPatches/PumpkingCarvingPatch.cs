using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using Vintagestory.GameContent;

namespace HalloweenEveryDay;

[HarmonyPatch]
public static class PumpkingCarvingPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(ItemChisel), nameof(ItemChisel.OnHeldInteractStart))]
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        bool found = false;
        List<CodeInstruction> codes = new(instructions);

        for (int i = 0; i < codes.Count; i++)
        {
            if (!found &&
                codes[i].opcode == OpCodes.Ldloc_2 && codes[i + 1].opcode == OpCodes.Brtrue_S && codes[i + 2].opcode == OpCodes.Ldloc_0 && codes[i - 1].opcode == OpCodes.Stloc_2)
            {
                yield return new CodeInstruction(OpCodes.Ldc_I4_1);
                found = true;
                continue;
            }
            yield return codes[i];
        }
    }
}
