using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Chats
{
    public class ChatView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string[] _names;
        [SerializeField] private Sprite[] _icons;
        
        public void Init(int id)
        {
            _icon.sprite = _icons[id % _icons.Length];
            _text.text = "Написать\n" + _names[id % _names.Length];
        }
    }
}