using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostViewController : MonoBehaviour
{
    PostViewModel viewModel;

    void Start()
    {
        viewModel = new PostViewModel(new Post { title = "new Title", context = "new Context" });

                
    }





}

