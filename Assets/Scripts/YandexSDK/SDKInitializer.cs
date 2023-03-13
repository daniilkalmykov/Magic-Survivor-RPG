using System.Collections;
using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YandexSDK
{
    public sealed class SDKInitializer : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return Agava.YandexGames.YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(ScenesNames.MainMenu);
        }
    }
}