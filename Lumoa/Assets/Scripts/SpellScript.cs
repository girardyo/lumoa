using UnityEngine;
using System.Collections;

public class SpellScript : MonoBehaviour
{
    private Transform _src;
    private Transform _target;
    private Vector3 _direction;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            SpellController.listSpells.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    public void Set(Vector3 src, Vector3 target)
    {
        transform.position = src + Vector3.up;
        Direction = (target - transform.position).normalized;
        Debug.DrawLine(src, target, Color.red, Mathf.Infinity);
    }

    public Transform Source
    {
        get => _src;
        set => _src = value;
    }
        
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }

    public Vector3 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    
    public Rigidbody Rigibody
    {
        get => GetComponent<Rigidbody>();
    }
}
