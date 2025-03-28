using Mirror;
using UnityEngine;

public class NetworkManagerCustom : NetworkManager
{
    // Reference to your Player prefab; assign this in the Inspector.
    public GameObject playerPrefab;

    // Called on the server when a new client connects.
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // You can customize spawn logic here.
        // If you have start positions defined, you could use GetStartPosition().
        Vector3 spawnPosition = Vector3.zero;
        if (startPositions != null && startPositions.Count > 0)
        {
            spawnPosition = startPositions[0].position;
        }
        else if (GetStartPosition() != null)
        {
            spawnPosition = GetStartPosition().position;
        }
        GameObject playerObj = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, playerObj);
    }
}
