using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CarList carList; 
    public CinemachineVirtualCamera vcam;
    public CameraLookAhead cameraScript;

    private GameObject carPrefab;
    public GameObject playerCar;

    public TextMeshProUGUI timeTextbox;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        // get player's selected car
        int carIndex = PlayerPrefs.GetInt("SelectedCar");
        carPrefab = carList.cars[carIndex].prefab;

        // spawn the car
        playerCar = Instantiate(carPrefab, Vector3.zero, Quaternion.identity);

        // give the car to the camera
        vcam.m_Follow = playerCar.transform;
        cameraScript.car = playerCar.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        UpdateTimeText();

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MenuScreen");
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateTimeText() {
        
        timeTextbox.text = time.ToString("0.00");

    }
}
