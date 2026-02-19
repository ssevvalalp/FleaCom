using System;
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
        int x, y;
        Vector3 spawnPosition;
        int i = 0;

        // Sonsuz döngü kilidini önlemek için güvenlik sayacı
        int attempts = 0;
        int maxAttempts = furCount * 10;
        

        while (i < furCount && attempts < maxAttempts)
        {
            attempts++; // Her denemede sayacı artır

            // 'out' anahtar kelimesi ile GenerateXY içindeki değerleri buraya çekiyoruz
            GenerateXY(out x, out y);
            spawnPosition = new Vector3(origin.x + x, origin.y + y);

            if (CanSpawnFur(spawnPosition))
            {
                Instantiate(furPrefab, spawnPosition, Quaternion.identity);
                i++;
            }
        }

        Debug.Log("toplam yerleşen: " + i.ToString());

        // Eğer alanda yer kalmadıysa bizi uyarması için:
        if (attempts >= maxAttempts)
        {
            Debug.LogWarning($"Alan çok dar! İstenen {furCount} pireden sadece {i} tanesi yerleştirilebildi.");
        }
    }

    // Metodun parametrelerine 'out' ekledik
    private void GenerateXY(out int x, out int y)
    {
        x = UnityEngine.Random.Range(-borderX, borderX + 1);
        y = UnityEngine.Random.Range(-borderY, borderY + 1);
    }

    public bool CanSpawnFur(Vector3 position)
    {
        BoxCollider2D boxCollider2D = furPrefab.GetComponent<BoxCollider2D>();

        // OverlapBox için çakışma kontrolü
        if (Physics2D.OverlapBox(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0) != null)
        {
            return false;
        }

        return true;
    }
}