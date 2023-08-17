using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogCheckerAndAccessor : MonoBehaviour
{
    [SerializeField] private Canvas _checkerCanvas;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Text _interactionText;
    [SerializeField] private Camera _camera;
    private AudioSource _audioSource;
    private Canvas _dialogCanvas;
    private Animator _animator;

    private Ray _ray;
    private RaycastHit _hit;
    private bool _isDialog = false;
    public bool IsDialog
    {
        get { return _isDialog; }
    }

    private void Update()
    {   
        if (!_isDialog)
        {
            TryToAccessToDialog();
        } 
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitFromDialog();
            }
        }
        
    }

    private void TryToAccessToDialog()
    {
        _ray.origin = _camera.transform.position;
        _ray.direction = _camera.transform.forward;
        if (Physics.Raycast(_ray, out _hit, 4, LayerMask.GetMask("NPC")))
        {
            _interactionText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterToDialog();
            }
        }
        else
        {
            _interactionText.enabled = false;
        }
    }

    private void ExitFromDialog()
    {
        _animator.SetBool("IsDialog", false);
        _animator = null;
        _audioSource.Stop();
        _audioSource = null;
        _isDialog = false;
        _checkerCanvas.enabled = true;
        _dialogCanvas.enabled = false;
        _dialogCanvas.transform.GetComponentInChildren<ManageDialogWindowByKeyboard>().enabled = false;
        _dialogCanvas = null;
        _playerController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void EnterToDialog()
    {   
        _animator = _hit.collider.GetComponentInChildren<Animator>();
        _animator.SetBool("IsDialog", true);
        _dialogCanvas = _hit.collider.gameObject.transform.GetComponentInChildren<Canvas>();
        _audioSource = _hit.collider.gameObject.transform.GetComponentInChildren<AudioSource>();
        _isDialog = true;
        _checkerCanvas.enabled = false;
        _dialogCanvas.enabled = true;
        _dialogCanvas.transform.GetComponentInChildren<ManageDialogWindowByKeyboard>().enabled = true;
        _playerController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

