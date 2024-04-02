using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject Decal;
    [SerializeField] private float bulletDamage;
    private float speed = 150f;
    private float timeToDestroy = 2f;
    public GameObject bloodvfx;
    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < 0.01f )
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {       
            ContactPoint contact = collision.GetContact(0);
            GameObject.Instantiate(Decal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));
            Destroy(gameObject);                     
    }
    private void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        Physics.Linecast(transform.position, other.transform.position, out hit);
        
        if (other.transform.tag == "Enemy")
        {         
            other.transform.GetComponent<GeneralType>().hit(bulletDamage);
            GameObject.Instantiate(bloodvfx, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(gameObject);
        }else if (other.transform.tag == "HeadShot")
        {
            other.transform.GetComponent<GeneralType>().headShot(bulletDamage);
            GameObject.Instantiate(bloodvfx, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(gameObject);
        }
    }

}
