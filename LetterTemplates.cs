using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTemplates : MonoBehaviour
{
    public LineVector lineVector;

    public static List<Vector3> GetLowAInterpolatedCoordinates()
    {
        LineVector[] lowA = LineVector.GetLowA(); // Accessing points from LineVector

        List<Vector3> lowAPoints = new List<Vector3>();

        lowAPoints.Add(lowA[0].startPoint);
        lowAPoints.Add(lowA[0].endPoint);
        lowAPoints.Add(lowA[1].startPoint);
        lowAPoints.Add(lowA[1].endPoint);

        int segments = 1000;

        List<Vector3> curve1Points = GetInterpolatedPoints(lowA[0].startPoint, lowA[0].endPoint, segments);
        List<Vector3> curve2Points = GetInterpolatedPoints(lowA[1].startPoint, lowA[1].endPoint, lowA[1].controlPoint, lowA[1].controlPoint2, segments);

        lowAPoints.AddRange(curve1Points);
        lowAPoints.AddRange(curve2Points);

        return lowAPoints;
    }

       private static List<Vector3> GetInterpolatedPoints(Vector3 start, Vector3 end, int segments = 30)
    {
        List<Vector3> interpolatedPoints = new List<Vector3>();
        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector3 point = Vector3.Lerp(start, end, t);
            interpolatedPoints.Add(point);
        }
        return interpolatedPoints;
    }

    private static List<Vector3> GetInterpolatedPoints(Vector3 start, Vector3 end, Vector3 controlPoint1, Vector3 controlPoint2, int segments = 30)
    {
        List<Vector3> interpolatedPoints = new List<Vector3>();
        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector3 point = CalculateCubicBezierPoint(start, end, controlPoint1, controlPoint2, t);
            interpolatedPoints.Add(point);
        }
        return interpolatedPoints;
    }
    public static Vector3 CalculateCubicBezierPoint(Vector3 startPoint, Vector3 endPoint, Vector3 controlPoint1, Vector3 controlPoint2, float t)
    {
        Vector3 p0 = startPoint;
        Vector3 p1 = controlPoint1;
        Vector3 p2 = controlPoint2;
        Vector3 p3 = endPoint;

        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point =
            (uuu * p0) +
            (3f * uu * t * p1) +
            (3f * u * tt * p2) +
            (ttt * p3);

        return point;
    }
}