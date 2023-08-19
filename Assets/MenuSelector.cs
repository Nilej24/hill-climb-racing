using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelector : MonoBehaviour
{
    private  GameObject currentMenu;
    public GameObject stageMenuPrefab, carMenuPrefab;
    public Transform bottomBarTransform;
    public GameObject stageButton, carButton;

    // Start is called before the first frame update
    void Start()
    {
        SelectStageMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStageMenu() {

        Destroy(currentMenu);
        currentMenu = Instantiate(stageMenuPrefab, this.transform);
        ShowSelection(0);

    }

    public void SelectCarMenu() {

        Destroy(currentMenu);
        currentMenu = Instantiate(carMenuPrefab, this.transform);
        ShowSelection(1);

    }

    // moves buttons to show which menu is selected
    private void ShowSelection(int menu) {

        switch (menu) {

            // stage menu
			case 0:
                stageButton.transform.position = bottomBarTransform.position + (Vector3.left * 140) + (Vector3.up * 10);
                carButton.transform.position = bottomBarTransform.position;
                break;

            // car menu
            case 1:
                stageButton.transform.position = bottomBarTransform.position + (Vector3.left * 140);
                carButton.transform.position = bottomBarTransform.position + (Vector3.up * 10);
                break;
                

        }

    }
}
