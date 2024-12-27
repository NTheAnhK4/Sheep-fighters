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
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sheepWeight;
    [SerializeField] private float damage;

    private IBehavior curBehavior;
    public Rigidbody2D Rigid => rigid;

    public Vector3 Direction => direction;

    public float MoveSpeed => moveSpeed;

    public float Damage => damage;

    public void Init(Vector3 direct, float speed, float weight,float _damage, string initAnim, IBehavior behavior = null)
    {
        LoadAnimCtrl();
        this.direction = direct;
        this.moveSpeed = speed;
        this.sheepWeight = weight;
        this.damage = _damage;
        curBehavior = behavior ?? new MoveHandler();
        curBehavior.Enter(this);
        animCtrl.ChangeAnim(initAnim);
        LoadCollid();
        LoadRigid();
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
    }

    private void LoadRigid()
    {
        if(rigid == null) rigid = transform.GetComponent<Rigidbody2D>();
        
        rigid.gravityScale = 0;
        rigid.mass = sheepWeight;
        rigid.freezeRotation = true;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        Vector2 direct =  Vector2.left;
        
        if (gameObject.tag.Equals("Player"))
        {
            direct = Vector2.right;
        }
        Init(direct, 2f, 20,3,"YoungWhiteSheepMove");
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
