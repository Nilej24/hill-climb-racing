using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAhead : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Rigidbody2D car;
    public float expectedCarMaxSpeed = 25;
    public float stillSize = 5, maxSpeedSize = 8;
    public float zoomSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // calculate camera size (zoom) based on car speed
        float targetSize = stillSize + (maxSpeedSize - stillSize) * (car.velocity.magnitude / expectedCarMaxSpeed);

        // update cam size based on zoom speed and framerate
        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, targetSize, Time.deltaTime * zoomSpeed);
    }
}
