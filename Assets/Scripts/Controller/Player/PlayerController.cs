using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour /*IDataManager*/
{
    private CharacterController controller;
    private PlayerInput PlayerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform camTransform;
    public Animator ani;
    private Vector2 SmoothAni;
    private Vector2 aniVelocity;  

    [Header("Player Config")]
    [SerializeField] private float playerWanderSpeed = 1.0f;
    [SerializeField] private float playerRunSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotSpeed = 0.5f;
    [SerializeField] private float SmoothTime = 0.05f;
    private float maxplayerHealth = 100f;
    [SerializeField] private float currentplayerHealth;
    [SerializeField] private Image bloodScreen = null;
    [SerializeField] private Image blackScreen = null; 
    [SerializeField] Transform startpoint;
    private float deleyHealth = 0;
    public SphereCollider sphereCollider;
    public float walkingPercepttionRadius = 1f;
    public float runningPercepttionRadius = 1.5f;
    public bool disable = false;
    public bool usedBandage = false;
    private float IsGrapple = 0f;

    private InputAction movementAction;
    private InputAction aimAction;
    private InputAction runAction;
    private InputAction healBandage;
    private InputAction healMedicpen;
    private InputAction ExitGrapple;
    public int Medicpen;
    public int Bandage;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        PlayerInput = GetComponent<PlayerInput>();
        ani = GetComponent<Animator>();
        camTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;

        this.transform.position = startpoint.position;

        movementAction = PlayerInput.actions["Movement"];
        aimAction = PlayerInput.actions["Aim"];
        runAction = PlayerInput.actions["Run"];
        healMedicpen = PlayerInput.actions["HealMedicpen"];
        healBandage = PlayerInput.actions["HealBandage"];
        ExitGrapple = PlayerInput.actions["ExitGrapple"];

        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        
        if (!disable)
        {
            death();
            UpdateHealth();
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector2 Input = movementAction.ReadValue<Vector2>();
            SmoothAni = Vector2.SmoothDamp(SmoothAni, Input, ref aniVelocity, SmoothTime);
            Vector3 move = new Vector3(SmoothAni.x, 0, SmoothAni.y);
            move = move.x * camTransform.right.normalized + move.z * camTransform.forward.normalized;
            move.y = 0f;

            if (runAction.inProgress)
            {
                controller.Move(move * Time.deltaTime * playerRunSpeed);
                ani.SetFloat("MoveX", SmoothAni.x * 3);
                ani.SetFloat("MoveY", SmoothAni.y * 3);
                sphereCollider.radius = runningPercepttionRadius;
            }
            else
            {
                controller.Move(move * Time.deltaTime * playerWanderSpeed);
                ani.SetFloat("MoveX", SmoothAni.x);
                ani.SetFloat("MoveY", SmoothAni.y);
                sphereCollider.radius = walkingPercepttionRadius;
            }

            if (aimAction.inProgress && groundedPlayer)
            {
                ani.SetBool("IsHasGun", true);
            }
            else
            {
                ani.SetBool("IsHasGun", false);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            if (move == Vector3.zero)
            {
                Quaternion rot = Quaternion.Euler(0, camTransform.eulerAngles.y, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1f * Time.deltaTime);
            }

            if (aimAction.inProgress)
            {
                Quaternion rot = Quaternion.Euler(0, camTransform.eulerAngles.y + 30, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed * Time.deltaTime);
            }
            else
            {
                Quaternion rot = Quaternion.Euler(0, camTransform.eulerAngles.y, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed - 1f * Time.deltaTime);
            }
            if (healMedicpen.triggered)
            {
                useMedicpen();
            }
            if (healBandage.triggered)
            {
                useBandage();
                usedBandage = true;
            }
            if (usedBandage)
            {
                deleyHealth += Time.deltaTime;
                currentplayerHealth += Time.deltaTime;
                if (deleyHealth > 25)
                {
                    usedBandage = false;
                }
            }
        }
        else
        {
            IsGrapple += Time.deltaTime;
            if (ExitGrapple.triggered)
            {
                IsGrapple += Time.deltaTime;                              
            }
            if (IsGrapple > 1f)
            {
                disable = true;
            }
        }       
    }
    private void useMedicpen()
    {
        if (Medicpen > 0)
        {
            currentplayerHealth += 100;
            Medicpen--;
        }
    }
    private void useBandage()
    {
        if (Bandage > 0)
        {
            currentplayerHealth += 25;         
            Bandage--;
        }
    }
    public void hit(float damage)
    {
        currentplayerHealth -= damage;       
    }
    private void UpdateHealth()
    {
        Color bloodAlpha = bloodScreen.color;
        bloodAlpha.a = 1 - (currentplayerHealth / 100);
        bloodScreen.color = bloodAlpha;
        Color blackAlpha = blackScreen.color;
        blackAlpha.a = 1 - ((currentplayerHealth*2) / 100);
        blackScreen.color = blackAlpha;
    }
    private void death()
    {
        if (currentplayerHealth <= 0)
        {
            StartCoroutine("Respwan");
            currentplayerHealth = maxplayerHealth;
        }
    }
    IEnumerator Respwan()
    {
        disable = true;
        yield return new WaitForSeconds(0.01f);
        yield return new WaitForSeconds(0.01f);
        disable = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<GeneralType>().OnAware();
        }
    }
    public int getMedicpen(int medicpen)
    {
        Medicpen += medicpen;
        return Medicpen;
    }
    public int getBandage(int bandage)
    {
        Bandage += bandage;
        return Bandage;
    }
    //public void LoadData(GameData data)
    //{
    //    this.currentplayerHealth = data.playerHealth;
    //    this.transform.position = data.playerPosition;
    //}
    //public void SaveData(ref GameData data)
    //{
    //    data.playerHealth = this.currentplayerHealth;
    //    data.playerPosition = this.transform.position;
    //}
}