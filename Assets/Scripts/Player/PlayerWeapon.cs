using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [Header("Cursor Control")]
    public float radius = 10.0f;

    [Header("Positional Objects")]
    public Camera mainCamera;
    public Transform weaponPivot;
    public Transform cursor;

    //[HideInInspector]
    public bool isWeaponMoving;

    Vector3 lastMousePos;

    private void FixedUpdate()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        SetWeaponPivot(mousePos);
        IsWeaponMoving(mousePos);

        cursor.transform.position = mousePos;
    }

    void IsWeaponMoving(Vector3 mousePos)
    {
        float travelled = (mousePos - lastMousePos).magnitude;
        lastMousePos = mousePos;

        isWeaponMoving = (travelled > 0.1f) ? true : false;
    }

    void SetWeaponPivot(Vector3 mousePos)
    {
        Vector3 directionToCursor = (mousePos - weaponPivot.position);
        directionToCursor.z = 0;
        Quaternion pivotRot = Quaternion.LookRotation(directionToCursor.normalized);

        weaponPivot.localRotation = pivotRot;
    }
}
