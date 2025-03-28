using Mirror;
using UnityEngine;

public class HexTileController : NetworkBehaviour
{
    // A unique ID or coordinate for the tile.
    [SyncVar]
    public int tileID;

    // Example property: type of resource or terrain.
    [SyncVar]
    public string tileType;

    void Start()
    {
        // Initialization logic for the tile (if needed).
    }
}
