using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    // This variable is synchronized across all clients.
    [SyncVar]
    public string playerName;

    void Start()
    {
        // Only the local player should execute local input code.
        if (!isLocalPlayer) return;

        // Set a default name (could be replaced by user input later).
        CmdSetPlayerName("Player_" + Random.Range(100, 999));
    }

    // Command to set the player's name on the server.
    [Command]
    void CmdSetPlayerName(string newName)
    {
        playerName = newName;
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        // Example: On left mouse click, attempt to place a road.
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the 3D world.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 placementPos = hit.point;
                CmdPlaceRoad(placementPos);
            }
        }
    }

    // Command to request road placement; runs on the server.
    [Command]
    void CmdPlaceRoad(Vector3 position)
    {
        // Load the Road prefab from the Resources folder.
        GameObject roadPrefab = Resources.Load<GameObject>("Prefabs/Road");
        if (roadPrefab == null)
        {
            Debug.LogError("Road prefab not found in Resources/Prefabs!");
            return;
        }
        GameObject road = Instantiate(roadPrefab, position, Quaternion.identity);
        NetworkServer.Spawn(road);
    }
}
