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

        // If player is flipped, invert angles from pivotRot so weapon to cursor stays the same
        if (Player.instance.PlayerMovement.isFlipped)
        {
            weaponPivot.localRotation = Quaternion.Euler((pivotRot.eulerAngles.x - 180) % 360, (pivotRot.eulerAngles.y - 180) % 360, (pivotRot.eulerAngles.z - 180) % 360);
            weaponPivot.localScale = new Vector3(weaponPivot.localScale.x, weaponPivot.localScale.y, -Mathf.Abs(weaponPivot.localScale.z));
        }
        else
        {
            weaponPivot.localRotation = pivotRot;
            weaponPivot.localScale = new Vector3(weaponPivot.localScale.x, weaponPivot.localScale.y, Mathf.Abs(weaponPivot.localScale.z));
        }
    }
}
