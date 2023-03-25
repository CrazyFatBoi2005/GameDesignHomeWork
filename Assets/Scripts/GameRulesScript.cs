using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRulesScript : MonoBehaviour
{
    [HideInInspector] public int currentFiles = 0;
    
    private bool finish = false;

    [SerializeField] private int maxFiles;
    [SerializeField] private GameObject _mouseInputManager;
    [SerializeField] private GameObject _fileGenerator;
    [SerializeField] private GameObject _endGameImage;


    private void Start()
    {
        StartCoroutine(Coldown());
    }

    private IEnumerator Coldown()
    {
        yield return new WaitForSeconds(1f);
        if (!finish)
        {
            CheckFiles();
            StartCoroutine(Coldown());
        }
    }

    private void CheckFiles()
    {
        if (currentFiles > maxFiles)
        {
            _mouseInputManager.SetActive(false);
            _fileGenerator.SetActive(false);
            _endGameImage.SetActive(true);
            finish = true;
        }
    }
}
