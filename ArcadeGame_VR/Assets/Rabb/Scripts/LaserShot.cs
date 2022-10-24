using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public GameObject Original;
    private List<GameObject> _clones = new List<GameObject>();
    private float cooldown = 1f;
    private float time = 0f;

    public void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
          //  Debug.Log("Shoot");
           GameObject clone = Instantiate(Original, transform.TransformPoint(Vector3.up * 1), transform.rotation);
            time = cooldown;
            for (int i = 0; i < 10; i++)
            {

                _clones.Add(clone);
            }
        }


        

        // When you're done with them destroy all the clones
        foreach (var cloneObj in _clones)
            Destroy(cloneObj);
        _clones.Clear();
    }
    
}
