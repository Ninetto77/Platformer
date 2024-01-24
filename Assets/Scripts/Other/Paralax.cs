using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform[] sprites;
    [SerializeField] private float[] coeff;
    private int lengthOfSprites;
    void Start()
    {
        lengthOfSprites = sprites.Length;
    }

    void Update()
    {
        for (int i = 0; i < lengthOfSprites; i++)
        {
            sprites[i].position = transform.position * coeff[i];
        }
    }
}
