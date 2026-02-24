using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


//transformation order:  cherry, strawberry, grape, lemon, orange, apple, pear, banana, pineapple, watermelon



public class playerBehavior : MonoBehaviour
{

    public float speed;
    private GameObject currentFruit;
    public GameObject[] fruits;
    //[] for an array of multiple

    //public int[] numbers;

    public float offY = -0.8f;
    public int move;


    public int[] points;
    public int total;
    public TMP_Text textField;


    private AudioSource dropSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        dropSource = GetComponents<AudioSource>()[1];

        //   for (int i = 0; i < numbers.Length; i++)
        //   {
        //       print(numbers[i]);
        //   }  refernce

        move = 0; //you can move both ways


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
            print(GameObject.FindGameObjectWithTag("Queue"));
            int choice = GameObject.FindGameObjectWithTag("Queue").GetComponent<QueueManager>().updateQueue();

            //int choice = Random.Range(0, fruits.Length);
            currentFruit = Instantiate(fruits[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }


        //drop fruit here
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Rigidbody2D body = currentFruit.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = currentFruit.GetComponent<Collider2D>();
            collider.enabled = true;

            dropSource.Play();

            currentFruit = null;

        }



        //bool left = (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) && move





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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LB"))
        {
            move = 1; //cannot move left
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LB"))
        {
            move = 0; //CAN move left
        }
    }


    public void updateScore(int index) {

        total = total + points[index];
        textField.SetText("Score:" + total);

    }



}
