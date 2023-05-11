using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuCan;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenuCan.SetActive(true);
            FindObjectOfType<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuCan.SetActive(false);
        FindObjectOfType<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
