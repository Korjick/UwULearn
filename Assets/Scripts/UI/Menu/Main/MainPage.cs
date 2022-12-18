using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Main
{
    public class MainPage : MonoBehaviour
    {
        public event Action FriendsButtonClicked;
        public event Action CoursesButtonClicked;
        public event Action ChatsButtonClicked;

        [SerializeField] private Button _friendsButton;
        [SerializeField] private Button _coursesButton;
        [SerializeField] private Button _chatsButton;

        public void Init()
        {
            _friendsButton.onClick.AddListener(() => FriendsButtonClicked?.Invoke());
            _coursesButton.onClick.AddListener(() => CoursesButtonClicked?.Invoke());
            _chatsButton.onClick.AddListener(() => ChatsButtonClicked?.Invoke());
        }
    }
}