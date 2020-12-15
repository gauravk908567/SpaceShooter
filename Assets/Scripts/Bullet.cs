using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float DeactivateTime = 3f;

    [HideInInspector]
    public bool is_EnemyBullet = false;


    void Start()
    {
        if (is_EnemyBullet)
        {
            speed *= -1f;
        }


        Invoke("DeactivateGobj", DeactivateTime);

       
    }

   
    void Update()
    {
        Move();
        
    }

    public void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateGobj()
    {
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Bullet"||target.tag=="Enemy")
        {
            gameObject.SetActive(false);
        }
    }



}//class
 