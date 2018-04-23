using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Xml;

public class CrateSpawner : MonoBehaviour {

    XmlTextReader rssReader;
    XmlDocument rssDoc;
    XmlNode nodeRss;
    XmlNode nodeChannel;
    XmlNode nodeItem;
    public string title;
    public string description;
    
	public GameObject[] prefabs;
    public float spawnDistance;
    private GameObject playerLastPosition;
    private GameObject playerPosition;
    private GameObject groundPosition;
    private GameObject activePrefab;
    float distanceTravelled = 0;
    Vector3 lastPosition;
    int tileCount = 0;
    public List<GameObject> cratelist;
    private bool goright = true;
    private int movementSpeed = 10;
    
	// Use this for initialization
	void Start () {

		// infinite coin spawning function, asynchronous
		//StartCoroutine(SpawnGround());
        playerPosition = GameObject.Find("Player");
        groundPosition = GameObject.Find("Ground1");
        lastPosition = playerPosition.transform.position;
        
        Rssreader rss = new Rssreader("http://www.barnettech.com/rss.xml");
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
          cratelist.Add(activePrefab);
          GameObject gameObjectToRemove1 = cratelist[1];
          if(cratelist.Count > 20 && gameObjectToRemove1.transform.position.z < playerPosition.transform.position.z) {
            GameObject gameObjectToRemove = cratelist[0];
            cratelist.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
          }
      }
      GameObject[] argo = GameObject.FindGameObjectsWithTag("crate");
      foreach (GameObject go in argo) {
        if(go.transform.position.x < 20 && goright) {
          go.transform.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
          goright=true;
        } else {
          goright=false;
          go.transform.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
          if(go.transform.position.x < -5) {
            goright=true;
          }     
        }
      }
    }
    
    void OnTriggerEnter(Collider other) {

		// trigger question from an rss feed
		
	}
    
}