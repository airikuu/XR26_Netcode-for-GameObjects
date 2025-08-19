using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuDisplay : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string gameplaySceneName = "Gameplay";
    [SerializeField] private TMP_InputField NameInput;
    private void Start()
    {
        if (NameInput != null)
        {
            NameInput.text = PlayerSettings.PlayerName;
            NameInput.onValueChanged.AddListener(delegate { OnNameChanged(); });
        }
    }
    private void OnNameChanged()
    {
        PlayerSettings.PlayerName = NameInput.text;
        Debug.Log($"Player name changed to {PlayerSettings.PlayerName}");
    }
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(gameplaySceneName, LoadSceneMode.Single);
    }
    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.SceneManager.LoadScene(gameplaySceneName, LoadSceneMode.Single);
    }
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}









