using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject victoryScreen;
    private int sec = 0;
    private int min = 0;
    public TMP_Text endTimeValue;
    public int errorCounter = -1;
    public TMP_Text errorCountValue;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EnableControls()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponentInChildren<PlayerLook>().enabled = true;
    }

    public void StartTimer()
    {
        StartCoroutine(ITimer());
    }

    IEnumerator ITimer()
    {
        while(true)
        {
            if(sec == 59)
            {
                min++;
                sec = -1;
            }
            sec++;
            endTimeValue.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        } 
    }

    public void Victory()
    {
        StopAllCoroutines();
        errorCountValue.text = errorCounter.ToString();
        victoryScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<PlayerMove>().enabled = false;
        player.GetComponentInChildren<PlayerLook>().enabled = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            StopAllCoroutines();
        }
    }
}
