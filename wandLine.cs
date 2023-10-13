using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wandLine : MonoBehaviour
{
    [SerializeField]
    protected Transform _pointerOrigin;
    [SerializeField]
    protected LineRenderer _line;
    [SerializeField]
    protected GameObject _pointer;
    public LayerMask layer;
    public void Update()
    {
        rayCast();
    }
    public void rayCast()
    {
        Vector3 direction = -_pointerOrigin.up;
        Ray ray = new Ray(_pointerOrigin.position, direction);
        RaycastHit hit;
        Vector3 hitPoint = _pointerOrigin.position + (direction);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,layer))
        {
            hitPoint = hit.point;
            _pointer.SetActive(true);
            _pointer.transform.position = hit.point;
            DrawLine(_pointerOrigin.position, hitPoint);
        }
    }
    public void DrawLine(Vector3 pWoldOriginPoint, Vector3 pWorldHitPoint)
    {
        Vector3 localOriginPoint = _line.transform.InverseTransformPoint(pWoldOriginPoint);
        Vector3 localHitPoint = _line.transform.InverseTransformPoint(pWorldHitPoint);
        _line.positionCount = 2;
        _line.SetPosition(0, pWoldOriginPoint);
        _line.SetPosition(1, pWorldHitPoint);
    }
}

