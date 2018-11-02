using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Player Stats
    public int Health;
    public int MaxHealth;
   
    //Player Movement
    [SerializeField]
    private float Speed;
    private Vector2 Direction;
   
    public void Move()
    {
        transform.Translate(Direction*Speed*Time.deltaTime);
        AnimationMovement(Direction);
    }

    private void GetInput()
    {
        Direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction += Vector2.right;
        }
    }

    //PlayerAnimations
    public Animator anim;

    public void AnimationMovement(Vector2 Direction)
    {
        anim.SetFloat("x", Direction.x);
        anim.SetFloat("y", Direction.y);
    }

    //PlayerWeapons
    public int Damage;
    public static int WeaponNumber;
    public int Ammo;
    public int ShootingSpeed;
    public string WeaponName;

    public void Weapon_Selector()
    {
        if (WeaponNumber == 1)
        {
            Damage = 10;
            WeaponName = "Death Scythe";
        }
        if (WeaponNumber == 2)
        {
            Damage = 10;
            WeaponName = "Pistol";
            ShootingSpeed = 1;
            Ammo = 15;
        }
        if (WeaponNumber == 3)
        {
            Damage = 10;
            WeaponName = "Ak-47";
            ShootingSpeed = 5;
            Ammo = 30;
        }
    }




    //Game
    void Start()
    {
        Health = 10;
        Speed = 2;
        Damage = 10;
        
        WeaponNumber = 0;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        GetInput();
        Test();
        Weapon_Selector();
    }



    void Test()
    {
        if (Input.GetKey(KeyCode.T))
        { 
            Debug.Log(Speed);
            Debug.Log(Damage);
            Debug.Log(WeaponName);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            WeaponNumber = 1;
        }
        if (Input.GetKey(KeyCode.X))
        {
            WeaponNumber = 2;
        }
        if (Input.GetKey(KeyCode.C))
        {
            WeaponNumber = 3;
        }

    }


}
