using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public bool Placed;
    [SerializeField] private Sprite Tower_Icon;
    [SerializeField] public int Tower_Cost;
    [SerializeField] private SpriteRenderer towerPlace;
    [SerializeField] private SpriteRenderer towerHead;
    public Vector2? PlacePosition { get; private set; }

    public Sprite GetTowerHeadIcon ()
    {
        return Tower_Icon;
    }

    public void SetPlacePosition(Vector2? newPosition)
    {
        PlacePosition = newPosition;
    }

    public void LockPlacement ()
    {
            LevelManager.Instance.Gold -= Tower_Cost;
            Placed = true;
            transform.position = (Vector2)PlacePosition;
                
    }

  
}
