using System;
using UnityEngine;

public class FolderScript : BaseFile
{
    [SerializeField] private Sprite _folderSprite;
    [SerializeField] private string _sortFileType;
    [SerializeField] private ScoreRecorder _scoreRecorder;

    void Start()
    {
        spriteOfFile = gameObject.GetComponent<SpriteRenderer>();
        spriteOfFile.sprite = _folderSprite;
        fileType = FileType.Folder;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        FileScript fileTriggered;
        other.gameObject.TryGetComponent<FileScript>(out fileTriggered);
        if (fileTriggered)
        {
            if (fileTriggered.fileType == _sortFileType)
            {
                Destroy(fileTriggered.gameObject);
                _scoreRecorder.AddScore(true);
            }
            else
            {
                Destroy(fileTriggered.gameObject);
                _scoreRecorder.AddScore(false);
            }
        }
    }
}
