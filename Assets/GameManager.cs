using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CarPrefabs carPrefabs; 
    public CinemachineVirtualCamera vcam;
    public CameraLookAhead cameraScript;

    private GameObject carPrefab;
    public GameObject playerCar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SelectedCar", 0);

        // get player's selected car
        int carIndex = PlayerPrefs.GetInt("SelectedCar");
        carPrefab = carPrefabs.cars[carIndex];

        // spawn the car
        playerCar = Instantiate(carPrefab, Vector3.zero, Quaternion.identity);

        // give the car to the camera
        vcam.m_Follow = playerCar.transform;
        cameraScript.car = playerCar.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
