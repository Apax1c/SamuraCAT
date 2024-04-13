using HeathenEngineering.SteamworksIntegration;
using UnityEngine;

namespace IslandConstructors.MainMenu
{
    public class MainMenuInitializator : MonoBehaviour
    {
        [SerializeField] private GameObject HostLobbyButton, JoinLobbyButton;

        void Start()
        {
            if (SteamSettings.Initialized)
            {
                HostLobbyButton.SetActive(true);
                JoinLobbyButton.SetActive(true);
            }
            else
            {
                HostLobbyButton.SetActive(false);
                JoinLobbyButton.SetActive(false);
            }
        }
    }
}