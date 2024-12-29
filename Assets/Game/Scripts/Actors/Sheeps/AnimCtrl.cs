using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimCtrl : ChildBehavior
{
    [SerializeField] private Animator anim;

    
    public void FlipAnim(bool isFacingRight)
    {
        Vector3 curScalse = transform.localScale;
        if (curScalse.x > 0 && !isFacingRight || (curScalse.x < 0 && isFacingRight))
        {
            transform.localScale = new Vector3(curScalse.x * -1, curScalse.y, curScalse.z);
        }
    }
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
