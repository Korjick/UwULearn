using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Courses
{
    public class CoursesPage : MonoBehaviour
    {
        public event Action FriendsButtonClicked;
        public event Action HomeButtonClicked;
        public event Action ChatsButtonClicked;

        [SerializeField] private CourseView _courseViewPrefab;
        [SerializeField] private Transform _container;
        [Space]
        [SerializeField] private Button _friendsButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _chatsButton;

        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var course = Instantiate(_courseViewPrefab, _container);
                course.Init(i);
            }

            _friendsButton.onClick.AddListener(() => FriendsButtonClicked?.Invoke());
            _homeButton.onClick.AddListener(() => HomeButtonClicked?.Invoke());
            _chatsButton.onClick.AddListener(() => ChatsButtonClicked?.Invoke());
        }
    }
}
