using UnityEngine;
using System.Collections.Generic;
using nuitrack;

public class FaceAnimManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] FaceAnimController facePrefab;

    [Range(0, 6)]
    [SerializeField] int faceCount = 6;         //Max number of skeletons tracked by Nuitrack

    public FaceInfo faceInfo;
    List<FaceAnimController> faceAnimControllers = new List<FaceAnimController>();
    float headsDistance = 100;

    void Start()
    {
        for (int i = 0; i < faceCount; i++)
        {
            GameObject newFace = Instantiate(facePrefab.gameObject, new UnityEngine.Vector3(i*headsDistance,0,0), Quaternion.identity);
            newFace.SetActive(false);
            FaceAnimController faceAnimController = newFace.GetComponent<FaceAnimController>();
            faceAnimController.Init(canvas);
            faceAnimControllers.Add(faceAnimController);
        }

        NuitrackManager.SkeletonTracker.SetNumActiveUsers(faceCount);
        NuitrackManager.SkeletonTracker.OnSkeletonUpdateEvent += OnSkeletonUpdate;
    }

    void OnSkeletonUpdate(SkeletonData skeletonData)
    {
        string json = Nuitrack.GetInstancesJson();
        faceInfo = JsonUtility.FromJson<FaceInfo>(json.Replace("\"\"", "[]"));

        if (faceInfo.Instances.Length == 0)
            return;

        for (int i = 0; i < faceAnimControllers.Count; i++)
        {
            if (i < skeletonData.Skeletons.Length)
            {
                Skeleton skeleton = skeletonData.GetSkeletonByID(faceInfo.Instances[i].id);
                if(skeleton != null)
                {
                    nuitrack.Joint headJoint = skeleton.GetJoint(JointType.Head);

                    faceAnimControllers[i].gameObject.SetActive(headJoint.Confidence > 0.5f);
                    faceAnimControllers[i].UpdateFace(faceInfo.Instances[i], headJoint);
                }
            }
            else
            {
                faceAnimControllers[i].gameObject.SetActive(false);
            }
        }
    }
}
