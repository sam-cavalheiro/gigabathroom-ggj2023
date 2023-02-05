using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXscript : MonoBehaviour
{
    public AudioSource IniciodoJogo;

    public AudioClip Click;

    public static SFXscript sfxInstance;
    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
