using HeathenEngineering.SteamworksIntegration;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace IslandConstructors.MainMenu.Lobby
{
    [RequireComponent(typeof(LobbyManager))]
    public class HostingLobby : LobbyManagerUser
    {
        protected override void Awake()
        {
            base.Awake();

            lobbyManager.evtCreated.AddListener(OnLobbyCreated);
            lobbyManager.evtCreateFailed.AddListener(OnLobbyCreateFailed);
        }

        public void CreateLobby()
        {
            if (SteamSettings.Initialized)
            {
                lobbyManager.Create(Friends.Client.PersonaName + "'s Lobby", ELobbyType.k_ELobbyTypeFriendsOnly, 4);
            }
            else
            {
                Debug.LogError("Steam is not Initialized");
            }
        }

        private void OnLobbyCreated(LobbyData lobbyData)
        {
            Debug.Log("Succesfully Created lobby " + lobbyData.Name);
            Debug.Log("Lobby enter code: " + lobbyData.ToString());
        }

        private void OnLobbyCreateFailed(EResult result)
        {
            Debug.LogError("Failed creating lobby: " + result.ToString());
        }

        private void OnDestroy()
        {
            lobbyManager.evtCreated.RemoveListener(OnLobbyCreated);
            lobbyManager.evtCreateFailed.RemoveListener(OnLobbyCreateFailed);
        }
    }
}