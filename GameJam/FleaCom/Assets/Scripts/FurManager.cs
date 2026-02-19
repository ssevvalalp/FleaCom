using System;
using System.Net.NetworkInformation;
using UnityEngine;


public class FurManager : MonoBehaviour
{

    [SerializeField] private GameObject furPrefab;
    [SerializeField] private Vector2 origin;
    [SerializeField] private int borderX, borderY;
    [SerializeField] private int furCount;

    private void Awake()
    {
        PlaceFurs();
    }

    private void PlaceFurs()
    {
        int x = 0, y = 0;
        Vector3 spawnPosition;
        int i = 0;

        while (i < furCount) 
        {
            GenerateXY(x, y);
            spawnPosition = new Vector3(origin.x + x, origin.y + y);

            if (CanSpawnFur(spawnPosition))
            {
                Instantiate(furPrefab, spawnPosition, Quaternion.identity);
                i++;
            }
        }
   
    }

    private void GenerateXY(int x, int y)
    {
        x = UnityEngine.Random.Range(-borderX, borderX + 1);
        y = UnityEngine.Random.Range(-borderY, borderY + 1);      
    }

    public bool CanSpawnFur(Vector3 position)
    {
        BoxCollider2D boxCollider2D = furPrefab.GetComponent<BoxCollider2D>();

        if (Physics2D.OverlapBox(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}

