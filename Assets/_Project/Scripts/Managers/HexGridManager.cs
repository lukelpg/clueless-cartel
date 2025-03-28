using Mirror;
using UnityEngine;

public class HexGridManager : NetworkBehaviour
{
    // Reference to your HexTile prefab; assign this in the Inspector.
    public GameObject hexTilePrefab;
    
    public int gridWidth = 5;
    public int gridHeight = 5;
    // Dimensions based on your 3D hex model. Adjust these as needed.
    public float tileWidth = 1.0f;
    public float tileHeight = 0.866f;

    // Called when the server starts; only the server spawns the grid.
    public override void OnStartServer()
    {
        base.OnStartServer();
        GenerateHexGrid();
    }

    [Server]
    void GenerateHexGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 pos = CalculateHexPosition(x, y);
                // For 3D, you might want the hex tiles rotated (e.g., flat on the ground).
                GameObject tile = Instantiate(hexTilePrefab, pos, Quaternion.Euler(90, 0, 0));
                NetworkServer.Spawn(tile);
            }
        }
    }

    // Calculates the world position for a hex tile at grid coordinates (x,y).
    Vector3 CalculateHexPosition(int x, int y)
    {
        float xOffset = x * tileWidth * 0.75f;
        float yOffset = y * tileHeight;
        // Offset every other column (or row) for hex alignment.
        if (x % 2 == 1)
            yOffset += tileHeight * 0.5f;
        return new Vector3(xOffset, 0, yOffset);
    }
}
