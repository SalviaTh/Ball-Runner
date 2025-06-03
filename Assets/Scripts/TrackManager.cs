using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public Transform player; // drag your player here in Inspector
    public GameObject[] trackPieces; // drag your 3-5 track pieces here
    public float trackLength = 100f; // how long each track piece is

    private int currentIndex = 0;

    void Update()
    {
        if (player.position.z > trackPieces[currentIndex].transform.position.z + trackLength)
        {
            // Move the oldest piece to the front
            GameObject movedPiece = trackPieces[currentIndex];
            float newZ = movedPiece.transform.position.z + trackLength * trackPieces.Length;

            movedPiece.transform.position = new Vector3(0, 0, newZ);

            currentIndex = (currentIndex + 1) % trackPieces.Length;
        }
    }
}
