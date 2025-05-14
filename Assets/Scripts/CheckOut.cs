using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AudioManager.instance.PlaySound("ChekOut");
            LevelManager.Instance.LivesLeft--;
            Destroy(collision.gameObject);

        }
    }
}
