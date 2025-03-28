using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerCustom networkManager;
    [SerializeField] private InputField ipInputField;

    // Called when the Host button is clicked.
    public void HostGame()
    {
        networkManager.StartHost();
    }

    // Called when the Join button is clicked.
    public void JoinGame()
    {
        if (!string.IsNullOrEmpty(ipInputField.text))
        {
            networkManager.networkAddress = ipInputField.text;
        }
        else
        {
            // Fallback to localhost if no IP is entered.
            networkManager.networkAddress = "localhost";
        }
        networkManager.StartClient();
    }
}
