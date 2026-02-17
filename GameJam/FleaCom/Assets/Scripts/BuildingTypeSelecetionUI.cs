using System.Collections.Generic;
using System.Data;
using TMPro; // <--- 1. Bunu mutlaka ekle!
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelecetionUI : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> buildingTypes;
    //Menü Listesi.Oyununda hangi binalar varsa (Kule, Duvar, Tuzak...),
    //   bu listeye sürükleyip bırakırsın. Script buraya bakarak kaç tane buton yaratacağını anlar.
    [SerializeField] private GameObject buttonTemplate;
    //Tek bir tane örnek buton tasarlarsın.Script bu butonu kopyalayarak (çoğaltarak) diğer butonları oluşturur.
    [SerializeField] private BuildingManager buildingManager;
    //Butona tıklandığında kime haber vereceğiz? Tabi ki inşaatı yapacak olan Manager'a.

    private void Awake()
    {
        foreach (BuildingTypeSO currType in buildingTypes)
        {
            GameObject CurrentButton = Instantiate(buttonTemplate, transform);
                    //Instantiate: Kopyalama komutudur. buttonTemplate objesinden bir kopya yaratır.
                    //İkinci parametre olarak transform yazdığımız için,
                    //yeni yaratılan butonu bu objenin çocuğu yapar.

            // İkonu değiştir
            Image currBtnImg = CurrentButton.GetComponent<Image>();
            currBtnImg.sprite = currType.sprite;

            // --- Yazıyı Değiştir ---
                    // 2. Tür olarak 'TextMeshProUGUI' kullanıyoruz
            TextMeshProUGUI buttonText = CurrentButton.GetComponentInChildren<TextMeshProUGUI>();
                    //GetComponentInChildren: Butonun içindeki/ altındaki objelerde TextMeshPro bileşeni arar.
                    //        (Çünkü yazı genellikle butonun çocuğudur).

            // 3. Yazıyı SO içindeki isimle değiştiriyoruz (SO'da 'nameString' olduğunu varsayıyorum)
            buttonText.text = currType.nameString;

            // Tıklama Eventi
            CurrentButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                buildingManager.SetActiveBuildingType(currType);
            });
        }
    }
}
                //buildingManager.SetActiveBuildingType(currType):

                //Kullanıcı butona tıkladığında, BuildingManager scriptine gider.

                //Onun SetActiveBuildingType fonksiyonunu çalıştırır.

                //Parametre olarak da o anki döngüdeki binayı (currType) gönderir.

                //Sonuç: Manager artık elinde hangi binanın (Örn: Kule) olduğunu bilir ve haritaya tıkladığında onu inşa eder.