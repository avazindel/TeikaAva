using UnityEngine;

public class backgroundManager : MonoBehaviour
{

    public GameObject bckPrefab;
    public float speed;
    private GameObject[] bcks;
    public float pivotPoint;
    public float scale;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pivotPoint = scale * 16 * -0.32f;
     //   bckPrefab.transform.localScale.x (scale, scale, scale);


        bcks = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            float xpos = pivotPoint - (pivotPoint / 2 * i);
            float ypos = pivotPoint - (pivotPoint / 2 * i);
            Vector2 position = new Vector2(0.0f, 0.0f);
            bcks[i] = Instantiate(bckPrefab, position, Quaternion.identity);

        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++) {
            float xpos = bcks[i].transform.position.x + speed;
            float ypos = bcks[i].transform.position.y + speed;
            Vector2 position = new Vector2(0.0f, 0.0f);
           
            if (bcks[i].transform.position.x > -pivotPoint/2)
            {

                position = new Vector2(pivotPoint, pivotPoint);

            }

            bcks[i].transform.position = position;

        }
    }
}