using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    [TextArea(3, 10)]
    //string for names and sentences
    public string[] sentences;
    public string[] names;

    //different expression sprites
    public Sprite[] sprites;


}
