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
