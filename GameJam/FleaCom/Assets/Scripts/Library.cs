using UnityEngine;

public static class Library 
{
    public static Vector3 GetMousePosition()
    {
        //mouse'un pozisyounu tut
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        return worldPosition;
    }
}

//Input.mousePosition: Farenin ekran üzerindeki (piksel cinsinden) yerini alır 
//    (Örn: 1920x1080 ekranda 500, 300 noktası).


//Camera.main.ScreenToWorldPoint(...): Bu pikseli oyun dünyasındaki gerçek koordinata (World Space) çevirir.

//worldPosition.z = 0;: Oyun 2D olduğu için derinliği (Z eksenini) sıfırlar.
//Bunu yapmazsan obje kameranın içinde veya çok arkasında oluşabilir.