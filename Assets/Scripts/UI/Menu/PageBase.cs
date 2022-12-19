using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class PageBase : MonoBehaviour
    {
        public event Action FriendsButtonClicked;
        public event Action CoursesButtonClicked;
        public event Action ChatsButtonClicked;
        public event Action ExitButtonClicked;

        [SerializeField] private Button _friendsButton;
        [SerializeField] private Button _coursesButton;
        [SerializeField] private Button _chatsButton;
        [SerializeField] private Button _exitButton;
        
        
        public virtual void Init()
        {
            _friendsButton?.onClick.AddListener(() => FriendsButtonClicked?.Invoke());
            _coursesButton?.onClick.AddListener(() => CoursesButtonClicked?.Invoke());
            _chatsButton?.onClick.AddListener(() => ChatsButtonClicked?.Invoke());
            _exitButton?.onClick.AddListener(() => ExitButtonClicked?.Invoke());
        }
    }
}