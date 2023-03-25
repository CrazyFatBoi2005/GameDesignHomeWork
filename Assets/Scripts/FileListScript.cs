using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileListScript : MonoBehaviour
{
    [SerializeField] public List<Sprite> Images = new List<Sprite>();
    [SerializeField] public List<string> TypeOfFile = new List<string>();
    [SerializeField] public List<string> Names = new List<string>();
}
