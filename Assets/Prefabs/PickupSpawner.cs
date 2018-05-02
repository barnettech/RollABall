using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {

	public GameObject[] prefabs;
    public float spawnDistance;
    private GameObject playerLastPosition;
    private GameObject playerPosition;
    private GameObject groundPosition;
    private GameObject activePrefab;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    int tileCount = 0;
    public List<GameObject> pickuplist;
    
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
          for (int i = 0; i < 10; i++) {
            GameObject activePrefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(groundPosition.transform.position.x + (Random.Range(-4, 4)), groundPosition.transform.position.y - (30 * tileCount), groundPosition.transform.position.z + Random.Range(40,64) * tileCount), Quaternion.identity) as GameObject;
            activePrefab.transform.rotation = groundPosition.transform.rotation;
            pickuplist.Add(activePrefab);
          }
          GameObject gameObjectToRemove1 = pickuplist[1];
          if(pickuplist.Count > 20 && gameObjectToRemove1.transform.position.z < playerPosition.transform.position.z) {
            GameObject gameObjectToRemove = pickuplist[0];
            pickuplist.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
          }
      }
      }
    
}