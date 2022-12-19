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

            foreach (PageBase pageBase in new PageBase[]{_mainPage, _friendsPage, _coursesPage, _chatsPage})
            {
                pageBase.FriendsButtonClicked += () => EnableFriends();
                pageBase.CoursesButtonClicked += () => EnableCourses();
                pageBase.ChatsButtonClicked += () => EnableChats();
                pageBase.ExitButtonClicked += () => EnableMain();
            }
            
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
