using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Chats
{
    public class ChatsPage : PageBase
    {
        
        [SerializeField] private ChatView _chatViewPrefab;
        [SerializeField] private Transform _container;

        public override void Init()
        {
            base.Init();
            for (int i = 0; i < 10; i++)
            {
                var chat = Instantiate(_chatViewPrefab, _container);
                chat.Init(i);
            }
        }
    }
}