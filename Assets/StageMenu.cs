using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public TextMeshProUGUI stageTitle;
    public Image stageThumbnail;

    public StageList stageList;

    void Awake()
    {
        displayStage(PlayerPrefs.GetInt("SelectedStage"));
    }

    public void selectNextStage() {
        
    }

    public void selectPrevStage() {
        
    }

    // selects stage
    private void selectStage(int stage) {
        PlayerPrefs.SetInt("SelectedStage", stage);
    }

    // updates stage displayed on screen
    private void displayStage(int stage) {

        // set title text to the stage name
        stageTitle.text = stageList.stages[stage].name;

        // set thumbnail to the stage image
        // first have to convert from texture2d to sprite
        Texture2D thumbnailTexture = stageList.stages[stage].image;
        stageThumbnail.sprite = Sprite.Create(thumbnailTexture, new Rect(0, 0, thumbnailTexture.width, thumbnailTexture.height), Vector2.zero);
        
    }
}
