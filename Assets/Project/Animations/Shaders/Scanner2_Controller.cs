using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner2_Controller : MonoBehaviour
{
    [Header("speed")]
    public float speed;

    [Header("destory time")]
    public float delay_destory_time;

    // Start is called before the first frame update
    void Start()
    {
        destory_object();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorMesh = this.transform.localScale;
        float growing = this.speed * Time.deltaTime;
        this.transform.localScale = new Vector3(vectorMesh.x + growing, vectorMesh.y + growing, vectorMesh.z + growing);
    }

    private void destory_object()
    {
        Destroy(this.gameObject, delay_destory_time);
    }
}
