using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public Tower placedTower;
    public bool IsOccupied;

    void Update()
    {
        // Обновляем статус занятой клетки, если башня размещена
        IsOccupied = (placedTower != null && placedTower.Placed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (placedTower != null || IsOccupied)
            return;

        Tower tower = collision.GetComponent<Tower>();
        if (tower != null && !tower.Placed && LevelManager.Instance.Gold >= tower.Tower_Cost)
        {
            tower.SetPlacePosition(transform.position);
            placedTower = tower;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Tower tower = collision.GetComponent<Tower>();
        if (tower == null || tower != placedTower)
            return;

        // Не отменяем размещение, если башня уже установлена
        if (tower.Placed)
            return;

        tower.SetPlacePosition(null);
        placedTower = null;
    }
}
