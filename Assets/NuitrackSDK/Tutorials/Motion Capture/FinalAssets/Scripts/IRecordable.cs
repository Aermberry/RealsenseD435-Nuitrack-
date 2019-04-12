using UnityEngine;

public interface IRecordable
{
    void TakeSnapshot(float deltaTime);

    AnimationClip GetClip { get; }
}