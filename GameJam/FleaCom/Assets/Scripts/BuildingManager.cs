using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.VirtualTexturing;

//Sistemi yöneten ana scripttir. Hangi binanın seçili olduğunu tutar ve tıklama anında inşaatı yapar.
public class BuildingManager : MonoBehaviour
{
    
    private BuildingTypeSO activeBuildingType; // activeBuildingType: o an elinde hangi bina var? 
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && activeBuildingType != null && ! EventSystem.current.IsPointerOverGameObject())
        {
            
            Vector3 mousePosition = Library.GetMousePosition(); // mouse'ın konumunu al
            if (CanSpawnBuilding(mousePosition))
            {
                Instantiate(activeBuildingType.prefab, mousePosition, Quaternion.identity);
            }

        }
    }

    public void SetActiveBuildingType(BuildingTypeSO activeBuildingType) //UI scripti bu fonksiyonu çağırıyor ve
                                                                         //activeBuildingType değişkenini doldurur
                                                                         //örn: artık elimizde DUVAR var
    {
        this.activeBuildingType = activeBuildingType;
    }

    public bool CanSpawnBuilding(Vector3 position)
    {
        BoxCollider2D boxCollider2D = activeBuildingType.prefab.GetComponent<BoxCollider2D>();

        if (Physics2D.OverlapBox(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0) != null)
        {
            return false;
        }
        else { 
            return true;
        }
    }

}
