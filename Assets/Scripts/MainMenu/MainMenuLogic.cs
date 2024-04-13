using UnityEngine;
using UnityEngine.UI;
using IslandConstructors.MainMenu.Lobby;

namespace IslandConstructors.MainMenu
{
    public class MainMenuLogic : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button SingleGameButton;
        [SerializeField] private Button HostLobbyButton;
        [SerializeField] private Button JoinLobbyButton;

        [Header("Menus")]
        [SerializeField] private GameObject LobbyMenuGO;
        [SerializeField] private GameObject JoinMenuGO;

        private HostingLobby hostingLobbyScript;

        private void Awake()
        {
            hostingLobbyScript = FindAnyObjectByType<HostingLobby>();

            // Attach logic to buttons
            SingleGameButton.onClick.AddListener(() => StartSingleGame());
            HostLobbyButton.onClick.AddListener(() => HostLobby());
            JoinLobbyButton.onClick.AddListener(() => JoinLobby());
        }

        private void StartSingleGame()
        {
            Debug.Log("Single Game Start Pressed");
        }

        // Calls when HostLobbyButton clicked
        private void HostLobby()
        {
            // Change menu to Lobby menu
            LobbyMenuGO.SetActive(true);
            gameObject.SetActive(false);

            // Create Lobby
            hostingLobbyScript.CreateLobby();
            Debug.Log("Lobby Hosting Pressed");
        }

        private void JoinLobby()
        {
            JoinMenuGO.SetActive(true);
            gameObject.SetActive(false);

            Debug.Log("Lobby Joining Pressed");
        }

        private void OnDestroy()
        {
            SingleGameButton.onClick.RemoveAllListeners();
            HostLobbyButton.onClick.RemoveAllListeners();
            JoinLobbyButton.onClick.RemoveAllListeners();
        }
    }
}