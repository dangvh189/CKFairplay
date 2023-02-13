using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apple.Arcade;
public class SampleTest : MonoBehaviour
{
    private void Awake()
    {
        try
        {
            FairPlay.Register();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }
}
