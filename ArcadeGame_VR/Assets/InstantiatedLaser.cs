using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedLaser : MonoBehaviour
{
    public GameObject Original;
    private List<GameObject> _clones = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            for (int i = 0; i < 10; i++)
            {
                //var clone = Instantiate(Original, transform.TransformPoint(Vector3.up * 1), transform.rotation);
                _clones.Add(Original);
            //Debug.Log(clone);
            }

       

        // When you're done with them destroy all the clones
        foreach (var cloneObj in _clones)
            Destroy(cloneObj);
        _clones.Clear();
    }
}

