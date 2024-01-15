using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject jumpscareController;
    [SerializeField] float speed = 15.0f;
    [SerializeField] int health = 3;
    private Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            player.GetComponent<PlayerController>().IncreaseCount();
            Destroy(gameObject);
        }
        SeekPlayer();
    }

    void SeekPlayer(){
        Vector3 playerPos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        rb.MovePosition(playerPos);
    }

    public void DecreaseHealth()
    {
        health = health - 1;
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(jumpscareController.GetComponent<Jumpscare>().ActivateJumpscare());
        }
    }
}
