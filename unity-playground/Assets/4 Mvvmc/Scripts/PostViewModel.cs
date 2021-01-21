using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PostViewModel
{ 
    private Post post;

    
    // public UpdateTitle updateTitle;

    

    public string postTitle
    {
        get { return post.title; }
        set
        {
            post.title = value;    
            // updateTitle(value);
        }
    }

    public PostViewModel(Post post)
    {
        this.post = post;
        // updateTitle = (value) => { };        

    }

    void UpdateTitleExecute() { Debug.Log("UpdateTitleExecute"); }
    bool CanUpdateTitleExecute() { Debug.Log("CanUpdateTitleExecute"); return true; }


}
