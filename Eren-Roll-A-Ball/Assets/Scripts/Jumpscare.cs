using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscare;
    public float audioDelay = 2.0f;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        jumpscare.SetActive(false);
    }

    public IEnumerator ActivateJumpscare()
    {
        music.Play();
        yield return new WaitForSeconds(audioDelay);
        jumpscare.SetActive(true);
        yield return new WaitForSeconds(2);
        music.Stop();
        if (SceneManager.GetActiveScene().name == "EasterEgg")
        {
            yield return new WaitForSeconds(2);
            Application.Quit();
        }
        if (SceneManager.GetActiveScene().name == "Minigame")
        {
            SceneManager.LoadSceneAsync("EasterEgg");
        }
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivateJumpscare());
        }
    }
}
