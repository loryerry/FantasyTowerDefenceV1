using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float speed =8.0f;
    public int damage = 1;
    public Transform EnemyPosition;
    public bool Slow;
    Vector3 direction;

    // public Vector3 change_derection;
    void Start()
    {

        direction = (EnemyPosition.position - transform.position).normalized;
    }

    void Update()
    {
        if (EnemyPosition == null)
        {
            Destroy(gameObject);

        }
        if (EnemyPosition!=null&&transform.position == EnemyPosition.position)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 3);


        transform.position += (direction) * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {


            col.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            if (Slow)
            {
                col.gameObject.GetComponent<Enemy>().SlowDown();
            }
         

            Destroy(gameObject);
        }

    }

}