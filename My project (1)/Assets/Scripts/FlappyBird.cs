using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{

    public float jumpForce = 10f;
    public float gravityForce = 10f;
    public bool isPaused = false;
    public bool isDead = false;
    public bool canControll = true;

    private Rigidbody rb;
    private BoxCollider overtake;

    void Start()
    {
        canControll = true;
        rb = GetComponent<Rigidbody>();
        overtake = GetComponent<BoxCollider>();
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
        }
        if (canControll && !isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(0, jumpForce, 0);
            }
            rb.AddForce(new Vector3(0, -gravityForce, 0));
        }
        else if (isDead)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 12f);
            Debug.Log("entered here");
            canControll = false;
            transform.position = newPos;
        }

        CharacterDie();

    }

    void CharacterDie()
    {
        if (transform.position.y >= 6.48f || transform.position.y <= -6.48f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("colliding");
            isDead = true;
        }
    }
}
