using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: MonoBehaviour {
    float time = 0;

    
    int direction = 1;

    public BulletMovement bullet;
    // Update is called once per frame
    void Update() {

        if(time > .05) {
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(2, 5 * direction), new LinearEquation(10));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(10), new SineEquation(2, 5 * direction), new LinearEquation(0));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(2, 5 * direction), new LinearEquation(-10));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(-10), new SineEquation(2, 5 * direction), new LinearEquation(0));
                    direction *= -1;
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(0), new LinearEquation(0), new ExponentialEquation(1, 30, .1f));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(0), new LinearEquation(0), new ExponentialEquation(1, -30, .1f));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new ExponentialEquation(1, -30, .1f), new LinearEquation(0), new LinearEquation(0));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new ExponentialEquation(1, 30, .1f), new LinearEquation(0), new LinearEquation(0));

            

            time = 0;
        }


        transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
        time += Time.deltaTime;
    }
}
