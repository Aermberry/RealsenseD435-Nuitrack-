using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AnimatorAvatar : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] List<SimpleJoint> joints = new List<SimpleJoint>();

    void Start ()
    {
        foreach (SimpleJoint item in joints)
        {
            HumanBodyBones unityBoneType = item.nuitrackJoint.ToUnityBones();
            Transform bone = animator.GetBoneTransform(unityBoneType);

            item.Bone = bone;
            item.Offset = bone.rotation;
        }
    }

    void LateUpdate()
    {
        if (CurrentUserTracker.CurrentSkeleton != null)
        {
            nuitrack.Skeleton skeleton = CurrentUserTracker.CurrentSkeleton;
            transform.position = Quaternion.Euler(0f, 180f, 0f) * (0.001f * skeleton.GetJoint(nuitrack.JointType.Torso).ToVector3());

            foreach (SimpleJoint item in joints)
            {
                nuitrack.Joint joint = skeleton.GetJoint(item.nuitrackJoint);

                Quaternion rotation = Quaternion.Inverse(CalibrationInfo.SensorOrientation) * joint.ToQuaternionMirrored() * item.Offset;
                item.Bone.rotation = rotation;
            }
        }
    }

    public HumanBodyBones[] GetHumanBodyBones
    {
        get
        {
            return joints.Select(x => x.nuitrackJoint.ToUnityBones()).ToArray();
        }
    }

    public Animator GetAnimator
    {
        get
        {
            return animator;
        }
    }
}

[System.Serializable]
class SimpleJoint
{
    public nuitrack.JointType nuitrackJoint = nuitrack.JointType.None;

    public Quaternion Offset { get; set; }

    public Transform Bone { get; set; }
}