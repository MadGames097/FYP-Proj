using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseBtn;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
    }
    public void PauseButton()
    {
        PauseBtn.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        PauseBtn.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


}
