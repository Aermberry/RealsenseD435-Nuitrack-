using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFace : MonoBehaviour {

    int frameId = 0;

    FaceInfo faceInfo;

    [SerializeField] GameObject sphere;

    List<Transform> points = new List<Transform>();

    FaceAnimManager faceAnimManager;

    float landmarkCount = 31;
    float eyesCount = 2;

    void Start()
    {
        faceAnimManager = FindObjectOfType<FaceAnimManager>();

        for (int i = 0; i < landmarkCount + eyesCount; i++)
        {
            Transform point = Instantiate(sphere,transform, false).transform;
            point.localScale /= 16;
            //point.parent = transform;
            points.Add(point);
        }
    }


    void Update()
    {
        faceInfo = faceAnimManager.faceInfo;

        if (faceInfo == null || faceInfo.Instances.Length == 0 || faceInfo.Instances[0].face == null || faceInfo.Instances[0].face.landmark == null)
            return;

        Face face = faceInfo.Instances[0].face;

        for (int i = 0; i < landmarkCount; i++)
        {
            Vector2 point = face.landmark[i];
            points[i].position = new Vector2(point.x * Screen.width, Screen.height - point.y * Screen.height);
        }

        points[32].position = new Vector2(face.left_eye.x * Screen.width, Screen.height - face.left_eye.y * Screen.height);
        points[32].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        points[31].position = new Vector2(face.right_eye.x * Screen.width, Screen.height - face.right_eye.y * Screen.height);
        points[31].GetComponent<UnityEngine.UI.Image>().color = Color.green;
    }

}
