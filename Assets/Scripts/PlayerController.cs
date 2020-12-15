using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 7f;
    public float MinY;
    public float MaxY;
    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private Transform Attackpoint;

    public float attack_timer = 0.35f;

    private float current_attacktimer;

    private bool canAttack;


    private AudioSource Laser;

    private void Awake()
    {
        Laser = GetComponent<AudioSource>();

    }
    void Start()
    {
        current_attacktimer = attack_timer;
    }

    
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            
            if(temp.y > MaxY)
            {
                temp.y = MaxY;
            }
            transform.position = temp;  
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < MinY)
            {
                temp.y = MinY;
            }
            transform.position = temp;
        }
    }

    public void Attack()
    {
        attack_timer += Time.deltaTime;
        if (attack_timer > current_attacktimer)
        {
            canAttack = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_timer = 0f;
                Instantiate(Bullet, Attackpoint.position, Quaternion.identity);

                //play the sfx

                Laser.Play();
               
            }
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="EnemyBullet"||collision.tag=="Enemy")
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
    }

}//class
