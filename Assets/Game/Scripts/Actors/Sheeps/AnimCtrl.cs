using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimCtrl : ChildBehavior
{
    [SerializeField] private Animator anim;
    
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (anim == null) anim = transform.GetComponent<Animator>();
    }

    public void ChangeAnim(string animName)
    {
        anim.Play(animName);
    }
    public void ChangeAnimSpeed(float speed)
    {
        if (anim != null) anim.speed = speed;
    }
}
