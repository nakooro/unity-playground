using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace mvvmc
{
    public enum MesssageViewState
    {
        None, Loading
    } 
    public class MessageViewModel : MonoBehaviour  //services di, use service
    {
        // Services
        // e.g. StorageService Load()
        public Action<MesssageViewState> OnStateChanged = delegate { };
        public Action OnMessagesUpdate = delegate { };
        public Action OnRefreshClicked = delegate { };

        private List<Message> messages;
        public List<Message> Messages
        {
            get => messages;
            private set
            {
                if (Messages != messages || messages == null)
                {
                    messages = value;
                    OnMessagesUpdate.Invoke();
                }
            }
        }
        

        private MesssageViewState currentState;
        public MesssageViewState CurrentState
        {
            get => currentState;
            private set
            {
                if (value != CurrentState)
                {
                    OnStateChanged.Invoke(value);
                    currentState = value;
                }
            }
        } 


        void Awake()
        {
            CurrentState = MesssageViewState.None;
            OnRefreshClicked += _OnRefreshClicked;
        }
        void _OnRefreshClicked()
        {
            DownloadMessages();
        }
        IEnumerator FetchMessages()
        {            
            Messages = new List<Message>()
            {
                new Message(){ username = "1", context = "1context"},
                new Message(){ username = "2", context = "2context"},
                new Message(){ username = "3", context = "3context"},
            };
            yield return Messages;
            CurrentState = MesssageViewState.None;
        }
        public void DownloadMessages()
        {
            CurrentState = MesssageViewState.Loading;
            StartCoroutine(FetchMessages());
        }

        public void SpawnCells(MessageCellView view, Transform spawnRoot)
        {
            if (Messages.Count == 0) return;
            for (var i=0; i!=Messages.Count; i++)
            {
                GameObject o = Instantiate(view.gameObject, spawnRoot);
                MessageCellView cell = o.GetComponent<MessageCellView>();
                cell.username.text = Messages[i].username;
                cell.context.text = Messages[i].context;
            }
        }
    }

}
