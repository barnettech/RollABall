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
    public int i = 0;    
    
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
      if(distanceTravelled > Random.Range(10,20) * tileCount ) {
          tileCount++;
          for(int i = 0; i < Random.Range(0,8); i++) {
            Debug.Log("i is " + i);
            GameObject activePrefab = Instantiate(birdPrefabs[Random.Range(0, birdPrefabs.Length)], new Vector3(groundPosition.transform.position.x + (Random.Range(-4, 4)), groundPosition.transform.position.y - (Random.Range(20, 30) * tileCount), groundPosition.transform.position.z + 48 * tileCount), Quaternion.identity) as GameObject;
		    activePrefab.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
            Vector3 currentPlayerPosition = playerCurrent.transform.position;
            activePrefab.transform.LookAt(currentPlayerPosition);
            birdlist.Add(activePrefab);
            GameObject gameObjectToRemove1 = birdlist[1];
            if(birdlist.Count > 5 && gameObjectToRemove1.transform.position.z <     playerPosition.transform.position.z) {
              Debug.Log("DESTROYING THE BIRD OBJECT");
              GameObject gameObjectToRemove = birdlist[0];
              birdlist.Remove(gameObjectToRemove);
              Destroy(gameObjectToRemove);
            }
          }
      }
      GameObject[] argo = GameObject.FindGameObjectsWithTag("bird");
      foreach (GameObject go in argo) {
        //GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
        float dist = Vector3.Distance(go.transform.position, playerPosition.transform.position);
        //Debug.Log("Distance to other: " + dist);
        if(dist < 10) {
          if(go.transform.position.y < groundPosition.transform.position.y + 2) {
            go.transform.transform.Translate(Vector3.up * Random.Range(0.45f, 2) * Time.deltaTime);
          }
          GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
          Vector3 newPos = new Vector3(playerCurrent.transform.position.x, playerCurrent.transform.position.y, playerCurrent.transform.position.z - 1); 
          go.transform.position = Vector3.Lerp(go.transform.position, newPos, Random.Range(0.45f, 2) * Time.deltaTime);
        }
      }
    }
    
}
