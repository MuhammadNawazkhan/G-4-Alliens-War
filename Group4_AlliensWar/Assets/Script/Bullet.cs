using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;

    public void Seek(Transform _traget) {

        target = _traget;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude<=distanceThisFrame) {
            HitTarge();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame, Space.World);

    }

    void HitTarge() { Debug.Log("Hit"); }
}
