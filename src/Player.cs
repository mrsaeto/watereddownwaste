using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
    public static Player singleton = null;

    // movement
    public float moveSpeed = 0.0f;
    private Rigidbody2D body = null;
    private Vector2 moveVector = Vector2.zero;

    public GameObject harpoon;
    private bool shooted = false;

    public GameObject foot;

    public GameObject gameStats;
    public GameObject HarpoonsUI;

    public int health = 0;
    public Text Hitpointstext;

    private bool hit = false;
    private float hitflashMaxTime = 0.25f;
    private float hitflashTargetTime = 0.0f;

    void Awake()
    {
        if (Player.singleton == null) {
            Player.singleton = this;
        }
    }

    void Start()
    {
        if (body == null) {
            body = GetComponent<Rigidbody2D>();
            gameStats.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !shooted) {
            shooted = true;
            GameObject h = Instantiate(harpoon, transform.position, Quaternion.identity);
            h.transform.localScale = new Vector3(transform.localScale.x, 1.0f, 1.0f);
        }

        if (health <= 0) {
            AudioManager.singleton.Play("PlayerDeath");
            SceneManager.LoadScene(4);
            gameStats.SetActive(false);

        }

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        Util.FlipScaleForMovement(gameObject, moveVector, false);
        Hitpointstext.text = "Health:" + health.ToString();

        if (hit) {
            Manager.singleton.ActivateItem("HitFlash");

            hitflashTargetTime -= Time.deltaTime;
            if (hitflashTargetTime <= 0.0f) {
                hit = false;
                Manager.singleton.DisableItem("HitFlash");
                hitflashTargetTime = hitflashMaxTime;
            }
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + moveVector * moveSpeed * Time.fixedDeltaTime);

        if(shooted == true){
            HarpoonsUI.SetActive(false);
        }else if(shooted == false){
            HarpoonsUI.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "JellyFish") {
            hit = true;
            health--;
            AudioManager.singleton.Play("Lightning");
        } else if (other.gameObject.tag == "Harpoon") {
            Destroy(other.gameObject);
            shooted = false;
        }
    }

}