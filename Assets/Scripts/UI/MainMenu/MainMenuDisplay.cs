using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuDisplay : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string gameplaySceneName = "Gameplay";
    [SerializeField] private TMP_InputField nameInput;


    private void Start()
    {
        nameInput.onValueChanged.AddListener(OnNameChanged);
    }

    private void OnNameChanged.(string name)
    {
        PlayerSettings.PlayerName = name;
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
