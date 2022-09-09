using UnityEngine;
using UnityEngine.SceneManagement;
public class Level_changer : MonoBehaviour
{
    public Animator animatorr;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FadeIntoLevel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            FadetoLevel();
        }
        
    }

    public void FadetoLevel ()
    {
        animatorr.SetTrigger("FadeOUT");
        animatorr.SetTrigger("FadeIN");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeIntoLevel()
    {
        animatorr.SetTrigger("FadeOUT");
        animatorr.SetTrigger("FadeIN");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
