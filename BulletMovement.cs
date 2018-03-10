using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class BulletMovement: MonoBehaviour {

    public enum equation {
        LINEAR,
        SQUARE,
        SIN
    }

    public equation equationTypeX;
    public equation equationTypeY;
    public equation equationTypeZ;

    public float linearCoeffX = 0;
    public float linearCoeffY = 0;
    public float linearCoeffZ = 0;

    public float squareInnerCoeffX = 0;
    public float squareInnerCoeffY = 0;
    public float squareInnerCoeffZ = 0;
    public float squareOuterCoeffX = 0;
    public float squareOuterCoeffY = 0;
    public float squareOuterCoeffZ = 0;
    public float squareExponentX = 0;
    public float squareExponentY = 0;
    public float squareExponentZ = 0;

    public float sinOuterX = 0;
    public float sinOuterY = 0;
    public float sinOuterZ = 0;
    public float sinInnerX = 0;
    public float sinInnerY = 0;
    public float sinInnerZ = 0;

    public float rateX = 0;
    public float rateY = 0;
    public float rateZ = 0;

    private float timeX = 0;
    private float timeY = 0;
    private float timeZ = 0;


    //Initial position of bullet
    private float initX;
    private float initY;
    private float initZ;


    void Start() {
        initX = transform.position.x;
        initY = transform.position.y;
        initZ = transform.position.z;
    }


    void Update() {
        float x = 0;
        float y = 0;
        float z = 0;
        if(equationTypeX == equation.SQUARE) {
            x = (float)(squareOuterCoeffX * Math.Pow(timeX * squareInnerCoeffX, squareExponentX) + initX);
        } else if(equationTypeX == equation.SIN) {
            x = (float)(sinOuterX * Math.Sin(timeX * sinInnerX) + initX);
        } else if(equationTypeX == equation.LINEAR) {
            x = (float)(linearCoeffX * timeX + initX);
        }
        if(equationTypeY == equation.SQUARE) {
            y = (float)(squareOuterCoeffY * Math.Pow(timeY * squareInnerCoeffY, squareExponentY) + initY);
        } else if(equationTypeY == equation.SIN) {
            y = (float)(sinOuterY * Math.Sin(timeY * sinInnerY) + initY);
        } else if(equationTypeY == equation.LINEAR) {
            y = (float)(linearCoeffY * timeY + initY);
        }
        if(equationTypeZ == equation.SQUARE) {
            z = (float)(squareOuterCoeffZ * Math.Pow(timeZ * squareInnerCoeffZ, squareExponentZ) + initZ);
        } else if(equationTypeZ == equation.SIN) {
            z = (float)(sinOuterZ * Math.Sin(timeZ * sinInnerZ) + initZ);
        } else if(equationTypeZ == equation.LINEAR) {
            z = (float)(linearCoeffZ * timeZ + initZ);
        }
        transform.position = new Vector3((float)x, (float)y, (float)z);

        timeX += rateX;
        timeY += rateY;
        timeZ += rateZ;
    }
}

[CustomEditor(typeof(BulletMovement))]
public class BulletMovementEditor: Editor {
    public enum Axis { X, Y, Z }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("equationTypeX"));
        Show(serializedObject.FindProperty("equationTypeX"), Axis.X);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("equationTypeY"));
        Show(serializedObject.FindProperty("equationTypeY"), Axis.Y);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("equationTypeZ"));
        Show(serializedObject.FindProperty("equationTypeZ"), Axis.Z);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rateX"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rateY"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rateZ"));

        serializedObject.ApplyModifiedProperties();
    }

    public void Show(SerializedProperty eqType, Axis axis) {
        EditorGUI.indentLevel += 1;
        if(eqType.enumValueIndex == 0) {
            if(axis == Axis.X)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("linearCoeffX"));
            else if(axis == Axis.Y)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("linearCoeffY"));
            else if(axis == Axis.Z)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("linearCoeffZ"));
        } else if(eqType.enumValueIndex == 1) {
            if(axis == Axis.X) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareInnerCoeffX"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareOuterCoeffX"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareExponentX"));

            } else if(axis == Axis.Y) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareInnerCoeffY"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareOuterCoeffY"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareExponentY"));

            } else if(axis == Axis.Z) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareInnerCoeffZ"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareOuterCoeffZ"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("squareExponentZ"));

            }
        } else if(eqType.enumValueIndex == 2) {
            if(axis == Axis.X) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sinOuterX"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sinInnerX"));
            } else if(axis == Axis.Y) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sinOuterY"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sinInnerY"));
            } else if(axis == Axis.Z) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sinOuterZ"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sinInnerZ"));
            }
        }
        EditorGUI.indentLevel -= 1;
    }

}