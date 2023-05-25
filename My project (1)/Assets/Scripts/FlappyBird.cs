using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{

    public float jumpForce = 10f;
    public float gravityForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) 
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
        rb.AddForce(new Vector3(0, -gravityForce, 0));

        CharacterDie();

    }

    void CharacterDie()
    {
        if (transform.position.y >= 5.48f || transform.position.y <= -5.48f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
