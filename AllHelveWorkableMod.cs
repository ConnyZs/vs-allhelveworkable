using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace allhelveworkable;

public class AllHelveWorkableMod : ModSystem
{
    Harmony? harmony;

    public override void Start(ICoreAPI api)
    {
        if (!Harmony.HasAnyPatches(Mod.Info.ModID))
        {
            harmony = new Harmony(Mod.Info.ModID);
            harmony.PatchAll();
        }
    }

    public override void Dispose()
    {
        harmony?.UnpatchAll(Mod.Info.ModID);
    }
}

[HarmonyPatch(typeof(ItemWorkItem), nameof(ItemWorkItem.GetHelveWorkableMode))]
public class GetHelveWorkableModePatch
{
    static void Postfix(ref EnumHelveWorkableMode __result)
    {
        __result = EnumHelveWorkableMode.FullyWorkable;
    }
}
