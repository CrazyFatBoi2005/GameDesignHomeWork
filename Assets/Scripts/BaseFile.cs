using TMPro;
using UnityEngine;

public class BaseFile : MonoBehaviour
{
    public TMP_Text nameOfFile;
    public SpriteRenderer spriteOfFile;
    public string fileType;
    
    public struct FileType
    {
        public const string Folder = "folder";
        public const string Text = "text";
        public const string Media = "media";
        public const string Exe = "exe";

    }
}
