using UnityEngine;

public class FaceSwitcher : MonoBehaviour {

    [SerializeField] Gender gender;
    [SerializeField] AgeType ageType;
    [SerializeField] EmotionType emotions;
    [SerializeField] GameObject enabledObject;
    [SerializeField] GameObject disabledObject;

    FaceController faceController;
    bool display = false;

    void Start ()
    {
        faceController = GetComponentInParent<FaceController>();
    }

    void Update()
    {
        display =   (gender == Gender.any || gender == faceController.genderType) &&
                    (ageType == AgeType.any || ageType == faceController.ageType) &&
                    (emotions == EmotionType.any || emotions == faceController.emotions);

        SwitchObjects();
    }

    void SwitchObjects()
    {
        if (enabledObject)
            enabledObject.SetActive(display);

        if (disabledObject)
            disabledObject.SetActive(!display);
    }
}
