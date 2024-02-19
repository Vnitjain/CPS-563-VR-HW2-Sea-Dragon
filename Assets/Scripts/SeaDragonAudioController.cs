using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaDragonAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SeaDragonMain.isFire1Pressed)
        {
            AudioSource[] audioSourceList = gameObject.GetComponents<AudioSource>();
            for (int i = 0; i < audioSourceList.Length; i++)
            {
                Debug.Log(audioSourceList[i]);
            }

        }
    }
}
