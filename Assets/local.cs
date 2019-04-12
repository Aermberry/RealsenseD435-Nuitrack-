using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class local : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        Debug.Log(transform.position);
//        Debug.Log(transform.localPosition);
//        
//        Vector3 pos=new Vector3(2,3,3);
//        Vector3 wToL = transform.InverseTransformPoint(pos);
//        Vector3 lTol = transform.TransformPoint(wToL);
//        Debug.Log("pos:"+pos);
//        Debug.Log("世界坐标系换局部坐标系pos:"+wToL);
//        Debug.Log("局部坐标系换世界坐标系pos:"+lTol);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1,0,0)*Time.deltaTime);//默认是向着自身的局部坐标系移动
        
        transform.Translate(new Vector3(1,0,0)*Time.deltaTime,Space.World);//默认是向着自身的局部坐标系移动
        
    }
}
