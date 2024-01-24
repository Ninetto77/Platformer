using Cainos.LucidEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChest : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool IsOpened
    {
        get { return isOpened; }
        set
        {
            isOpened = value;
            animator.SetBool("IsOpened", isOpened);
        }
    }
    private bool isOpened;

    public void SetIsOpen(bool value)
    {
        IsOpened = value;
    }


}
