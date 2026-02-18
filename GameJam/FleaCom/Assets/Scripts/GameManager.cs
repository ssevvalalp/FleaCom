using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject buildingUI;
    [SerializeField] BuildingManager buildingManager;

    bool isInBuildingMode = false;
    private void Start()
    {
        // Oyun başlar başlamaz menüyü ve sistemi kapat.
        // Böylece oyuncu 'B'ye basana kadar inşaat yapamaz.
        buildingUI.SetActive(false);
        buildingManager.enabled = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 1. Önce açma/kapama işlemini yap 
          
            buildingUI.SetActive(!buildingUI.activeSelf);
            buildingManager.enabled = !buildingManager.enabled; //inşa etmek için buildinmanager

            if (Time.timeScale == 1) Time.timeScale = 0;
            else if (Time.timeScale == 0 && isInBuildingMode) Time.timeScale = 1;
            isInBuildingMode = !isInBuildingMode;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isInBuildingMode)
        {
            ChangeTimeScale();
        }   


    }

    private void ChangeTimeScale()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }else
            { Time.timeScale = 0f; }

        Debug.Log("Time Scale = " + Time.timeScale.ToString());
    }
}
