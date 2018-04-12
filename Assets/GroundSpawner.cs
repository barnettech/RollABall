using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

	public GameObject[] prefabs;
    public float spawnDistance;
    private GameObject playerLastPosition;
    private GameObject playerPosition;
    private GameObject groundPosition;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    private bool flag = false;
    int tileCount = 0;
    
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
      if(distanceTravelled > 20 * tileCount ) {
          tileCount++;
          GameObject clone;
          
          clone = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(groundPosition.transform.position.x, groundPosition.transform.position.y, groundPosition.transform.position.z + 48 * tileCount), Quaternion.identity);
          clone.transform.rotation = groundPosition.transform.rotation;
          // flag = true;
      }
        
      GameObject[] argo = GameObject.FindGameObjectsWithTag("Ground");
 foreach (GameObject go in argo) {
   //Debug.Log("tagged position is " + go.transform.position.z);
   //Debug.Log("player position is " + playerPosition.transform.position.z);
   /*if(go.transform.position.z < playerPosition.transform.position.z + 5) {
     Debug.Log("in here");
     Destroy(go);
   }*/
   // Debug.Log(go.name);
 }
        
        
    }

}