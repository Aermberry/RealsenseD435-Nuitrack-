using UnityEngine;
using System.Collections;

public class DebugDepth : MonoBehaviour 
{
  [SerializeField]Material _depthMat = null, _segmentationMat = null;

  public static Material depthMat, segmentationMat;

	void Awake () 
  {
    depthMat = _depthMat;
    segmentationMat = _segmentationMat;
	}
}
