using System;
using UnityEngine;

public class FruitBehaviort : MonoBehaviour
{
    public float timeout;
    private float timeStart;

    public GameObject[] fruits;
    public int fruitType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        fruits = GameObject.FindGameObjectWithTag("Player").GetComponent<playerBehavior>().fruits;
        //transformation order:  cherry, strawberry, grape, lemon, orange, apple, pear, banana, pineapple, watermelon

      //  total = 0;

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            int otherType = other.gameObject.GetComponent<FruitBehaviort>().fruitType;
            if (otherType == fruitType && fruitType < fruits.Length - 1)
            {

                if (gameObject.transform.position.y > other.transform.position.y
                    || (gameObject.transform.position.y == other.transform.position.y
                    && gameObject.transform.position.x >= other.transform.position.x))
                {

                    int choice = fruitType + 1;
                    GameObject currentFruit = Instantiate(fruits[choice],
                        Vector3.Lerp(gameObject.transform.position,other.gameObject.transform.position, 0.5f),Quaternion.identity);
                    currentFruit.GetComponent<Collider2D>().enabled = true;
                    currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

                    GameObject.FindGameObjectWithTag("Player").GetComponent<playerBehavior>().updateScore(fruitType);

                    //destroy both fruits
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            }

        
                //destroy both fruits and create new fruit


    
        }
    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            timeStart = Time.time;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;
            if (timeThusFar > timeout)
            {
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
