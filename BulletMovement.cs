using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class BulletMovement: MonoBehaviour {
    /// <summary>
    /// Must be called after creation to set everything.
    /// </summary>
    /// <param name="lifetimeInSeconds">How long the bullet should last, in seconds</param>
    /// <param name="xAxisEquation">Equation to model movement along the x axis</param>
    /// <param name="yAxisEquation">Equation to model movement along the y axis</param>
    /// <param name="zAxisEquation">Equation to model movement along the z axis</param>
    public void Initialize(float lifetimeInSeconds, Equation xAxisEquation, Equation yAxisEquation, Equation zAxisEquation, float scale = 1f) {
        initX = transform.position.x;
        initY = transform.position.y;
        initZ = transform.position.z;
        transform.localScale *= scale;
        this.xAxisEquation = xAxisEquation;
        this.yAxisEquation = yAxisEquation;
        this.zAxisEquation = zAxisEquation;
        lifetime = lifetimeInSeconds;
    }

    private Equation xAxisEquation;
    private Equation yAxisEquation;
    private Equation zAxisEquation;

    public int damage = 0;

    private float time = 0;
    public float lifetime = 0;

    //Initial position of bullet
    private float initX;
    private float initY;
    private float initZ;

    void Update() {
        float x = 0;
        float y = 0;
        float z = 0;
        if(xAxisEquation.equationType == Equation.EquationType.SQUARE) {
            ExponentialEquation eq = (ExponentialEquation)xAxisEquation;
            x = (float)(eq.outerCoefficient * Math.Pow(time * eq.innerCoefficient, eq.exponent) );
        } else if(xAxisEquation.equationType == Equation.EquationType.SIN) {
            SineEquation eq = (SineEquation)xAxisEquation;
            x = (float)(eq.outerCoefficient * Math.Sin(time * eq.innerCoefficient) );
        } else if(xAxisEquation.equationType == Equation.EquationType.LINEAR) {
            LinearEquation eq = (LinearEquation)xAxisEquation;
            x = (float)(eq.coefficient * time);
        }
        if(yAxisEquation.equationType == Equation.EquationType.SQUARE) {
            ExponentialEquation eq = (ExponentialEquation)yAxisEquation;
            y = (float)(eq.outerCoefficient * Math.Pow(time * eq.innerCoefficient, eq.exponent) );
        } else if(yAxisEquation.equationType == Equation.EquationType.SIN) {
            SineEquation eq = (SineEquation)yAxisEquation;
            y = (float)(eq.outerCoefficient * Math.Sin(time * eq.innerCoefficient) );
        } else if(yAxisEquation.equationType == Equation.EquationType.LINEAR) {
            LinearEquation eq = (LinearEquation)yAxisEquation;
            y = (float)(eq.coefficient * time);
        }
        if(zAxisEquation.equationType == Equation.EquationType.SQUARE) {
            ExponentialEquation eq = (ExponentialEquation)zAxisEquation;
            z = (float)(eq.outerCoefficient * Math.Pow(time * eq.innerCoefficient, eq.exponent));
        } else if(zAxisEquation.equationType == Equation.EquationType.SIN) {
            SineEquation eq = (SineEquation)zAxisEquation;
            z = (float)(eq.outerCoefficient * Math.Sin(time * eq.innerCoefficient));
        } else if(zAxisEquation.equationType == Equation.EquationType.LINEAR) {
            LinearEquation eq = (LinearEquation)zAxisEquation;
            z = (float)(eq.coefficient * time);
        }

        transform.position = (transform.rotation * new Vector3((float)x, (float)y, (float)z))+new Vector3(initX, initY, initZ);
        
        if(time > lifetime) {
            Destroy(this.gameObject);
        }
        time += Time.deltaTime;
    }
}


public abstract class Equation {
    public enum EquationType {
        LINEAR,
        SQUARE,
        SIN
    }

    public EquationType equationType;
}

public class LinearEquation: Equation{
    public float coefficient;
    public LinearEquation(float coefficient){
        this.coefficient = coefficient;
        equationType = EquationType.LINEAR;
    }
}

public class ExponentialEquation: Equation {
    public float innerCoefficient;
    public float outerCoefficient;
    public float exponent;
    public ExponentialEquation(float innerCoefficient, float outerCoefficient, float exponent) {
        this.innerCoefficient = innerCoefficient;
        this.outerCoefficient = outerCoefficient;
        this.exponent = exponent;
        equationType = EquationType.SQUARE;
    }
}

public class SineEquation: Equation {
    public float innerCoefficient;
    public float outerCoefficient;
    public SineEquation(float innerCoefficient, float outerCoefficient) {
        this.innerCoefficient = innerCoefficient;
        this.outerCoefficient = outerCoefficient;
        equationType = EquationType.SIN;
    }
}