using UnityEngine;

public class Bezier : MonoBehaviour
{
    [SerializeField] private Transform P0;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform P3;

    public Vector3 GetStartPos { get => P0.position; }

    public Vector3[] GetPass()
    {
        Vector3[] pass = new Vector3[30];
        for (int i = 0; i < pass.Length; i++)
        {
            pass[i] = Evaluate((float)i / pass.Length);
        }
        return pass;
    }

    private Vector3 Evaluate(float t)
    {
        float t1 = 1 - t;
        return t1 * t1 * t1 * P0.position + 3 * t * t1 * t1 * P1.position +
            3 * t * t * t1 * P2.position + t * t * t * P3.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 1; i < 50; i++)
        {
            float t = (i - 1f) / 49f;
            float t1 = i / 49f;
            Gizmos.DrawLine(Evaluate(t), Evaluate(t1));
        }
    }
}
