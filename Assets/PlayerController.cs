using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public GameObject[] prefabs;
    
    public float speed;
    public Vector3 jump;
    public Text countText;
    public Text winText;
    private bool restart = false;

    private Rigidbody rb;
    private int count;
    private GameObject playerPosition;

    void Start ()
    {
        playerPosition = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        count = 0;
        SetCountText ();
        winText.text = "";
    }
    
    void Update() {
      /*if (playerPosition.transform.position.y < 5 && playerPosition.transform.position.y < 1 && Input.GetButtonDown("Jump")) {
         print("space key was pressed");
         rb.AddForce(jump * 2.0f, ForceMode.Impulse);
      }*/
      if(playerPosition.transform.position.y < -10) {
           SetLoseText ();
      }
      if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name );
            }
       }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 5.0f, 0.0f);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag ( "crate" )) {
		  // trigger question from an rss feed
          Debug.Log("Collided2");
          QuestionController.showQuestion = true;
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
    
    void SetLoseText ()
    {
        
        winText.text = "You Lose! Press R to restart.";
        restart = true;
        
    }
    
}
