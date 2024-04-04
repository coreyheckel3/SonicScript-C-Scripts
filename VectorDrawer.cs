/*//USED TO DEBUG AND VIEW VECTORS 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VectorDrawer : MonoBehaviour
{
    public Material lineMaterial;
    private LineVector[] lowF;
    private LineVector[][] alphabet;
    public Vector3 offset;

    private void Start()
    {
        lowF = LineVector.GetLowF();
    }

   private void OnRenderObject()
    {
        if (lineMaterial == null)
        {
            Debug.LogError("Line material is not assigned.");
            return;
        }

        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.LINES);
        GL.Color(Color.white);

        foreach (LineVector lineVector in lowF)
        {
            if (lineVector.isCurved)
            {
                Vector3 adjustedStartPoint = lineVector.startPoint + offset;
                Vector3 adjustedEndPoint = lineVector.endPoint + offset;
                Vector3[] adjustedControlPoints = new Vector3[2];
                adjustedControlPoints[0] = lineVector.controlPoint + offset;
                adjustedControlPoints[1] = lineVector.controlPoint2 + offset;

                DrawCurve(adjustedStartPoint, adjustedEndPoint, adjustedControlPoints);
            }
            else
            {
                Vector3 adjustedStartPoint = lineVector.startPoint + offset;
                Vector3 adjustedEndPoint = lineVector.endPoint + offset;

                DrawLine(adjustedStartPoint, adjustedEndPoint);
            }
        }

        GL.End();

        GL.PopMatrix();
    }

    private void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        GL.Vertex(startPoint);
        GL.Vertex(endPoint);
    }

    private void DrawCurve(Vector3 startPoint, Vector3 endPoint, Vector3[] controlPoints)
    {
        int segments = 40; // Increase the number of segments for smoother curve
        float tStep = 1f / segments;

        Vector3 previousPoint = startPoint;

        for (int i = 1; i <= segments; i++)
        {
            float t = i * tStep;
            Vector3 point = CalculateCubicBezierPoint(startPoint, endPoint, controlPoints[0], controlPoints[1], t);

            GL.Vertex(previousPoint);
            GL.Vertex(point);

            previousPoint = point;
        }
    }

    private Vector3 CalculateCubicBezierPoint(Vector3 startPoint, Vector3 endPoint, Vector3 controlPoint1, Vector3 controlPoint2, float t)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point =
            (uuu * startPoint) +
            (3f * uu * t * controlPoint1) +
            (3f * u * tt * controlPoint2) +
            (ttt * endPoint);

        return point;
    }
}*/