using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5f;
    public float rotate_speed = 50f;
    public bool canShoot;
    public bool canRotate;
    public bool canMove = true;

    public float Bound_X = -10f;
    public Transform attack_point;
    public GameObject Enemybullet;

    private Animator Anim;
    private AudioSource ExplosionSound;
  
    void Awake()
    {
        Anim = GetComponent<Animator>();
        ExplosionSound = GetComponent<AudioSource>();

    }

     void Start()
    {
        if(canRotate)
        {
            if(Random.Range(0,2)>0)
            {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
                rotate_speed *= -1f;
            }
        }

        if (canShoot)
        {
            Invoke("startshoot", Random.Range(0.4f, 1f));

        }

    }
        

    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if(canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(temp.x<Bound_X)
            {
                gameObject.SetActive(false);

            }
        }
    }

    void RotateEnemy()
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_speed * Time.deltaTime), Space.World);
        }
    }

    void startshoot()
    {
        GameObject bullet = Instantiate(Enemybullet, attack_point.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().is_EnemyBullet = true;
        if(canShoot)
        {
            Invoke("startshoot", Random.Range(0.5f, 0.9f));

        }
    }

    void Turnoff()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Bullet")
        {
            canMove = false;
            if(canShoot)
            {
                canShoot = false;
                CancelInvoke("startshoot");
            }

            Invoke("Turnoff", .5f);
            ExplosionSound.Play();
            Anim.Play("Destroy");
        }
    }

}
