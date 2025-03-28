using Mirror;
using UnityEngine;

public class RoadController : NetworkBehaviour
{
    // You can store information like which player owns this road.
    [SyncVar]
    public int ownerID;

    // Optionally, store any other state (e.g., connected hexes).
    [SyncVar]
    public Vector3 placementPosition;

    void Start()
    {
        // Initialization logic for the road.
    }
}
