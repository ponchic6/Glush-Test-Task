using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageDialogWindowByKeyboard : MonoBehaviour
{
    [SerializeField] private List<Button> _buttonList = new List<Button>();
    [SerializeField] private DialogCheckerAndAccessor _dialogChecker;
    [SerializeField] private AudioSource _audioSource;
    private void Update()
    {   
        if (_dialogChecker.IsDialog)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _buttonList[0].onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _buttonList[1].onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _buttonList[2].onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _audioSource.Stop();
            }
        }
    }
}
