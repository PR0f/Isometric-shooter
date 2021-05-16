using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraPlayerDifference;
    private GameObject player;
    private GameObject aimingView;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraPlayerDifference = transform.position - player.transform.position;
        aimingView = GameObject.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraPlayerDifference;
        aimingView.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
