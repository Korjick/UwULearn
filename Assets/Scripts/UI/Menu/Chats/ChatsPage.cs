using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Chats
{
    public class ChatsPage : MonoBehaviour
    {
        public event Action FriendsButtonClicked;
        public event Action CoursesButtonClicked;
        public event Action HomeButtonClicked;
        
        [SerializeField] private ChatView _chatViewPrefab;
        [SerializeField] private Transform _container;
        [Space]
        [SerializeField] private Button _friendsButton;
        [SerializeField] private Button _coursesButton;
        [SerializeField] private Button _homeButton;

        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var chat = Instantiate(_chatViewPrefab, _container);
                chat.Init(i);
            }

            _friendsButton.onClick.AddListener(() => FriendsButtonClicked?.Invoke());
            _coursesButton.onClick.AddListener(() => CoursesButtonClicked?.Invoke());
            _homeButton.onClick.AddListener(() => HomeButtonClicked?.Invoke());
        }
    }
}