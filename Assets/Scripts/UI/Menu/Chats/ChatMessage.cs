using System;
using TMPro;
using UnityEngine;

namespace UI.Menu.Chats
{
    public class ChatMessage : MonoBehaviour
    {
        [SerializeField] private TMP_Text _usernameText;
        [SerializeField] private TMP_Text _dateText;
        [SerializeField] private TMP_Text _textText;
        
        public void Init(string username, DateTime time, string text)
        {
            _usernameText.text = username;
            _dateText.text = DateTime.Now.Subtract(time).Days > 0 ? time.ToString("dd-MM-yyyy hh:mm:ss") : time.ToString("hh:mm:ss");
            _textText.text = text;
        }
    }
}