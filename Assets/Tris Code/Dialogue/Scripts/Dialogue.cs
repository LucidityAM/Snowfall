﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    //bool for dog
    public bool dogTrigger = false;
    public bool sceneTransition;
    public int sceneIndex;
    [TextArea(3, 10)]
    //string for sentences
    public string[] sentences;

    //different expression sprites
    public Sprite[] sprites;
    public AudioClip[] voices;

}
