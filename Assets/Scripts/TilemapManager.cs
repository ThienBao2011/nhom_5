using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap tilemap; // Gán Tilemap từ Unity Inspector

    public void DestroyTilemap()
    {
        if (tilemap != null)
        {
            Destroy(tilemap.gameObject);
        }
    }
}