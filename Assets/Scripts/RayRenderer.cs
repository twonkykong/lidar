using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRenderer : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private List<Vector3[]> _lines = new List<Vector3[]>();
    [SerializeField] private List<Color> _lineColors = new List<Color>();

    public void AddLine(Vector3 start, Vector3 end, Color color)
    {
        _lines.Add(new Vector3[2] { start, end });
        _lineColors.Add(color);
    }

    public void ClearLines()
    {
        _lines = new List<Vector3[]>();
        _lineColors = new List<Color>();
    }

    private void OnPostRender()
    {
        GL.Begin(GL.LINES);
        for (int i = 0; i < _lines.Count; i++)
        {
            Debug.Log(_lines[i][0] + " " + _lines[i][1]);
            material.SetPass(0);
            GL.Color(material.color);
            GL.Vertex(_lines[i][0]);
            GL.Vertex(_lines[i][1]);
        }
        GL.End();
    }
}
