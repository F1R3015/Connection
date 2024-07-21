using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRope : MonoBehaviour
{

    private LineRenderer _lr;
    private Vector2 _startLine;
    [SerializeField] private Camera _cam;
    private int _layerMask;

    Boolean _isDrawing;
    // Update is called once per frame


    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.positionCount = 2;
        _lr.useWorldSpace = true;
        _lr.startWidth = 0.3f;
        _lr.endWidth = 0.3f;
        _lr.textureMode = LineTextureMode.RepeatPerSegment;
        _isDrawing = false;
        _layerMask = 1 << 7;
    }

    void Update()
    {


        //Touch controls
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero, 0f, _layerMask) && !Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero, 0f).transform.gameObject.CompareTag("Rope"))
        {
            _startLine = _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            _lr.SetPosition(0, _startLine);
            if (Physics2D.Raycast(_startLine, Vector2.zero, 0))
            {
                _isDrawing = true;

            }
        }

        if (Input.touchCount > 0 && _isDrawing)
        {
            Vector3 _pos = _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            _pos.z = 0;
            _lr.SetPosition(1, _pos);
        }
        //Change raycast layermask?
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && _isDrawing && Physics2D.RaycastAll(_startLine, ((Vector2)_cam.ScreenToWorldPoint(Input.GetTouch(0).position)) - _startLine, Vector2.Distance(_startLine, (Vector2)_cam.ScreenToWorldPoint(Input.GetTouch(0).position)),_layerMask).Length == 2 && !Physics2D.RaycastAll(_startLine, ((Vector2)_cam.ScreenToWorldPoint(Input.GetTouch(0).position)) - _startLine, 1000f, _layerMask)[1].transform.gameObject.CompareTag("Rope") && !Physics2D.Raycast(_startLine, Vector2.zero, 0, _layerMask).transform.gameObject.Equals(Physics2D.Raycast(_startLine + (((Vector2)_cam.ScreenToWorldPoint(Input.GetTouch(0).position)) - _startLine).normalized * 0.3f, ((Vector2)_cam.ScreenToWorldPoint(Input.GetTouch(0).position)) - _startLine, 10000f, _layerMask).transform.gameObject))
        {
            _isDrawing = false;
            Vector3 _end = _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            _end.z = 0;
            GameObject _newLine = new GameObject();
            _newLine.tag = "Rope";
            _newLine.AddComponent<LineRenderer>();
            _newLine.GetComponent<LineRenderer>().textureMode = LineTextureMode.RepeatPerSegment;
            _newLine.GetComponent<LineRenderer>().positionCount = 2;
            _newLine.GetComponent<LineRenderer>().startWidth = .3f;
            _newLine.GetComponent<LineRenderer>().endWidth = .3f;
            _newLine.GetComponent<LineRenderer>().useWorldSpace = true;
            _newLine.GetComponent<LineRenderer>().material = GetComponent<LineRenderer>().material;
            _newLine.GetComponent<LineRenderer>().alignment = LineAlignment.TransformZ;
            _newLine.GetComponent<LineRenderer>().SetPosition(0, _startLine);
            _newLine.GetComponent<LineRenderer>().SetPosition(1, _cam.ScreenToWorldPoint(Input.GetTouch(0).position));
            _lr.SetPosition(0, Vector3.zero);
            _lr.SetPosition(1, Vector3.zero);
            _newLine.transform.position = _startLine + ((Vector2)_end - _startLine) / 2;
            _newLine.transform.rotation = Quaternion.FromToRotation(Vector3.right, _end - (Vector3)_startLine);
            _newLine.AddComponent<BoxCollider2D>();
            _newLine.GetComponent<BoxCollider2D>().size = new Vector2(Vector3.Distance(_end, _startLine), 0.15f);
            _newLine.GetComponent<BoxCollider2D>().offset = Vector2.zero;

        }
        else if (Input.touchCount > 0 && _isDrawing && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _isDrawing = false;
            _lr.SetPosition(0, Vector3.zero);
            _lr.SetPosition(1, Vector3.zero);
        }

        //Mouse Controls
        if (Input.GetMouseButtonDown(0) && Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, _layerMask) && !Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f).transform.gameObject.CompareTag("Rope"))
        {
            _startLine = _cam.ScreenToWorldPoint(Input.mousePosition);
            _lr.SetPosition(0, _startLine);
            if (Physics2D.Raycast(_startLine, Vector2.zero, 0))
            {
                _isDrawing = true;

            }
        }

        if (_isDrawing)
        {
            Vector3 _pos = _cam.ScreenToWorldPoint(Input.mousePosition);
            _pos.z = 0;
            _lr.SetPosition(1, _pos);
        }
        //Change raycast layermask?
        if (Input.GetMouseButtonUp(0) && _isDrawing && Physics2D.RaycastAll(_startLine, ((Vector2)_cam.ScreenToWorldPoint(Input.mousePosition)) - _startLine, Vector2.Distance(_startLine, (Vector2)_cam.ScreenToWorldPoint(Input.mousePosition)),_layerMask).Length == 2 && !Physics2D.RaycastAll(_startLine, ((Vector2)_cam.ScreenToWorldPoint(Input.mousePosition)) - _startLine, 1000f, _layerMask)[1].transform.gameObject.CompareTag("Rope") && !Physics2D.Raycast(_startLine, Vector2.zero, 0, _layerMask).transform.gameObject.Equals(Physics2D.Raycast(_startLine + (((Vector2)_cam.ScreenToWorldPoint(Input.mousePosition)) - _startLine).normalized * 0.3f, ((Vector2)_cam.ScreenToWorldPoint(Input.mousePosition)) - _startLine, 10000f, _layerMask).transform.gameObject))
        {
            _isDrawing = false;
            Vector3 _end = _cam.ScreenToWorldPoint(Input.mousePosition);
            _end.z = 0;
            GameObject _newLine = new GameObject();
            _newLine.tag = "Rope";
            _newLine.AddComponent<LineRenderer>();
            _newLine.GetComponent<LineRenderer>().textureMode = LineTextureMode.RepeatPerSegment;
            _newLine.GetComponent<LineRenderer>().positionCount = 2;
            _newLine.GetComponent<LineRenderer>().startWidth = .3f;
            _newLine.GetComponent<LineRenderer>().endWidth = .3f;
            _newLine.GetComponent<LineRenderer>().useWorldSpace = true;
            _newLine.GetComponent<LineRenderer>().material = GetComponent<LineRenderer>().material;
            _newLine.GetComponent<LineRenderer>().alignment = LineAlignment.TransformZ;
            _newLine.GetComponent<LineRenderer>().SetPosition(0, _startLine);
            _newLine.GetComponent<LineRenderer>().SetPosition(1, _cam.ScreenToWorldPoint(Input.mousePosition));
            _lr.SetPosition(0, Vector3.zero);
            _lr.SetPosition(1, Vector3.zero);
            _newLine.transform.position = _startLine + ((Vector2)_end - _startLine) / 2;
            _newLine.transform.rotation = Quaternion.FromToRotation(Vector3.right, _end - (Vector3)_startLine);
            _newLine.AddComponent<BoxCollider2D>();
            _newLine.GetComponent<BoxCollider2D>().size = new Vector2(Vector3.Distance(_end, _startLine), 0.15f);
            _newLine.GetComponent<BoxCollider2D>().offset = Vector2.zero;

        }
        else if (_isDrawing && Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
            _lr.SetPosition(0, Vector3.zero);
            _lr.SetPosition(1, Vector3.zero);
        }
    }
}
