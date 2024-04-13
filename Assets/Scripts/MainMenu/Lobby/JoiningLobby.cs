using HeathenEngineering.SteamworksIntegration;
using Steamworks;
using UnityEngine;

namespace IslandConstructors.MainMenu.Lobby
{
	public class JoiningLobby : LobbyManagerUser
    {
        protected override void Awake()
        {
            base.Awake();

            lobbyManager.evtEnterSuccess.AddListener(OnLobbyEntered);
            lobbyManager.evtEnterFailed.AddListener(OnLobbyEnterFailed);
        }

        private void OnDestroy()
        {
            lobbyManager.evtEnterSuccess.RemoveListener(OnLobbyEntered);
            lobbyManager.evtEnterFailed.RemoveListener(OnLobbyEnterFailed);
        }

        public void JoinLobby(LobbyData data)
        {
            lobbyManager.Join(data);
        }

        private void OnLobbyEntered(LobbyData lobbyData)
        {
            Debug.Log("Succesfully connected to lobby " + lobbyData.Name);
        }

        private void OnLobbyEnterFailed(EChatRoomEnterResponse response)
        {
            Debug.LogError("Failed coonecting to lobby " + response.ToString());
        }
    }
}