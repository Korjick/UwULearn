using System;
using UI.Menu.Chats;
using UI.Menu.Courses;
using UI.Menu.Friends;
using UI.Menu.Main;
using UnityEngine;

namespace UI.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private MainPage _mainPage;
        [SerializeField] private FriendsPage _friendsPage;
        [SerializeField] private CoursesPage _coursesPage;
        [SerializeField] private ChatsPage _chatsPage;

        private void Start()
        {
            _mainPage.Init();
            _friendsPage.Init();
            _coursesPage.Init();
            _chatsPage.Init();
            
            _mainPage.FriendsButtonClicked += () => EnableFriends();
            _mainPage.CoursesButtonClicked += () => EnableCourses();
            _mainPage.ChatsButtonClicked += () => EnableChats();
            
            _friendsPage.HomeButtonClicked += () => EnableMain();
            _friendsPage.CoursesButtonClicked += () => EnableCourses();
            _friendsPage.ChatsButtonClicked += () => EnableChats();
            
            _coursesPage.FriendsButtonClicked += () => EnableFriends();
            _coursesPage.HomeButtonClicked += () => EnableMain();
            _coursesPage.ChatsButtonClicked += () => EnableChats();
            
            _chatsPage.FriendsButtonClicked += () => EnableFriends();
            _chatsPage.CoursesButtonClicked += () => EnableCourses();
            _chatsPage.HomeButtonClicked += () => EnableMain();
            
            EnableMain();
        }

        private void EnableMain()
        {
            _mainPage.gameObject.SetActive(true);
            _friendsPage.gameObject.SetActive(false);
            _coursesPage.gameObject.SetActive(false);
            _chatsPage.gameObject.SetActive(false);
        }

        private void EnableFriends()
        {
            _mainPage.gameObject.SetActive(false);
            _friendsPage.gameObject.SetActive(true);
            _coursesPage.gameObject.SetActive(false);
            _chatsPage.gameObject.SetActive(false);
        }

        private void EnableCourses()
        {
            _mainPage.gameObject.SetActive(false);
            _friendsPage.gameObject.SetActive(false);
            _coursesPage.gameObject.SetActive(true);
            _chatsPage.gameObject.SetActive(false);
        }

        private void EnableChats()
        {
            _mainPage.gameObject.SetActive(false);
            _friendsPage.gameObject.SetActive(false);
            _coursesPage.gameObject.SetActive(false);
            _chatsPage.gameObject.SetActive(true);
        }
    }
}
