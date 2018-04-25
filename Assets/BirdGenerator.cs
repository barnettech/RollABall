using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour {
    
    public GameObject[] birdPrefabs;
    private GameObject playerLastPosition;
    private GameObject playerPosition;
    private GameObject groundPosition;
    private GameObject activePrefab;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    int tileCount = 0;
    public List<GameObject> birdlist;
    private bool goup = true;
    private bool goright = true;
    private int movementSpeed = 10;
    private float movementSpeedBirds = 0.45f;
    
	// Use this for initialization
	void Start () {

		// infinite coin spawning function, asynchronous
		//StartCoroutine(SpawnGround());
        playerPosition = GameObject.Find("Player");
        groundPosition = GameObject.Find("Ground1");
        lastPosition = playerPosition.transform.position;
	}

	// Update is called once per frame
	void Update () {
      distanceTravelled += Vector3.Distance(playerPosition.transform.position, lastPosition);
      lastPosition = playerPosition.transform.position;
      // Debug.Log("tileCount is " + tileCount + " and distanceTravelled is " + distanceTravelled);
      if(distanceTravelled > 10 * tileCount ) {
          tileCount++;
          GameObject activePrefab = Instantiate(birdPrefabs[Random.Range(0, birdPrefabs.Length)], new Vector3(groundPosition.transform.position.x, groundPosition.transform.position.y + 2, groundPosition.transform.position.z + 48 * tileCount), Quaternion.identity) as GameObject;
		  activePrefab.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
          GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
          Vector3 currentPlayerPosition = playerCurrent.transform.position;
          activePrefab.transform.LookAt(currentPlayerPosition);
          birdlist.Add(activePrefab);
          GameObject gameObjectToRemove1 = birdlist[1];
          if(birdlist.Count > 5 && gameObjectToRemove1.transform.position.z < playerPosition.transform.position.z) {
            Debug.Log("DESTROYING THE BIRD OBJECT");
            GameObject gameObjectToRemove = birdlist[0];
            birdlist.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
          }
      }
      GameObject[] argo = GameObject.FindGameObjectsWithTag("bird");
      foreach (GameObject go in argo) {
        if(go.transform.position.y < groundPosition.transform.position.y + 2) {
          go.transform.transform.Translate(Vector3.up * movementSpeedBirds * Time.deltaTime);
        }
        GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
        Vector3 newPos = new Vector3(playerCurrent.transform.position.x, playerCurrent.transform.position.y, playerCurrent.transform.position.z - 20); 
        go.transform.position = Vector3.Lerp(go.transform.position, newPos, movementSpeedBirds * Time.deltaTime);
        /*GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
        Vector3 currentPlayerPosition = playerCurrent.transform.position;
        GameObject birdDestinationPosition = playerCurrent;
        Vector3 newPos = new Vector3(playerCurrent.transform.position.x, playerCurrent.transform.position.y, playerCurrent.transform.position.z - 20); 
        birdDestinationPosition.transform.position = newPos;*/
        //go.transform.position = Vector3.Lerp(go.transform.position, birdDestinationPosition.transform.position, movementSpeedBirds * Time.deltaTime);
    
        /*if(go.transform.position.y < 5 && goup) {
          go.transform.transform.Translate(Vector3.up * movementSpeedBirds * Time.deltaTime);
          goup=true;
        } else {
          goup=false;
          go.transform.transform.Translate(Vector3.down * movementSpeedBirds * Time.deltaTime);
          if(go.transform.position.y < groundPosition.transform.position.y + 1) {
            goup=true;
          }     
        }*/
      }
    }
    
}
