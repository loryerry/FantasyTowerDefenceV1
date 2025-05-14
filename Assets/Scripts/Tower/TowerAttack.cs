using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    float nextFire;
    public float fireRate;
    public GameObject bullet;
    public float Distance;
    public Transform closestEnemyPostion;
    public Transform ShootingPosition;

    void Update()
    {
        FindClosestEnemy();
       if(GetComponent<Tower>().Placed)
        fire();



    }



    void gun_face_enemy()
    {

        if (closestEnemyPostion != null)
        {
            Vector3 EnemyPosition = closestEnemyPostion.position;

            Vector2 directionToLookAt = new Vector2(
               EnemyPosition.x - transform.position.x,
                EnemyPosition.y - transform.position.y
                );
            transform.up = directionToLookAt;




        }

    }
    void fire()
    {

        if (Time.time > nextFire && closestEnemyPostion != null)
        {
            AudioManager.instance.PlaySound("TowerShoot");
            GameObject EvolutionBullett = Instantiate(bullet, ShootingPosition.position, Quaternion.identity);

            EvolutionBullett.GetComponent<TowerBullet>().EnemyPosition = closestEnemyPostion;
            nextFire = Time.time + fireRate;

        }

    }





    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy && distanceToEnemy < Distance * 10)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;

                closestEnemyPostion = closestEnemy.transform;

            }
        }

        if (closestEnemy != null)
        {
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);


        }
    }


  

}
