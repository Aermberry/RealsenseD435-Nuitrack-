using UnityEngine;

public class BlendshapeWeights
{
    float lerpSpeed = 7f;

    float jawParam = 0;

    float leftEyeParam = 0;
    float rightEyeParam = 0;

    float leftBrowUpParam = 0;
    float rightBrowUpParam = 0;

    float smile = 0.0f;

    public float GetJawOpen(Face face)
    {
        float jawOpen = getJawOpenYRatio(face.landmark);

        if (jawOpen >= 0.51f)
        {
            jawOpen = 1.0f;
        }
        else if (jawOpen >= 0.25f)
        {
            jawOpen = 0.5f;
        }
        else
        {
            jawOpen = 0.0f;
        }
        jawParam = Mathf.Lerp(jawParam, jawOpen, lerpSpeed * Time.deltaTime);

        return jawParam * 100;
    }

    public float GetEyeBlinkLeft(Face face)
    {
        float eyeOpen = getLeftEyeOpenRatio(face.landmark);

        if (eyeOpen < 0.05f && GetJawOpen(face) < 0.3f)
        {
            leftEyeParam = Mathf.Lerp(leftEyeParam, 1, lerpSpeed * Time.deltaTime);
        }
        else
        {
            leftEyeParam = Mathf.Lerp(leftEyeParam, 0, lerpSpeed * Time.deltaTime);
        }

        return leftEyeParam * 100;
    }

    public float GetEyeBlinkRight(Face face)
    {
        float eyeOpen = getRightEyeOpenRatio(face.landmark);

        if (eyeOpen < 0.05f && GetJawOpen(face) < 0.3f)
        {
            rightEyeParam = Mathf.Lerp(rightEyeParam, 1, lerpSpeed * Time.deltaTime);
        }
        else
        {
            rightEyeParam = Mathf.Lerp(rightEyeParam, 0, lerpSpeed * Time.deltaTime);
        }

        return rightEyeParam * 100;
    }

    public float GetSmile(Face face)
    {
        float smileParam = Mathf.Lerp(smile, face.emotions.happy, lerpSpeed * Time.deltaTime);
        smile = face.emotions.happy;
        return smileParam * 100;
    }

    public float GetBrowUpLeft(Face face)
    {
        float BrowLeftUp = getLeftBrowOpenRatio(face.landmark);

        if (BrowLeftUp >= 0.5f)
        {
            BrowLeftUp = 1.0f;
        }
        else
        {
            BrowLeftUp = 0.0f;
        }

        leftBrowUpParam = Mathf.Lerp(leftBrowUpParam, BrowLeftUp, lerpSpeed * Time.deltaTime);

        return leftBrowUpParam * 100;
    }

    public float GetBrowUpRight(Face face)
    {
        float BrowRightUp = getRightBrowOpenRatio(face.landmark);

        if (BrowRightUp >= 0.5f)
        {
            BrowRightUp = 1.0f;
        }
        else
        {
            BrowRightUp = 0.0f;
        }

        rightBrowUpParam = Mathf.Lerp(rightBrowUpParam, BrowRightUp, lerpSpeed * Time.deltaTime);

        return rightBrowUpParam * 100;
    }

    float getJawOpenYRatio(Vector2[] points)
    {
        float size = Mathf.Abs(points[27].y - points[28].y) / Mathf.Abs(points[6].y - points[9].y);
        return Mathf.InverseLerp(0.0f, 0.5f, size);
    }

    float getLeftBrowOpenRatio(Vector2[] points)
    {
        float size = Mathf.Abs(points[4].y - points[6].y) / Mathf.Abs(points[6].y - points[9].y);
        return size;
        //Mathf.InverseLerp(0.5f, 0.7f, size);
    }

    float getRightBrowOpenRatio(Vector2[] points)
    {
        float size = Mathf.Abs(points[1].y - points[6].y) / Mathf.Abs(points[6].y - points[9].y);
        return size;
        //Mathf.InverseLerp(0.5f, 0.7f, size);
    }

    float getLeftEyeOpenRatio(Vector2[] points)
    {
        float size = Mathf.Abs(points[19].y - points[21].y) / Mathf.Abs(points[5].y - points[9].y);
        return Mathf.InverseLerp(0.1f, 0.16f, size);
    }

    float getRightEyeOpenRatio(Vector2[] points)
    {
        float size = Mathf.Abs(points[12].y - points[16].y) / Mathf.Abs(points[5].y - points[9].y);
        return Mathf.InverseLerp(0.1f, 0.16f, size);
    }
}
