using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BuildingManager : MonoBehaviour
{
    
    private BuildingTypeSO activeBuildingType;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && activeBuildingType != null)
        {
            // Mouse pozisyonunu çağır ve o pozisyonda obje oluştur.
            Vector3 mousePosition = Library.GetMousePosition(); 
            Instantiate(activeBuildingType.prefab, mousePosition, Quaternion.identity);
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO activeBuildingType)
    {
        this.activeBuildingType = activeBuildingType;
    }
}
