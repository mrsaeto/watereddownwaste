using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    private Rigidbody2D body;

    private bool acted = false;

    public GameObject harpoonPickup;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!acted) {
            acted = true;
            body.AddForce(new Vector2(transform.localScale.x, 0.0f) * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shark") {
            Shark s = other.gameObject.GetComponent<Shark>();
            s.health--;

            AudioManager.singleton.Play("SharkHit");
            GameObject harp = Instantiate(harpoonPickup, transform.position, Quaternion.identity);
            harp.transform.localScale = new Vector3(transform.localScale.x, 1.0f, 1.0f);

            Destroy(gameObject);
        } else if (other.gameObject.tag == "Bounds") {
            GameObject harp = Instantiate(harpoonPickup, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            harp.transform.localScale = new Vector3(transform.localScale.x, 1.0f, 1.0f);
            
            Destroy(gameObject);
        }
    }
}
