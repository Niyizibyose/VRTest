using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject cubePrefab;

    public void Cube()
    {
        Instantiate(cubePrefab);
    }
}
