using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start ()
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate ()
    {
        //transform.position = player.transform.position + offset;
        
        
        GameObject playerCurrent = GameObject.FindGameObjectWithTag ("Player");
             Vector3 currentPlayerPosition = playerCurrent.transform.position;
             transform.position = new Vector3 (currentPlayerPosition.x, currentPlayerPosition.y + 4.2f, currentPlayerPosition.z - 3.0f);
             Vector3 lookAtPos = currentPlayerPosition;
             lookAtPos.y = lookAtPos.y + 1.0f;
             transform.LookAt (lookAtPos);
    }
}
