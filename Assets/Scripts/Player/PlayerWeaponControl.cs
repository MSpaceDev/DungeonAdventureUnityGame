using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponControl : MonoBehaviour {

    [Header("Cursor Control")]
    public float radius = 10.0f;

    [Header("Positional Objects")]
    public Camera mainCamera;
    public Transform weaponPivot;
    public Transform cursor;

    private void FixedUpdate()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        Vector3 directionToCursor = (mousePos - weaponPivot.position);
        directionToCursor.z = 0;
        Quaternion pivotRot= Quaternion.LookRotation(directionToCursor.normalized);

        weaponPivot.localRotation = pivotRot;

        // Lock cursor to set radius from player
        float distance = Vector2.Distance(mousePos, transform.position);

        if (distance > radius)
        {
            Vector3 fromOriginToObject = mousePos - transform.position;
            fromOriginToObject *= radius / distance;
            mousePos = transform.position + fromOriginToObject;
        }

        cursor.transform.position = mousePos;
    }

    void SetCursorPosition()
    {

    }
}
