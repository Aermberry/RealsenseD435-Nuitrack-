using UnityEngine;

[System.Serializable]
class ModelJoint
{
    /// <summary> Transform model bone </summary>
    public Transform bone = null;
    public nuitrack.JointType jointType = nuitrack.JointType.None;
    [HideInInspector] public Quaternion baseRotOffset;

    //For "Direct translation"
    public nuitrack.JointType parentJointType = nuitrack.JointType.None;
    /// <summary> Base model bones rotation offsets</summary>
    [HideInInspector] public Transform parentBone;
    // <summary> Base distance to parent bone </summary>
    [HideInInspector] public float baseDistanceToParent;
}
