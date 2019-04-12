#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

public class UnityAnimationRecorder : MonoBehaviour
{
    enum RecordMode { Generic, GenericExperimental, Humanoid };

    [Header("Generic")]
    [SerializeField] RecordMode recordMode = RecordMode.Generic;

    [Header("Save")]
    [SerializeField] string savePath = "Assets/NuitrackSDK/Tutorials/Motion Capture/Animations";
    [SerializeField] string fileName = "Example";

    [Header("Control")]
    [SerializeField] TPoseCalibration poseCalibration;
    [SerializeField] GameObject recordIcon;

    bool isRecording = false;
    IRecordable recordable = null;
    
    [Header("Generic Animations")]

    [SerializeField] Transform root;
    [SerializeField] Transform[] transforms;

    [Header("Humanoid Animations")]
    [SerializeField] AnimatorAvatar animatorAvatar;

    void Start()
    {
        poseCalibration.onSuccess += PoseCalibration_onSuccess;

        switch (recordMode)
        {
            case RecordMode.Generic:
                recordable = new GenericRecorder(transforms, root);
                break;

            case RecordMode.GenericExperimental:
                recordable = new ExperimentalRecorder(root.gameObject);
                break;

            case RecordMode.Humanoid:
                recordable = new HumanoidRecoder(animatorAvatar.GetAnimator, animatorAvatar.GetHumanBodyBones);
                break;
        }
    }

    private void OnDestroy()
    {
        poseCalibration.onSuccess -= PoseCalibration_onSuccess;
    }

    private void PoseCalibration_onSuccess(Quaternion rotation)
    {
        if (!isRecording)
        {
            Debug.Log("Start recording");
            isRecording = true;
        }
        else
        {
            Debug.Log("Stop recording");
            isRecording = false;
            SaveToFile(recordable.GetClip);
        }

        recordIcon.SetActive(isRecording);
    }

    void Update()
    {
        if (isRecording)
            recordable.TakeSnapshot(Time.deltaTime);
    }

    void SaveToFile(AnimationClip clip)
    {
        string path = savePath + "/" + fileName + ".anim";
        clip.name = fileName;

        AssetDatabase.CreateAsset(clip, path);
        Debug.Log("Save to: " + path);
    }
}
#endif