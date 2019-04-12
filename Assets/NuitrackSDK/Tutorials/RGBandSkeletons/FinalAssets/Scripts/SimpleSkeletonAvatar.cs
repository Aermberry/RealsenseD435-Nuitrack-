using System.Collections.Generic;
using UnityEngine;

public class SimpleSkeletonAvatar : MonoBehaviour
{
    public bool autoProcessing = true;
    [SerializeField] GameObject jointPrefab = null, connectionPrefab = null;

    nuitrack.JointType[] jointsInfo = new nuitrack.JointType[]
    {
        nuitrack.JointType.Head,
        nuitrack.JointType.Neck,
        nuitrack.JointType.LeftCollar,
        nuitrack.JointType.Torso,
        nuitrack.JointType.Waist,
        nuitrack.JointType.LeftShoulder,
        nuitrack.JointType.RightShoulder,
        nuitrack.JointType.LeftElbow,
        nuitrack.JointType.RightElbow,
        nuitrack.JointType.LeftWrist,
        nuitrack.JointType.RightWrist,
        nuitrack.JointType.LeftHand,
        nuitrack.JointType.RightHand,
        nuitrack.JointType.LeftHip,
        nuitrack.JointType.RightHip,
        nuitrack.JointType.LeftKnee,
        nuitrack.JointType.RightKnee,
        nuitrack.JointType.LeftAnkle,
        nuitrack.JointType.RightAnkle
    };

    nuitrack.JointType[,] connectionsInfo = new nuitrack.JointType[,]
    { //Right and left collars are currently located at the same point, that's why we use only 1 collar,
        //it's easy to add rightCollar, if it ever changes
        {nuitrack.JointType.Neck,           nuitrack.JointType.Head},
        {nuitrack.JointType.LeftCollar,     nuitrack.JointType.Neck},
        {nuitrack.JointType.LeftCollar,     nuitrack.JointType.LeftShoulder},
        {nuitrack.JointType.LeftCollar,     nuitrack.JointType.RightShoulder},
        {nuitrack.JointType.LeftCollar,     nuitrack.JointType.Torso},
        {nuitrack.JointType.Waist,          nuitrack.JointType.Torso},
        {nuitrack.JointType.Waist,          nuitrack.JointType.LeftHip},
        {nuitrack.JointType.Waist,          nuitrack.JointType.RightHip},
        {nuitrack.JointType.LeftShoulder,   nuitrack.JointType.LeftElbow},
        {nuitrack.JointType.LeftElbow,      nuitrack.JointType.LeftWrist},
        {nuitrack.JointType.LeftWrist,      nuitrack.JointType.LeftHand},
        {nuitrack.JointType.RightShoulder,  nuitrack.JointType.RightElbow},
        {nuitrack.JointType.RightElbow,     nuitrack.JointType.RightWrist},
        {nuitrack.JointType.RightWrist,     nuitrack.JointType.RightHand},
        {nuitrack.JointType.LeftHip,        nuitrack.JointType.LeftKnee},
        {nuitrack.JointType.LeftKnee,       nuitrack.JointType.LeftAnkle},
        {nuitrack.JointType.RightHip,       nuitrack.JointType.RightKnee},
        {nuitrack.JointType.RightKnee,      nuitrack.JointType.RightAnkle}
    };

    GameObject[] connections;
    Dictionary<nuitrack.JointType, GameObject> joints;

    void Start()
    {
        CreateSkeletonParts();
    }

    void CreateSkeletonParts()
    {
        joints = new Dictionary<nuitrack.JointType, GameObject>();

        for (int i = 0; i < jointsInfo.Length; i++)
        {
            if (jointPrefab != null)
            {
                GameObject joint = Instantiate(jointPrefab, transform, true);
                joint.SetActive(false);
                joints.Add(jointsInfo[i], joint);
            }
        }

        connections = new GameObject[connectionsInfo.GetLength(0)];

        for (int i = 0; i < connections.Length; i++)
        {
            if (connectionPrefab != null)
            {
                GameObject connection = Instantiate(connectionPrefab, transform, true);
                connection.SetActive(false);
                connections[i] = connection;
            }
        }
    }

    void Update()
    {
        if (autoProcessing)
            ProcessSkeleton(CurrentUserTracker.CurrentSkeleton);
    }

    public void ProcessSkeleton(nuitrack.Skeleton skeleton)
    {
        if (skeleton == null)
            return;

        for (int i = 0; i < jointsInfo.Length; i++)
        {
            nuitrack.Joint j = skeleton.GetJoint(jointsInfo[i]);
            if (j.Confidence > 0.5f)
            {
                joints[jointsInfo[i]].SetActive(true);
                joints[jointsInfo[i]].transform.position = new Vector2(j.Proj.X * Screen.width, Screen.height - j.Proj.Y * Screen.height);
            }
            else
            {
                joints[jointsInfo[i]].SetActive(false);
            }
        }

        for (int i = 0; i < connectionsInfo.GetLength(0); i++)
        {
            GameObject startJoint = joints[connectionsInfo[i, 0]];
            GameObject endJoint = joints[connectionsInfo[i, 1]];

            if (startJoint.activeSelf && endJoint.activeSelf)
            {
                connections[i].SetActive(true);

                connections[i].transform.position = startJoint.transform.position;
                connections[i].transform.right = endJoint.transform.position - startJoint.transform.position;
                float distance = Vector3.Distance(endJoint.transform.position, startJoint.transform.position);
                connections[i].transform.localScale = new Vector3(distance, 1f, 1f);
            }
            else
            {
                connections[i].SetActive(false);
            }
        }
    }
}
