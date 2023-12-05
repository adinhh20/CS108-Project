using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSwitchBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehaviour _doorBehaviour;
    [SerializeField] BigDoorBehaviour _bigDoorBehaviour;
    [SerializeField] bool _isDoorOpenSwitch;
    [SerializeField] bool _isDoorCloseSwitch;
    [SerializeField] InventoryManager.AllItems _requiredItem1;
    [SerializeField] InventoryManager.AllItems _requiredItem2;
    [SerializeField] AudioSource openDoorSoundEffect;

    float _switchSizeY;
    Vector3 _switchUpPos;
    Vector3 _switchDownPos;
    float _switchSpeed = 10f;
    float _switchDelay = 5f;
    bool _isPressingSwitch = false;
    // Start is called before the first frame update
    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2;

        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x, transform.position.y - _switchSizeY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!_isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }

    void MoveSwitchDown()
    {
        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPressingSwitch = !_isPressingSwitch;

            if (HasRequiredItem(_requiredItem1) && HasRequiredItem(_requiredItem2))
            {
                if (_isDoorOpenSwitch && _doorBehaviour != null && !_doorBehaviour._isDoorOpen)
                {
                    _doorBehaviour._isDoorOpen = !_doorBehaviour._isDoorOpen;
                    openDoorSoundEffect.Play();
                }
                else if (_isDoorCloseSwitch && _doorBehaviour != null && _doorBehaviour._isDoorOpen)
                {
                    _doorBehaviour._isDoorOpen = !_doorBehaviour._isDoorOpen;
                }
                else if (_isDoorOpenSwitch && _bigDoorBehaviour != null && !_bigDoorBehaviour._isDoorOpen)
                {
                    _bigDoorBehaviour._isDoorOpen = !_bigDoorBehaviour._isDoorOpen;
                    openDoorSoundEffect.Play();
                }
                else if (_isDoorCloseSwitch && _bigDoorBehaviour != null && _bigDoorBehaviour._isDoorOpen)
                {
                    _bigDoorBehaviour._isDoorOpen = !_bigDoorBehaviour._isDoorOpen;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressingSwitch = false;
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else return false;
    }
}
