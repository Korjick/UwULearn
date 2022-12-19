using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu.Chats
{
    public class ChatDialog : MonoBehaviour
    {
        [SerializeField] private ChatMessage _chatMessagePrefab;
        [SerializeField] private Transform _messageContainer;
        [Space]
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _sendButton;

        private Coroutine _getMessagesCoroutine;
        private int _user_id; // TODO add user id
        

        private void Start()
        {
            _sendButton.onClick.AddListener(() => StartCoroutine(SendCoroutine()));

            StartCoroutine(CheckForMessages());
        }

        private IEnumerator CheckForMessages()
        {
            while (true)
            {
                GetMessages();
                yield return null;
            }
        }
        
        private void GetMessages()
        {
            _getMessagesCoroutine ??= StartCoroutine(GetMessagesCoroutine());
        }

        private IEnumerator GetMessagesCoroutine()
        {
            UnityWebRequest uwr = UnityWebRequest.Get(Constants.ServerAddress + "/Chat");
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
                ReceivedData.Root result = JsonUtility.FromJson<ReceivedData.Root>(uwr.downloadHandler.text);
                var message = Instantiate(_chatMessagePrefab, _messageContainer);
                message.Init(result.from.username, result.date, result.text);
            }

            _getMessagesCoroutine = null;
        }

        private IEnumerator SendCoroutine()
        {
            WWWForm form = new WWWForm();
            form.AddField("from", _user_id);
            form.AddField("date", DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            form.AddField("text", _inputField.text);
            
            UnityWebRequest uwr = UnityWebRequest.Post(Constants.ServerAddress + "/Chat", form);
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
                if (uwr.responseCode == 201)
                {
                    yield break;
                }
            }
            
            // show error sending message
            Debug.LogError("Error message sending");
        }
    }
}