using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerEntity))]
public class SingleTowerEntity : TowerEntity
{
    [SerializeField]
    private EnemyEntity Target;
    [SerializeField]
    private bool CanShoot;
    public GameObject Patron;
    public GameObject Gun;
    public GameObject LeftPos;
    public GameObject RightPos;
    public GameObject Magazine;

    public AudioClip lazer;
    public AudioSource aud;
    void Start()
    {
        Magazine = GameObject.Find("Magazine");
        ShootCorut = true;
        GetComponent<SphereCollider>().radius = RangeAttack;
        aud = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }
    private bool ShootCorut;
    void Update()
    {
		if (Target != null)
		{
			LookAtTarget();
		}
        if (CanShoot && ShootCorut)
        {
            Shoot();
        }
    }

    void LookAtTarget()
    {
        if(EnemiesIn.Count != 0)
        {
            Vector3 direction = Target.transform.position - Gun.transform.position;
            Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            Gun.transform.rotation = Quaternion.Lerp(Gun.transform.rotation, rotation, 10f * Time.deltaTime);
        }
    }

    void Shoot()
    {
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        ShootCorut = false;
        aud.PlayOneShot(lazer);
        var clone = Instantiate(Patron, RightPos.transform.position, Quaternion.identity, Magazine.transform);
        clone.GetComponent<SinglePatronEntity>().Target = Target;
        clone.GetComponent<SinglePatronEntity>().Damage = Damage;
        yield return new WaitForSeconds(SpeedShooting);
        //aud.PlayOneShot(lazer);
        clone = Instantiate(Patron, LeftPos.transform.position, Quaternion.identity, Magazine.transform);
        clone.GetComponent<SinglePatronEntity>().Target = Target;
        clone.GetComponent<SinglePatronEntity>().Damage = Damage;
        yield return new WaitForSeconds(SpeedShooting);
        ShootCorut = true;
    }
    void TargetEnemy()
    {
        if(EnemiesIn.Count != 0)
        {
            Target = EnemiesIn[0];
            CanShoot = true;
        } else
        {
            CanShoot = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            AddEnemy(other.gameObject.GetComponent<EnemyEntity>());
            TargetEnemy();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyEntity>().Alive == false)
            {
                RemoveEnemy(other.gameObject.GetComponent<EnemyEntity>());
                TargetEnemy();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            RemoveEnemy(other.gameObject.GetComponent<EnemyEntity>());
            TargetEnemy();
        }
    }

}
