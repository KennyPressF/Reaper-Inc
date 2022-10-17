using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{
    public int FlipACoin()
    {
        int coinFlip = Random.Range(1, 100);
        return coinFlip;
    }
}
