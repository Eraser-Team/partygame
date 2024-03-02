using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServerCheck : MonoBehaviour
{
    public string serverAddress = "https://anchosus.itch.io/projectsky";
	public GameObject connectUI;
    public Text connectionText;

    IEnumerator Start()
    {
        while (true)
        {
            using (var webRequest = UnityEngine.Networking.UnityWebRequest.Get(serverAddress))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
                {
                    connectUI.SetActive(false);
                }
                else
                {
					connectUI.SetActive(true);
                    connectionText.text = "Connecting to the " + serverAddress + "...";
                }
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
