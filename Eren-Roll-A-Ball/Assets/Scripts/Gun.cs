using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody bullet;
    [SerializeField] float projSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            // Instantiate the bullet at the gun's position and rotation
            //Transform parentTransform = transform.parent.parent;
            Rigidbody projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.transform.Rotate(90.0f,0,0);
            
            //projectile.transform.SetParent(GameObject.Find("GunPoint").transform);
            // Get the forward direction of the parent object (gun)
            Vector3 shootDirection = transform.forward;

            // Set the velocity of the projectile based on the shoot direction and projSpeed
            projectile.velocity = shootDirection * projSpeed;
        }    
    }
}
