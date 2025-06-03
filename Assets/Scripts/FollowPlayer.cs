
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+ offset;
    }
}
