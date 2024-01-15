using UnityEngine;

public class MatchCameraRotation : MonoBehaviour
{
    public new Transform camera;
    private new Transform transform;
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        transform.rotation = camera.transform.rotation;
    }
}
