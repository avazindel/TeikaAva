using UnityEngine;
using UnityEngine.InputSystem;


//transformation order:  cherry, strawberry, grape, lemon, orange, apple, pear, banana, pineapple, watermelon



public class playerBehavior : MonoBehaviour
{

    public float speed;
    private GameObject currentFruit;
    public GameObject[] fruits;
    //[] for an array of multiple

    //public int[] numbers;

    public float offY = -0.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

     //   for (int i = 0; i < numbers.Length; i++)
     //   {
     //       print(numbers[i]);
     //   }  refernce


    }

    // Update is called once per frame
    void Update()
    {

       // int choice = Random.Range(1, 100);
        // print(choice);


       


        if (currentFruit != null)
        {
            Vector3 playerPos = transform.position;
            Vector3 fruitOffset = new Vector3(0.0f, offY, 0.0f);
            currentFruit.transform.position = playerPos + fruitOffset;
        }
        else
        {
            int choice = Random.Range(0, fruits.Length);
            currentFruit = Instantiate(fruits[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }



        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Rigidbody2D body = currentFruit.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = currentFruit.GetComponent<Collider2D>();
            collider.enabled = true;

            currentFruit = null;

        }



        if (Keyboard.current.leftArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        }


        //interaction with the 2D collider = currentFruit... if (collider w sameCurrentFruit- return GetComponent<nextFruit>
        //make a list? retrieve list

    }

}
