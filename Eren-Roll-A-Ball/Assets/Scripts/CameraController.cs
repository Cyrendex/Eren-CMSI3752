using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame, after all Update functions have been called
    void LateUpdate()
    {
        // Get the player's rotation
        Quaternion playerRotation = player.transform.rotation;

        // Calculate the new position based on the player's position, rotation, and offset
        Vector3 newPosition = player.transform.position + playerRotation * offset;

        // Set the camera's position to the new position
        transform.position = newPosition;

    }
}