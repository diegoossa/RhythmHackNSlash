using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitController : MonoBehaviour {

    public int bpm=0;
    public char movement1, movement2, movement3;

    [HideInInspector]
    public static BitController instance;
    [HideInInspector]
    public char[] songbpm;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        songbpm = new char[bpm];
    }


}
