using UnityEngine;
using Random = UnityEngine.Random;

public class FileScript : BaseFile
{
    [SerializeField] private string _listName;
    [SerializeField] private string _gameRulesName;
    private GameRulesScript _gameRules;
    private FileListScript _fileListScript;
    
    
    private void OnEnable()
    {
        _fileListScript = GameObject.Find(_listName).GetComponent<FileListScript>();
        _gameRules = GameObject.Find(_gameRulesName).GetComponent<GameRulesScript>();
        var randomValue = Random.Range(0, _fileListScript.TypeOfFile.Count);
        fileType = _fileListScript.TypeOfFile[randomValue];
        spriteOfFile.sprite = _fileListScript.Images[randomValue];
        _gameRules.currentFiles += 1;
        nameOfFile.text = _fileListScript.Names[Random.Range(0, _fileListScript.Names.Count)];
    }

    private void OnDestroy()
    {
        _gameRules.currentFiles -= 1;
    }
}
