using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SFXscript.sfxInstance.IniciodoJogo.PlayOneShot(SFXscript.sfxInstance.Click);

    }

    public void CreditsScreen()
    {
        SFXscript.sfxInstance.IniciodoJogo.PlayOneShot(SFXscript.sfxInstance.Click);
    }

    public void OptionsMenu()
    {
        SFXscript.sfxInstance.IniciodoJogo.PlayOneShot(SFXscript.sfxInstance.Click);
        Application.Quit();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        SFXscript.sfxInstance.IniciodoJogo.PlayOneShot(SFXscript.sfxInstance.Click);
    }

    public void TitleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
