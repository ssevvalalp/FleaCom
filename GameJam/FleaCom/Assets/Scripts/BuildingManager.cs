using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject house;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Mouse pozisyonunu çağır ve o pozisyonda obje oluştur.
            Vector3 mousePosition = Library.GetMousePosition(); 
            Instantiate(house, mousePosition, Quaternion.identity);
        }
    }
}
