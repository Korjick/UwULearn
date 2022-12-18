using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Friends
{
    public class FriendsPage : MonoBehaviour
    {
        public event Action HomeButtonClicked;
        public event Action CoursesButtonClicked;
        public event Action ChatsButtonClicked;

        [SerializeField] private FriendView _friendViewPrefab;
        [SerializeField] private Transform _container;
        [Space]
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _coursesButton;
        [SerializeField] private Button _chatsButton;

        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var friend = Instantiate(_friendViewPrefab, _container);
                friend.Init(i);
            }

            _homeButton.onClick.AddListener(() => HomeButtonClicked?.Invoke());
            _coursesButton.onClick.AddListener(() => CoursesButtonClicked?.Invoke());
            _chatsButton.onClick.AddListener(() => ChatsButtonClicked?.Invoke());
        }
    }
}
