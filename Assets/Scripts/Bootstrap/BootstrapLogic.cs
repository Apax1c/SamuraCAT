using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using HeathenEngineering.SteamworksIntegration;
using AppClient = HeathenEngineering.SteamworksIntegration.API.App.Client;

namespace IslandConstructors.Bootstrap
{
    public class BootstrapLogic : MonoBehaviour
    {
        [SerializeField] private LoadingProgress LoadingProgressScript;

        private void Start()
        {
            StartCoroutine(Validate());
        }

        private IEnumerator Validate()
        {
#if !UNITY_EDITOR
        yield return new WaitForSeconds(1f);
        LoadingProgressScript.SetProgressValue(3);

        yield return new WaitForSeconds(1f);
        LoadingProgressScript.SetProgressValue(2);

        yield return new WaitForSeconds(1f);
        LoadingProgressScript.SetProgressValue(1);
#endif
            if (!SteamSettings.HasInitializationError)
            {
                yield return new WaitUntil(() => SteamSettings.Initialized);
                Debug.Log("Steam API is initialized as App " + AppClient.Id.ToString() + " Starting Scene Load!");
            }

            SceneManager.LoadSceneAsync(1);
        }
    }
}