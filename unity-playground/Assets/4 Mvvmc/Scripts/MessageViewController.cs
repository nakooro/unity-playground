using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using mvvmc;

namespace mvvmc
{
    public class MessageViewController : MonoBehaviour //Binding
    {
        [SerializeField] private MessageViewModel viewModel;
        public MessageCellView messageCellView;
        public Text usrename;
        public Text context;
        public Button submit;
        public Button refresh;

        void Start()
        {
            refresh.onClick.AddListener(() => {
                viewModel.OnRefreshClicked.Invoke();
            });

            viewModel.OnStateChanged += _OnStateChanged;
            viewModel.OnMessagesUpdate += _OnMessagesUpdate;
        }

        void _OnStateChanged(MesssageViewState state)
        {
            print("View Changed" + state.ToString());
        }
        void _OnMessagesUpdate()
        {
            viewModel.SpawnCells(messageCellView, messageCellView.transform.parent);
        }

    }

}
