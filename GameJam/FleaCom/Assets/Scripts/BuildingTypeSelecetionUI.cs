using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // <--- 1. Bunu mutlaka ekle!

public class BuildingTypeSelecetionUI : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> buildingTypes;
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private BuildingManager buildingManager;

    private void Awake()
    {
        foreach (BuildingTypeSO currType in buildingTypes)
        {
            GameObject CurrentButton = Instantiate(buttonTemplate, transform);

            // İkonu değiştir
            Image currBtnImg = CurrentButton.GetComponent<Image>();
            currBtnImg.sprite = currType.sprite;

            // --- Yazıyı Değiştir ---
            // 2. Tür olarak 'TextMeshProUGUI' kullanıyoruz
            TextMeshProUGUI buttonText = CurrentButton.GetComponentInChildren<TextMeshProUGUI>();

            // 3. Yazıyı SO içindeki isimle değiştiriyoruz (SO'da 'nameString' olduğunu varsayıyorum)
            buttonText.text = currType.nameString;

            CurrentButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                buildingManager.SetActiveBuildingType(currType);
            });
        }
    }
}