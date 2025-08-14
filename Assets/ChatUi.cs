using UnityEngine;
using TMPro
public class ChatUi : MonoBehaviour
{
    public static ChatUi Instance {  get; private set; }


    [SerializeField] private TMP_InputField chatInput;

    [SerializeField] private GameObject chatMsgPrefab;

    [SerializeField] private Transform content;     


    void Awake ()
    {
        chatInput.onSubmit.AddListener (t => CreateChatMessage  ("Aerie", t));
    }    
    
    public void CreateChatMessage(string msg)
    {
         var chatMsgObject = Instantiate(chatMsgPrefab, content, false);
        chatMsgObject.GetComponent<TMP_Text>().text =
            $"[{name}] : {msg}";
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;  
            DontDestroyOnLoad(gameObject);
        } 
            
    }
}

