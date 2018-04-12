using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {

	public GameObject[] prefabs;
    private GameObject groundPosition;
    private GameObject playerPosition;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    int tileCount = 0;

	// Use this for initialization
	void Start () {
        groundPosition = GameObject.Find("Ground1");
        playerPosition = GameObject.Find("Player");
        lastPosition = playerPosition.transform.position;
		// infinite coin spawning function, asynchronous
		//StartCoroutine(SpawnGems());
	}

	// Update is called once per frame
	void Update () {
      distanceTravelled += Vector3.Distance(playerPosition.transform.position, lastPosition);
      lastPosition = playerPosition.transform.position;
      // Debug.Log("tileCount is " + tileCount + " and distanceTravelled is " + distanceTravelled);
      if(distanceTravelled > 20 * tileCount ) {
          tileCount++;
          int gemsThisRow = Random.Range(1, 4);
          for (int i = 0; i < gemsThisRow; i++) {
				/*Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(26, Random.Range(-10, 10), 10), Quaternion.identity);*/
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(groundPosition.transform.position.x, groundPosition.transform.position.y, groundPosition.transform.position.z + 40 * tileCount), Quaternion.identity);
              
			}
      }
	}

	/*IEnumerator SpawnGems() {
		while (true) {

			// number of coins we could spawn vertically
			int gemsThisRow = Random.Range(1, 4);

			// instantiate all coins in this row separated by some random amount of space
			for (int i = 0; i < gemsThisRow; i++) {
				Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(26, Random.Range(-10, 10), 10), Quaternion.identity);
			}
            
            Vector3(groundPosition.transform.position.x, groundPosition.transform.position.y, groundPosition.transform.position.z + 48 * tileCount), Quaternion.identity);

			// pause 1-20 seconds until the next coin spawns
			yield return new WaitForSeconds(Random.Range(1, 20));
		}*/
	
}