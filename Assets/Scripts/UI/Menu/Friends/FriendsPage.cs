using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Friends
{
    public class FriendsPage : PageBase
    {
        [SerializeField] private FriendView _friendViewPrefab;
        [SerializeField] private Transform _container;

        public override void Init()
        {
            base.Init();
            for (int i = 0; i < 10; i++)
            {
                var friend = Instantiate(_friendViewPrefab, _container);
                friend.Init(i);
            }
        }
    }
}
