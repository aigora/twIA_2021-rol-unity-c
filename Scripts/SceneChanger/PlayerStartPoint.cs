using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private Movement Player;
    private CameraController theCamera;
    public Vector2 startDirection;
    public string pointName;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Movement>();
        if (Player.startPoint == pointName)
        {
            Player.transform.position = transform.position;
            Player.lastMove = startDirection;
            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
