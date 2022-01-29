using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHandler : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    public float wallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wall.transform.position = new Vector3(wall.transform.position.x + (wallSpeed / 500), 0, 0);
    }
}
