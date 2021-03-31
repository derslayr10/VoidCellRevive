using BepInEx;
namespace VoidCellRevive
{

    [BepInPlugin(ModGuid, ModName, ModVer)]

    public class PlayerBotsItems : BaseUnityPlugin
    {

        public const string ModGuid = "com.Derslayr.VoidCellRevive";
        public const string ModName = "VoidCellRevive";
        public const string ModVer = "1.0.2";

        private void ReviveDeadPlayers()
        {

            var players = RoR2.PlayerCharacterMasterController.instances;

            if (RoR2.Run.instance.livingPlayerCount < RoR2.Run.instance.participatingPlayerCount)
            {

                for (int i = 0; i < RoR2.Run.instance.participatingPlayerCount; i++)
                {

                    if (players[i].master.IsDeadAndOutOfLivesServer())
                    {

                        players[i].master.RespawnExtraLife();

                    }

                }

            }

        }

        public void Awake()
        {

            On.RoR2.ArenaMissionController.BeginRound += (orig, self) => {

                ReviveDeadPlayers();
                orig(self);

            };

        }

    }

}

