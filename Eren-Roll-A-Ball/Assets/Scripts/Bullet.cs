using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int airtime = 4; // This is in seconds

    void Awake()
    {
        StartCoroutine(lifespan());
    }

    IEnumerator lifespan()
    {
        yield return new WaitForSeconds(airtime);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().DecreaseHealth();
            Destroy(gameObject);
        }
    }
}
