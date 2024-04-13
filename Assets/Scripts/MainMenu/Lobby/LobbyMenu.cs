using HeathenEngineering.SteamworksIntegration;
using HeathenEngineering.SteamworksIntegration.API;
using IslandConstructors.Prefabs;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IslandConstructors.MainMenu.Lobby
{
	public class LobbyMenu : MonoBehaviour
	{
        [SerializeField] private GameObject playerItemPrefab;
        [SerializeField] private Transform playerItemsHolderGO;
        private List<LobbyPlayerItem> playerItemsList = new List<LobbyPlayerItem>();

        // TextMeshPro
		[SerializeField] private TextMeshProUGUI lobbyNameText;
		[SerializeField] private TextMeshProUGUI lobbyEnterCodeText;

        [SerializeField] private Button leaveLobbyButton;

        [SerializeField] private GameObject MainMenuGO;

        // Manager
		private LobbyManager lobbyManager;

        private void Awake()
        {
            lobbyManager = FindAnyObjectByType<LobbyManager>();
            leaveLobbyButton.onClick.AddListener(LeaveLobby);
            lobbyManager.evtCreated.AddListener(SetLobbyCreated);
            lobbyManager.evtUserJoined.AddListener(OnUserJoined);
            lobbyManager.evtUserLeft.AddListener(OnUserLeft);
        }

        private void AddNewPlayer(UserData newUser)
        {
            GameObject newPlayerItem = Instantiate(playerItemPrefab, playerItemsHolderGO);
            LobbyPlayerItem newPlayerItemScript = newPlayerItem.GetComponent<LobbyPlayerItem>();
            newPlayerItemScript.Init(newUser);

            playerItemsList.Add(newPlayerItemScript);
        }

        private void SetLobbyCreated(LobbyData lobbyData)
        {
            lobbyNameText.text = lobbyData.Name;
            lobbyEnterCodeText.text = lobbyData.ToString();
            AddNewPlayer(App.Client.Owner);
        }

        private void LeaveLobby()
        {
            lobbyManager.Leave();

            foreach (LobbyPlayerItem lobbyPlayerItem in playerItemsList)
            {
                Destroy(lobbyPlayerItem.gameObject);
            }
            playerItemsList = new List<LobbyPlayerItem>();

            MainMenuGO.SetActive(true);
            gameObject.SetActive(false);
        }

        private void OnUserJoined(UserData userData)
        {
            AddNewPlayer(userData);

            Debug.Log(userData.Name + " has connected");
        }

        private void OnUserLeft(UserLobbyLeaveData userLobbyData)
        {
            foreach (LobbyPlayerItem lobbyPlayerItem in playerItemsList)
            {
                if (lobbyPlayerItem.userData == userLobbyData.user)
                {
                    playerItemsList.Remove(lobbyPlayerItem);
                    Destroy(lobbyPlayerItem.gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            leaveLobbyButton.onClick.RemoveListener(LeaveLobby);
            lobbyManager.evtCreated.RemoveListener(SetLobbyCreated);
            lobbyManager.evtUserJoined.RemoveListener(OnUserJoined);
            lobbyManager.evtUserLeft.RemoveListener(OnUserLeft);
        }
    }
}