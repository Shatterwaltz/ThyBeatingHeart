using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: MonoBehaviour {
    public GameObject player;

    float time = 60;
    float fireTime = 0;
    float firetime2 = 0;

    int phase = 0;
    int direction = 1;

    public BulletMovement bullet;
    // Update is called once per frame
    void Update() {

        switch(phase) {
            case 0:
                if(fireTime > .5) {
                    transform.LookAt(player.transform);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(4, new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(Random.Range(-.3f, .3f)), new LinearEquation(10), .3f);

                    fireTime = 0;
                }
                break;
            case 1:
                if(fireTime > .06) {
                    float offset1 = Random.Range(-1.5f, 1.5f);
                    float offset2 = Random.Range(-1.5f, 1.5f);
                    float offset3 = Random.Range(-1.5f, 1.5f);
                    float offset4 = Random.Range(-1.5f, 1.5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset1, transform.rotation).Initialize(5, new LinearEquation(0), new LinearEquation(0), new ExponentialEquation(1, 30, .1f));
                    Instantiate(bullet, transform.position + Vector3.up * offset2, transform.rotation).Initialize(5, new LinearEquation(0), new LinearEquation(0), new ExponentialEquation(1, -30, .1f));
                    Instantiate(bullet, transform.position + Vector3.up * offset3, transform.rotation).Initialize(5, new ExponentialEquation(1, -30, .1f), new LinearEquation(0), new LinearEquation(0));
                    Instantiate(bullet, transform.position + Vector3.up * offset4, transform.rotation).Initialize(5, new ExponentialEquation(1, 30, .1f), new LinearEquation(0), new LinearEquation(0));

                    Instantiate(bullet, transform.position + Vector3.up * offset1, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(5, 1), new ExponentialEquation(1, 30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset2, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(5, 1), new ExponentialEquation(1, -30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset3, transform.rotation).Initialize(5, new ExponentialEquation(1, -30, .1f), new SineEquation(5, 1), new LinearEquation(0), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset4, transform.rotation).Initialize(5, new ExponentialEquation(1, 30, .1f), new SineEquation(5, 1), new LinearEquation(0), .5f);

                    Instantiate(bullet, transform.position + Vector3.up * offset1, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(-5, 1), new ExponentialEquation(1, 30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset2, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(-5, 1), new ExponentialEquation(1, -30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset3, transform.rotation).Initialize(5, new ExponentialEquation(1, -30, .1f), new SineEquation(-5, 1), new LinearEquation(0), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset4, transform.rotation).Initialize(5, new ExponentialEquation(1, 30, .1f), new SineEquation(-5, 1), new LinearEquation(0), .5f);

                    Instantiate(bullet, transform.position + Vector3.up * offset1, transform.rotation).Initialize(5, new SineEquation(5, 1), new LinearEquation(0), new ExponentialEquation(1, 30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset2, transform.rotation).Initialize(5, new SineEquation(5, 1), new LinearEquation(0), new ExponentialEquation(1, -30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset3, transform.rotation).Initialize(5, new ExponentialEquation(1, -30, .1f), new LinearEquation(0), new SineEquation(5, 1), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset4, transform.rotation).Initialize(5, new ExponentialEquation(1, 30, .1f), new LinearEquation(0), new SineEquation(5, 1), .5f);

                    Instantiate(bullet, transform.position + Vector3.up * offset1, transform.rotation).Initialize(5, new SineEquation(-5, 1), new LinearEquation(0), new ExponentialEquation(1, 30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset2, transform.rotation).Initialize(5, new SineEquation(-5, 1), new LinearEquation(0), new ExponentialEquation(1, -30, .1f), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset3, transform.rotation).Initialize(5, new ExponentialEquation(1, -30, .1f), new LinearEquation(0), new SineEquation(-5, 1), .5f);
                    Instantiate(bullet, transform.position + Vector3.up * offset4, transform.rotation).Initialize(5, new ExponentialEquation(1, 30, .1f), new LinearEquation(0), new SineEquation(-5, 1), .5f);

                    fireTime = 0;
                }
                break;
            case 2:
                if(fireTime > .025) {
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(3, 3f * direction), new LinearEquation(10));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(11), new SineEquation(3, 3f * direction), new LinearEquation(0));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(0), new SineEquation(3, 3f * direction), new LinearEquation(-10));
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(5, new LinearEquation(-11), new SineEquation(3, 3f * direction), new LinearEquation(0));
                    direction *= -1;
                    fireTime = 0;
                }
                if(firetime2 > 2.5) {
                    Quaternion rot = transform.rotation;
                    transform.LookAt(player.transform);
                    Instantiate(bullet, transform.position, transform.rotation).Initialize(10, new LinearEquation(0), new LinearEquation(0), new LinearEquation(4), 1.4f);
                    transform.rotation = rot;
                    firetime2 = 0;
                }
                firetime2 += Time.deltaTime;
                break;
        }

        if(time > 30 && phase < 1) {
            ++phase;
            transform.LookAt(Vector3.zero);
        } else if(time > 60 && phase < 2) {
            ++phase;
        } else if(time > 90) {
            Destroy(transform.parent.gameObject);

        }

        transform.parent.transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
        time += Time.deltaTime;
        fireTime += Time.deltaTime;
    }
}
