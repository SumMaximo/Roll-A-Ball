using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private GameObject PlayerLevelOne;
    private GameObject PlayerLevelTwo;
   // public GameObject LevelOne;
    //public GameObject LevelTwo;
    

    private Vector3 offset;
    
   
	// Use this for initialization
	void Start () {

        //LevelOne = GameObject.FindGameObjectWithTag("Level 1");
        //player = PlayerLevelTwo;
        offset = transform.position - player.transform.position;
        

    }


    // Update is called once per frame
    void LateUpdate () {
      
            transform.position = player.transform.position + offset;
    }
}
