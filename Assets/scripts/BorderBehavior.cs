using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    public float timeout;
    private float timeStart;
    public GameObject gameOver;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            timeStart = Time.time;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;
            if (timeThusFar > timeout)
            {

                gameOver.SetActive(true);
                print(message: "game over");
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            timeStart = 0.0f;
        }

    }


}
