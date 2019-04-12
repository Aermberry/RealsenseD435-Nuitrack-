#if UNITY_EDITOR

using UnityEngine;
using System.Collections.Generic;

public class HumanoidRecoder : IRecordable
{
    float time = 0;

    HumanPoseHandler humanPoseHandler;
    HumanPose humanPose = new HumanPose();  

    Dictionary<int, AnimationCurve> muscleCurves = new Dictionary<int, AnimationCurve>();
    Dictionary<string, AnimationCurve> rootCurves = new Dictionary<string, AnimationCurve>();

    Vector3 rootOffset;

    public HumanoidRecoder(Animator animator, HumanBodyBones[] humanBodyBones)
    {
        rootOffset = animator.transform.position;
        humanPoseHandler = new HumanPoseHandler(animator.avatar, animator.transform);

        foreach (HumanBodyBones unityBoneType in humanBodyBones)
        {
            for (int dofIndex = 0; dofIndex < 3; dofIndex++)
            {
                int muscle = HumanTrait.MuscleFromBone((int)unityBoneType, dofIndex);

                if (muscle != -1)
                    muscleCurves.Add(muscle, new AnimationCurve());
            }
        }

        rootCurves.Add("RootT.x", new AnimationCurve());
        rootCurves.Add("RootT.y", new AnimationCurve());
        rootCurves.Add("RootT.z", new AnimationCurve());
    }

    public void TakeSnapshot(float deltaTime)
    {
        time += deltaTime;

        humanPoseHandler.GetHumanPose(ref humanPose);

        foreach (KeyValuePair<int, AnimationCurve> data in muscleCurves)
        {
            Keyframe key = new Keyframe(time, humanPose.muscles[data.Key]);
            data.Value.AddKey(key);
        }

        Vector3 rootPosition = humanPose.bodyPosition - rootOffset;

        AddRootKey("RootT.x", rootPosition.x);
        AddRootKey("RootT.y", rootPosition.y);
        AddRootKey("RootT.z", rootPosition.z);
    }

    void AddRootKey(string property, float value)
    {
        Keyframe key = new Keyframe(time, value);
        rootCurves[property].AddKey(key);
    }

    public AnimationClip GetClip
    {
        get
        {
            AnimationClip clip = new AnimationClip();

            foreach (KeyValuePair<int, AnimationCurve> data in muscleCurves)
            {
                clip.SetCurve(null, typeof(Animator), HumanTrait.MuscleName[data.Key], data.Value);
            }

            foreach (KeyValuePair<string, AnimationCurve> data in rootCurves)
            {
                clip.SetCurve(null, typeof(Animator), data.Key, data.Value);
            }

            return clip;
        }
    }
}
#endif