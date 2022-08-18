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
        //Hvis brugeren ikke har r�rt ved volume, s� spiller musikken med fuld kraft.
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
        //Dramatisk g�r fra -60DB til -40DB, dog kan mennesket ikke h�rer under -40DB s� det g�r:)
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    //For at kunne finde vores slider
    [SerializeField] Slider volumeSlider;


    public void ChangeVolume()
    {
        //S�tter volume til valuen p� slideren og laver en save.
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        //S�tter den lig med hvad vi har gemt
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        //S�tter value fra slider ind i vores key name
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
