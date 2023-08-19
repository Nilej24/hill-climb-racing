using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public StageList stageList;

    public void LoadGame() {
        
        int stageNum = PlayerPrefs.GetInt("SelectedStage");
        SceneManager.LoadScene(stageList.stages[stageNum].sceneName);

    }
}
