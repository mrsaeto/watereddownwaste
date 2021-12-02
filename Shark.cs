using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shark : MonoBehaviour
{
    // movement
    private float moveSpeed;
    private Rigidbody2D body = null;
    private Vector2 moveVector = Vector2.zero;

    // dependencies
    private Player player = null;
    private Manager manager = null;

    // attack timer
    public float attackMaxTime = 0.0f;
    private float attackTargetTime = 0.0f;
    private bool hasAttacked = false;

    public int health = 0;

    void Start()
    {
        moveSpeed = Random.Range(2.0f, 4.0f);

        player = Player.singleton;
        manager = Manager.singleton;

        if (body == null) {
            body = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (health <= 0) {
            AudioManager.singleton.Play("SharkDeath");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        moveVector = Util.VectorTo(player.foot, gameObject);

        if (moveVector.magnitude <= 0.75) {
            attackTargetTime -= Time.fixedDeltaTime;
            
            if (attackTargetTime <= 0.0f && !hasAttacked) {
                hasAttacked = true;
                manager.ActivateItem("HitFlash");
                player.health--;
                AudioManager.singleton.Play("sharkChomp");
            
            } else if (attackTargetTime <= -0.25f) {
                hasAttacked = false;
                manager.DisableItem("HitFlash");
                attackTargetTime = attackMaxTime;
            }
            
        } else {
            Util.FlipScaleForMovement(gameObject, moveVector, true);
        }

        body.MovePosition(body.position + moveVector.normalized * moveSpeed * Time.fixedDeltaTime); 
    }
}