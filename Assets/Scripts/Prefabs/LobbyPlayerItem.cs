using HeathenEngineering.SteamworksIntegration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IslandConstructors.Prefabs
{
	public class LobbyPlayerItem : MonoBehaviour
	{
		[SerializeField] private RawImage playerAvatar;
		[SerializeField] private TextMeshProUGUI playerNameText;

		public UserData userData { get; private set; }

		public void Init(UserData data)
		{
			userData = data;
			if (userData.Avatar != null)
			{
				playerAvatar.texture = userData.Avatar;
			}
			else
			{
				userData.LoadAvatar((result) => playerAvatar.texture = result);
			}
			playerNameText.text = userData.Name;
		}
	}
}