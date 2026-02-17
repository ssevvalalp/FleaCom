using UnityEngine;

[CreateAssetMenu()]
public class BuildingTypeSO : ScriptableObject 
{
    public string nameString;
    public Transform prefab;
    public Sprite sprite;
}

//BuildingTypeSO dosyan, binaların DNA'sını taşıyan veri dosyalarıdır. ,
//BuildingManager ise bu DNA'yı okuyup sahneye gerçek binayı diken ustadır.