using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PostView : MonoBehaviour
{
    public Text title;
    public Text context;
    public Button updateTitle;
    public PostViewModel viewModel;

    private void Start()
    {
        updateTitle.onClick.AddListener(() =>
        {            
        });
    }
}
