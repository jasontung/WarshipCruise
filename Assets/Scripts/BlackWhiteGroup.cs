﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWhiteGroup : MonoBehaviour {

    public GameObject root;
    public void Show()
    {
        root.SetActive(true);
    }

    public void Hide()
    {
        root.SetActive(false);
    }
}
