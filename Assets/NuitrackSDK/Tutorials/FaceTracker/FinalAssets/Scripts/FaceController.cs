using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FaceController : MonoBehaviour {

    public Gender genderType;
    public EmotionType emotions;
    public AgeType ageType;

    Dictionary<string, AgeType> age = new Dictionary<string, AgeType>()
    {
        { "kid", AgeType.kid },
        { "young", AgeType.young },
        { "adult", AgeType.adult },
        { "senior", AgeType.senior },
    };

    Dictionary<EmotionType, float> emotionDict = new Dictionary<EmotionType, float>()
    {
        { EmotionType.happy, 0 },
        { EmotionType.surprise, 0 },
        { EmotionType.neutral, 0 },
        { EmotionType.angry, 0 },
    };

    public void SetFace(Face newFace)
    {
        //Gender
        if (newFace.gender == "female")
            genderType = Gender.female;
        else
            genderType = Gender.male;

        //Age
        if(newFace.age != null)
            age.TryGetValue(newFace.age.type, out ageType);

        //Emotion
        if (newFace.emotions != null)
        {
            emotionDict[EmotionType.happy] = newFace.emotions.happy;
            emotionDict[EmotionType.surprise] = newFace.emotions.surprise;
            emotionDict[EmotionType.neutral] = newFace.emotions.neutral;
            emotionDict[EmotionType.angry] = newFace.emotions.angry;

            KeyValuePair<EmotionType, float> prevailingEmotion = emotionDict.First();
            foreach (KeyValuePair<EmotionType, float> emotion in emotionDict)
                if (emotion.Value > prevailingEmotion.Value) prevailingEmotion = emotion;

            emotions = prevailingEmotion.Key;
        }
    }
}
