using UnityEngine;
using UnityEngine.InputSystem;

public class playerBehavior : MonoBehaviour
{

    public float speed;
    public GameObject fruit;
    private GameObject currentFruit;

    public float offY = -0.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

        if (currentFruit != null)
        {
            Vector3 playerPos = transform.position;
            Vector3 fruitOffset = new Vector3(0.0f, offY, 0.0f);
            currentFruit.transform.position = playerPos + fruitOffset;
        }
        else
        {
            currentFruit = Instantiate(fruit, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
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





    }

}
