using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

	public GameObject[] prefabs;
    public float spawnDistance;
    private int randomrotate;
    private GameObject playerLastPosition;
    private GameObject playerPosition;
    private GameObject groundPosition;
    private GameObject activePrefab;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    int tileCount = 0;
    public List<GameObject> groundlist;
    
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
          GameObject activePrefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(groundPosition.transform.position.x, groundPosition.transform.position.y, groundPosition.transform.position.z + 48 * tileCount), Quaternion.identity) as GameObject;
          activePrefab.transform.rotation = groundPosition.transform.rotation;
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
                 // rotates the planes
                 //randomrotate = Random.Range(1,3);
                 randomrotate = 1;
                 if(randomrotate == 1) {
                   Debug.Log("positive");
                   obj.transform.Rotate(Vector3.up * Time.deltaTime * .75f);
                 } else if(randomrotate == 2) {
                     Debug.Log("negative");
                     obj.transform.Rotate(Vector3.up * Time.deltaTime * -.75f);
                 }
                 //obj.transform.Rotate (new Vector3 (0, 0, 20) * Time.deltaTime);
               }
      }
    
      IEnumerator rotateRandom() {
         // execute block of code here
            GameObject[] tagged = GameObject.FindGameObjectsWithTag("Ground");
               foreach (GameObject obj in tagged) {
                 // rotates the planes
                 randomrotate = Random.Range(1,3);
                 if(randomrotate == 1) {
                   Debug.Log("positive");
                   obj.transform.Rotate(Vector3.up * Time.deltaTime * .75f);
                 } else if(randomrotate == 2) {
                     Debug.Log("negative");
                     obj.transform.Rotate(Vector3.up * Time.deltaTime * -.75f);
                 }
                 //obj.transform.Rotate (new Vector3 (0, 0, 20) * Time.deltaTime);
               }
         yield return new WaitForSeconds(10.0f);
  }
    
}