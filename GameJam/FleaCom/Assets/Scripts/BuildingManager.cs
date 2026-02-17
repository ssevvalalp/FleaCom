using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.VirtualTexturing;

//Sistemi yöneten ana scripttir. Hangi binanın seçili olduğunu tutar ve tıklama anında inşaatı yapar.
public class BuildingManager : MonoBehaviour
{
    
    private BuildingTypeSO activeBuildingType; // activeBuildingType: o an elinde hangi bina var? 
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && activeBuildingType != null)
        {
            
            Vector3 mousePosition = Library.GetMousePosition(); // mouse'ın konumunu al
            Instantiate(activeBuildingType.prefab, mousePosition, Quaternion.identity); // Instantiate: Seçili binanın prefabını (activeBuildingType.prefab),
                                                                                        // farenin olduğu yere, dönme açısı olmadan (Quaternion.identity) yarat.

        }
    }

    public void SetActiveBuildingType(BuildingTypeSO activeBuildingType) //UI scripti bu fonksiyonu çağırıyor ve
                                                                         //activeBuildingType değişkenini doldurur
                                                                         //örn: artık elimizde DUVAR var
    {
        this.activeBuildingType = activeBuildingType;
    }
}
