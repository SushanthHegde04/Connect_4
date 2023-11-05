using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{

    public GameObject circle;
    public int width = 10;
    public int height=4;

    // Start is called before the first frame update
    void Start()
    {
    for(int y=-5;y<=height;y=y+2) 
    {
        for(int x=-6;x<=width;x=x+2)
        {
            Instantiate(circle, new Vector3(x,y,0) , Quaternion.identity);
        }
    }   
    }
}
