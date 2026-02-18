using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject buildingUI;
    [SerializeField] BuildingManager buildingManager;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildingUI.SetActive(!buildingUI.activeSelf);
            buildingManager.enabled = !buildingManager.enabled;
        }
 
    }
}
