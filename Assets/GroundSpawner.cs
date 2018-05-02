using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

	public GameObject[] prefabs;
    public float spawnDistance;
    public float groundSpeed;
    private int randomrotate;
    private GameObject playerLastPosition;
    private GameObject playerPosition;
    private GameObject groundPosition;
    private GameObject activePrefab;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    int tileCount = 0;
    public static List<GameObject> groundlist;
    Vector3 oldEulerAngles;
    private int multiplier;
    
	// Use this for initialization
	void Start () {

		// infinite coin spawning function, asynchronous
		//StartCoroutine(SpawnGround());
        playerPosition = GameObject.Find("Player");
        groundPosition = GameObject.Find("Ground1");
        lastPosition = playerPosition.transform.position;
        randomrotate = 1;
	}

	// Update is called once per frame
	void Update () {
      distanceTravelled += Vector3.Distance(playerPosition.transform.position, lastPosition);
      lastPosition = playerPosition.transform.position;
      // Debug.Log("tileCount is " + tileCount + " and distanceTravelled is " + distanceTravelled);
      if(distanceTravelled > 2 * tileCount ) {
          tileCount++;
          GameObject activePrefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(groundPosition.transform.position.x, lastPosition.y - (30 * tileCount), groundPosition.transform.position.z + 48 * tileCount), Quaternion.AngleAxis(-45, Vector3.up)) as GameObject;
          //activePrefab.transform.rotation = groundPosition.transform.rotation;
          //activePrefab.transform.Rotate(50, 0, 0);
          groundlist.Add(activePrefab);
          GameObject gameObjectToRemove1 = groundlist[1];
          if(groundlist.Count > 20 && gameObjectToRemove1.transform.position.z < playerPosition.transform.position.z) {
            GameObject gameObjectToRemove = groundlist[0];
            groundlist.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
          }
      }
        GameObject[] tagged = GameObject.FindGameObjectsWithTag("Ground");
               foreach (GameObject obj in tagged) {
                 if (oldEulerAngles == obj.transform.rotation.eulerAngles){
                   if(randomrotate == 1) {
                     multiplier = 1;
                   } else {
                     multiplier = -1;
                   }
                 }
                 
                 Vector3 direction = new Vector3(25, 34 * multiplier, 0);
                 Quaternion targetRotation = Quaternion.Euler(direction); 
                 obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, targetRotation, Time.deltaTime * .74f);
                 oldEulerAngles = obj.transform.rotation.eulerAngles;
               }
      }
    
}