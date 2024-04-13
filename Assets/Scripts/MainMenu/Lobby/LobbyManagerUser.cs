using HeathenEngineering.SteamworksIntegration;
using UnityEngine;

namespace IslandConstructors.MainMenu.Lobby
{
	public class LobbyManagerUser : MonoBehaviour
	{
        internal LobbyManager lobbyManager;

        protected virtual void Awake()
        {
            lobbyManager = GetComponent<LobbyManager>();
        }
    }
}