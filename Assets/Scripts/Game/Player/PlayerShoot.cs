using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{   
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;
    
    private bool _fireContiniusly;
    private bool _fireSingle;
    private float _lastFireTime;

    // Update is called once per frame
    void Update()
    {
        if(_fireContiniusly || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {    
                FireBullet();

                _lastFireTime = Time.time;
                _fireSingle = false;
            }
        }

    }

    

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = _bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContiniusly = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }
    
}
