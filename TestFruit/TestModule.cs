using Gemfruit.Mod.API;
using Gemfruit.Mod.API.Events;
using Gemfruit.Mod.API.Events.Monsters;
using Gemfruit.Mod.Monsters;
using StardewValley.Monsters;

namespace TestFruit
{
    [Module("testfruit")]
    public class TestModule
    {
        [InitBusHook]
        private static void OnMonsterRegistration(MonsterRegistrationEvent evt)
        {
            if (evt.Phase == EventPhase.During)
            {
                evt.Registry.Register(new MonsterType(new RegistryKey("test_mod", "bad_guy"))
                                        .setMineshaftConstructor(d => new MetalHead(d.Position, (int) MineshaftArea.Ice)));
            }
        }

        [InitBusHook]
        private static void OnMonsterSpawnRegistration(MineshaftSpawnRegistrationEvent evt)
        {
            if (evt.Phase == EventPhase.Before && evt.Area == MineshaftArea.Surface && evt.Type == MonsterLocomotion.Ground)
            {
                evt.Registry.Register(MonsterLocomotion.Ground,
                                        MineshaftArea.Surface, 
                                        new MineshaftSpawnChance(new RegistryKey("test_mod", "bad_guy"),
                                            0, 9, -2));
            }
        }
    }
}