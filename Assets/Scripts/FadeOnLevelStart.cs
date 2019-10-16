﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnLevelStart : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("FadeOut");
    }

}
