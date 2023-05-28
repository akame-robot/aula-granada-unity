using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private FlappyBird dead;
    public float velocity = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject scriptWithBool = GameObject.Find("Cube");
        dead = scriptWithBool.GetComponent<FlappyBird>();
        bool died = dead.isDead;

        transform.Translate(-velocity * Time.deltaTime, 0, 0);
        if (transform.position.x <= -30f)
        {
            Destroy(gameObject);
        }

        else if (died)
        {
            velocity = 0f;
        }
    }
}
