using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Granade : MonoBehaviour
{

    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public int delayExplode;

    public GameObject explodePrefab;

    private bool collided = false;

    private void FixedUpdate()
    {
        if (collided)
        {
            Invoke("Explode", delayExplode);
            Destroy(gameObject, 3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            collided = true;
        }
    }

    void Explode()
    {
        Instantiate(explodePrefab, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider colliderd in colliders)
        {
            Rigidbody target = colliderd.GetComponent<Rigidbody>();

            if (target != null)
            {
                Vector3 directtion = (colliderd.transform.position - transform.position).normalized;
                target.AddForce(directtion * explosionForce, ForceMode.Impulse);
            } 
        }
    }
}
