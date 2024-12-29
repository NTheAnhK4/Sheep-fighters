using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SheepCtrl : ParentBehavior
{
    [SerializeField] private AnimCtrl animCtrl;
    [SerializeField] private BoxCollider2D collid;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Vector3 direction;
    [SerializeField] private string sheepName;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sheepWeight;
    [SerializeField] private float damage;

    private IBehavior curBehavior;
    public Rigidbody2D Rigid => rigid;

    public Vector3 Direction => direction;

    public float MoveSpeed => moveSpeed;

    public float Damage => damage;

    public AnimCtrl AnimCtrl => animCtrl;

    public void Init(Vector3 direct, SheepParam sheepParam, string initAnim, IBehavior behavior = null)
    {
        LoadAnimCtrl();
        this.direction = direct;
        this.moveSpeed = sheepParam.speed;
        this.sheepWeight = sheepParam.weight;
        this.damage = sheepParam.damage;
        this.sheepName = sheepParam.name;
        curBehavior = behavior ?? new MoveHandler();
        ChangeAnim(initAnim);
        LoadCollid();
        LoadRigid();
        curBehavior.Enter(this);
    }

    private void LoadAnimCtrl()
    {
        if(animCtrl != null) return;
        animCtrl = transform.GetComponentInChildren<AnimCtrl>();
    }
    private void LoadCollid()
    {
        if(collid != null) return;
        collid = transform.GetComponent<BoxCollider2D>();
        collid.offset = new Vector2(0.05f, 0);
        collid.size = new Vector2(1.2f, 0.25f);
    }

    private void LoadRigid()
    {
        if(rigid == null) rigid = transform.GetComponent<Rigidbody2D>();
        
        rigid.gravityScale = 0;
        rigid.mass = sheepWeight;
        rigid.freezeRotation = true;
    }

    public void ChangeAnim(string animName)
    {
        animCtrl.ChangeAnim(sheepName.Replace(" ", "") + animName);
    }

    public void ChangeBehavior(IBehavior newBehavior)
    {
        curBehavior?.Exit(this);
        curBehavior = newBehavior;
        curBehavior?.Enter(this);
    }
    private void Update()
    {
        if(transform.position.x < -7 || transform.position.x > 7) ChangeBehavior(new AttackHandler());
        curBehavior.Execute(this);
    }
}
