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
      Debug.Log("distanceTravelled is " + distanceTravelled);
      if(distanceTravelled > .5 && flag == false) {
          GameObject clone;
          clone = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(groundPosition.transform.position.x, groundPosition.transform.position.y, groundPosition.transform.position.z + 48), Quaternion.identity);
          clone.transform.rotation = groundPosition.transform.rotation;
          flag = true;
      }
        
      
    }

}