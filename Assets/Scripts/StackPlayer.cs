using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using DG.Tweening;
public class StackPlayer : MonoBehaviour
{
    public delegate void Behaviour();
    public Behaviour currentBehaviour;
    public AnimationCurve speedCurve;
    public static StackPlayer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public Rigidbody rb;
    public float animalFarwardSpeed, starfeSpeed;
    public float boostSpeed, boostUpTime;
    float storedFarwardSpeed;
    public float stackPosoffset;
    public float shootSpeed;
    public Stack<Transform> stacks = new Stack<Transform>();
    private void Start()
    {
        storedFarwardSpeed = animalFarwardSpeed;    //store farward speed for use after boostup
        stacks.Push(transform);
        currentBehaviour = MovementController;
    }
    private void FixedUpdate()
    {
        currentBehaviour.Invoke();
    }
    public void MovementController()
    {
        rb.velocity = Vector3.forward * animalFarwardSpeed;
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * starfeSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * starfeSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stack"))
        {
            other.GetComponent<RunnerObject>().isRun = false;
            other.GetComponent<RunnerObject>().isCatch = true;
            other.GetComponent<RunnerObject>().OnCatch.Invoke();
            other.tag = "Finish";
            other.transform.position = stacks.Peek().transform.position;
            stacks.Push(other.transform);
            transform.position += new Vector3(0, stackPosoffset, 0);
            other.transform.parent = transform;
        }
        if (other.CompareTag("FinishMomentum"))
        {
            shootPoint=GameObject.FindGameObjectWithTag("ShootPoint").transform;
            rb.isKinematic = true;
            currentBehaviour=SetupShootPoint;
        }
        if (other.GetComponent<AbilityObject>())
        {
            other.GetComponent<AbilityObject>().Power();
        }
    }
    public interface IAbility
    {
        public void Power();
    }
    Transform shootPoint;
    public float lerpSpeed;
    public void SetupShootPoint()
    {
        if (transform.position.z != shootPoint.position.z)
        {
           transform.position=Vector3.MoveTowards(transform.position, new Vector3(shootPoint.position.x, transform.position.y, shootPoint.position.z), lerpSpeed);
        }
        else
        {
            currentBehaviour=FinalController;
        }
    }
    // public void FinalMomentum()
    // {
    //     print("final point ");
    //     rb.isKinematic = true;
    //     currentBehaviour = FinalController;
    // }
    public void FinalController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var v = stacks.Pop();
            v.GetComponent<DOTweenAnimation>().DOKill();
            v.GetComponent<RunnerObject>().isRun = true;
            v.GetComponent<RunnerObject>().runSpeed = shootSpeed;
        }
    }
    public IEnumerator PowerUp()
    {
        float time = 0;
        while (time < speedCurve.keys[speedCurve.keys.Length - 1].time)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
            print("run " + time);
            animalFarwardSpeed = boostSpeed * speedCurve.Evaluate(time);
        }
    }

}
