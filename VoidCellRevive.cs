using BepInEx;
using R2API;
using R2API.Utils;
using UnityEngine;
namespace VoidCellRevive
{

    [BepInDependency(R2API.R2API.PluginGUID, R2API.R2API.PluginVersion)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(ModGuid, ModName, ModVer)]

    public class PlayerBotsItems : BaseUnityPlugin
    {

        public const string ModGuid = "com.Derslayr.VoidCellRevive";
        public const string ModName = "VoidCellRevive";
        public const string ModVer = "1.0.0";

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

            };

        }

    }

}

