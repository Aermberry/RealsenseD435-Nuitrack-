#if UNITY_EDITOR

using UnityEngine;
#if UNITY_2017_4 || UNITY_2018_2
using UnityEditor.Experimental.Animations;
#endif

public class ExperimentalRecorder : IRecordable
{
#if UNITY_2017_4 || UNITY_2018_2
    GameObjectRecorder m_Recorder;
#endif
    public ExperimentalRecorder(GameObject rootObject)
    {
#if UNITY_2017_4

        m_Recorder = new GameObjectRecorder();
        m_Recorder.root = rootObject;
        m_Recorder.BindComponent<Transform>(rootObject, true);

#elif UNITY_2018_2

        m_Recorder = new GameObjectRecorder(rootObject);
        m_Recorder.BindComponentsOfType<Transform>(rootObject, true);

#else
        PrintErrorVersion();
#endif

    }

    public void TakeSnapshot(float deltaTime)
    {
#if UNITY_2017_4 || UNITY_2018_2
        m_Recorder.TakeSnapshot(deltaTime);
#else
        PrintErrorVersion();
#endif
    }

    public AnimationClip GetClip
    {
        get
        {
#if UNITY_2017_4 || UNITY_2018_2

            AnimationClip clip = new AnimationClip();
            m_Recorder.SaveToClip(clip);
            m_Recorder.ResetRecording();

            return clip;
#else
            PrintErrorVersion();
            return null;
#endif
        }
    }

    void PrintErrorVersion()
    {
        Debug.Log("Check your Unity version");
    }
}
#endif