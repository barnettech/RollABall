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
    public Text timerLabel;
    private float time;
    
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
      time += Time.deltaTime;
 
      var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
      var seconds = time % 60;//Use the euclidean division for the seconds.
      var fraction = (time * 100) % 100;
 
      //update the label value
      timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
      //Debug.Log("y is " + GroundSpawner.groundlist[GroundSpawner.groundlist.Count].transform.position.y);
      /*if(playerPosition.transform.position.y < GroundSpawner.groundlist[GroundSpawner.groundlist.Count].transform.position.y) {
           SetLoseText ();
      }*/
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
        
        if (other.gameObject.CompareTag ("bird"))
        {
            SetLoseText2();
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
    
    void SetLoseText2 ()
    {
        
        winText.text = "You Lose, the birds got to your bagel, ate some, and it's no longer usable! Press R to restart.";
        restart = true;
        
    }
    
}
