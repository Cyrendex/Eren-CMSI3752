using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public int winScore;
    public new Transform camera;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= winScore)
        {
            winTextObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * speed;
        float vertical = Input.GetAxisRaw("Vertical") * speed;

        Vector3 camForward = camera.forward;
        Vector3 camRight = camera.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 relativeForward = vertical * camForward;
        Vector3 relativeRight = horizontal * camRight;

        Vector3 moveDir = relativeForward + relativeRight;

        rb.AddForce(moveDir.x, rb.velocity.y, moveDir.z);
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            IncreaseCount();
        }
    }

    public void IncreaseCount()
    {
        count = count + 1;
        SetCountText();
    }
}
