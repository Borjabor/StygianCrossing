using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused;

    [SerializeField]
    private GameObject _pausePanel;

    [SerializeField]
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _pausePanel.SetActive(false);
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            { 
                PauseGame();  
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        
        _isPaused = true;
        //_audioSource.Pause();
        _pausePanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (_isPaused)
        {
            _isPaused = false;
            //_audioSource.Play();
            _pausePanel.SetActive(false);

            Time.timeScale = 1;

        }
        
    }

    public void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }

    public void RestartLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}