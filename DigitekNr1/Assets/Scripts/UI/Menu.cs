using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        //Hvis brugeren ikke har rørt ved volume, så spiller musikken med fuld kraft.
        //Ellers loader den deres settings.
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    #region OptionMenu
    public void SetVolume(float volume)
    {
        //Dramatisk går fra -60DB til -40DB, dog kan mennesket ikke hører under -40DB så det går:)
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    //For at kunne finde vores slider
    [SerializeField] Slider volumeSlider;


    public void ChangeVolume()
    {
        //Sætter volume til valuen på slideren og laver en save.
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        //Sætter den lig med hvad vi har gemt
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        //Sætter value fra slider ind i vores key name
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    #endregion

    #region MainMenu
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #endregion



}
