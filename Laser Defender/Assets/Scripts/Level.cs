using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    // Start is called before the first frame update
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMainGame()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Screen");
    }
}
