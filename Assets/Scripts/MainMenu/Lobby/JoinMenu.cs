using HeathenEngineering.SteamworksIntegration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IslandConstructors.MainMenu.Lobby
{
	public class JoinMenu : MonoBehaviour
	{
		[SerializeField] private TMP_InputField enterCodeInputField;
        [SerializeField] private Button joinButton;
        [SerializeField] private Button backToMainButton;

        [SerializeField] private GameObject MainMenuGO;
        [SerializeField] private GameObject LobbyMenuGO;

		private JoiningLobby joiningLobbyScript;

        private void Awake()
        {
            joiningLobbyScript = FindAnyObjectByType<JoiningLobby>();
            joinButton.onClick.AddListener(Join);
            backToMainButton.onClick.AddListener(BackToMainMenu);
        }

        private void Join()
        {
            LobbyData lobby = LobbyData.Get(enterCodeInputField.text);
            joiningLobbyScript.JoinLobby(lobby);

            LobbyMenuGO.SetActive(true);
            gameObject.SetActive(false);
        }

        private void BackToMainMenu()
        {
            MainMenuGO.SetActive(true);
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            joinButton.onClick.RemoveListener(Join);
            backToMainButton.onClick.RemoveListener(BackToMainMenu);
        }
    }
}