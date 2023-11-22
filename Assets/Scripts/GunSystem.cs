using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour{

    public GameObject player;
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    // public GameObject muzzleFlash, bulletHoleGraphic;
    // public CamShake camShake;
    // public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI magazineText;
    public TextMeshProUGUI pointsText;

    [Header("Sistema de apuntado")]
    public GameObject mainCamera;
    public GameObject aimCamera;
    public int manager;

    private void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update(){
        MyInput();

        //SetText
        pointsText.SetText("Score:" + player.GetComponent<PlayerMove>().getPuntos().ToString());
        magazineText.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput(){
        if (allowButtonHold){
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKey(KeyCode.Mouse1)) Aim();
        if (Input.GetKeyUp(KeyCode.Mouse1)) StopAim();

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot(){
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy)){
            Debug.Log("Le diste al:" + rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy")){
                rayHit.collider.GetComponent<Enemigo>().TakeDamage(damage,player);
                Debug.Log("El enemigo tiene de vida:" + rayHit.collider.GetComponent<Enemigo>().vida);
            }
        }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot(){
        readyToShoot = true;
    }
    private void Reload(){
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished(){
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private void Aim(){
        mainCamera.SetActive(false);
        aimCamera.SetActive(true);
    }

    private void StopAim(){
        mainCamera.SetActive(true);
        aimCamera.SetActive(false);
    }
}
