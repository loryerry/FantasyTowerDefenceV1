using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private SpriteRenderer healthBar;
    [SerializeField] private SpriteRenderer healthFill;

    private int currentHealth;

    [SerializeField] private int GoldValue=10;




    public Transform[] waypoints; // Array of waypoints/positions to follow
    public float speed = 2.0f;   // Enemy movement speed
    private int currentWaypoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthFill.size = healthBar.size;
    }
public void SlowDown()
    {

        StartCoroutine(Slow());
    }
    public void SetTargetPosition(Vector3 targetPosition)
    {

        healthBar.transform.parent = null;
        healthBar.transform.parent = transform;
    }

    void Update()
    {
        // Check if there are waypoints to follow
        if (waypoints.Length == 0)
            return;

        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        direction.Normalize();

        // Move the enemy towards the current waypoint
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Switch to the next waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
        if (Vector3.Distance(transform.position, waypoints[waypoints.Length-1].position) < 0.1f)
        {
            // Switch to the next waypoint
            LevelManager.Instance.LivesLeft--;
            Destroy(gameObject);
        }

    }
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        AudioManager.instance.PlaySound("EnemyHit");

        if (currentHealth <= 0)
        {
            LevelManager.Instance.Gold += GoldValue;
            LevelManager.Instance.EnemyLeft--;
              currentHealth = 0;
            Destroy(gameObject);        
        }

        float healthPercentage = (float) currentHealth / maxHealth;
        healthFill.size = new Vector2 (healthPercentage * healthBar.size.x, healthBar.size.y);
    }

   IEnumerator Slow()
    {
        speed = speed / 2;

        // Yield for a few seconds
        yield return new WaitForSeconds(2.0f);

        speed = speed * 2;
    }
}
