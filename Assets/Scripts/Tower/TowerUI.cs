using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TowerUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _towerIcon;
    [SerializeField] private TMP_Text TowerCostText;
    [SerializeField] private int TowerCost;

    private Tower towerPrefab;
    private Tower currentSpawnedTower;

    public bool can;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((LevelManager.Instance.Gold - TowerCost) >= 0)
        {
            can = true;
        }
        else
        {
            can = false;

        }
    }

    public void SetTowerPrefab(Tower tower)
    {
        towerPrefab = tower;
        TowerCost = tower.Tower_Cost;
        TowerCostText.text = tower.Tower_Cost.ToString();
        _towerIcon.sprite = tower.GetTowerHeadIcon();
    }

   
    public void OnBeginDrag(PointerEventData eventData)
    {
     
        GameObject newTowerObj = Instantiate(towerPrefab.gameObject);
        currentSpawnedTower = newTowerObj.GetComponent<Tower>();

   
    }

 
    public void OnDrag(PointerEventData eventData)
    {
        Camera mainCamera = Camera.main;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        currentSpawnedTower.transform.position = targetPosition;
    }

   
    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentSpawnedTower.PlacePosition == null)
        {
            Destroy(currentSpawnedTower.gameObject);
        }

        else
        {
            currentSpawnedTower.LockPlacement();
            currentSpawnedTower = null;
        }
    }
}
