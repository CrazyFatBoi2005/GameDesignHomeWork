using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(EndGameColdown(sceneName));
    }

    private IEnumerator EndGameColdown(string sceneName)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}
