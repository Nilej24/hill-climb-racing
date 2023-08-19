using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarMenu : MonoBehaviour
{
    public TextMeshProUGUI carTitle;
    public Image carThumbnail;

    public CarList carList;

    void Awake()
    {
        displayCar(PlayerPrefs.GetInt("SelectedCar"));
    }

    // used by button
    public void selectNextCar() {

        int carNum = PlayerPrefs.GetInt("SelectedCar") + 1;

        if (carNum >= carList.cars.Length)
            carNum = 0;

        selectCar(carNum);
        displayCar(carNum);

    }

    // used by button
    public void selectPrevCar() {

        int carNum = PlayerPrefs.GetInt("SelectedCar") - 1;

        if (carNum < 0)
            carNum = carList.cars.Length - 1;

        selectCar(carNum);
        displayCar(carNum);
        
    }

    // selects car
    private void selectCar(int car) {
        PlayerPrefs.SetInt("SelectedCar", car);
    }

    // updates car displayed on screen
    private void displayCar(int car) {

        // set title text to the car name
        carTitle.text = carList.cars[car].name;

        // set thumbnail to the car image
        // first have to convert from texture2d to sprite
        Texture2D thumbnailTexture = carList.cars[car].image;
        carThumbnail.sprite = Sprite.Create(thumbnailTexture, new Rect(0, 0, thumbnailTexture.width, thumbnailTexture.height), Vector2.zero);
        
    }
}
