using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Networking;
using Object = System.Object;

namespace zerohourcheat
{
    [SuppressMessage("ReSharper", "Unity.RedundantEventFunction")]
    public class HackMain : MonoBehaviour
    
    {
        
        private UserInput[] users;
        public void Awake()
        {
        }
        public void OnEnable()
        {
        }
        public void Start()
        {
            EntityUpdate = EntityUpdateFunct(0);
            StartCoroutine(EntityUpdate);
        }
        public void Update()
        {
            foreach (var user in users)
            {
                user.myWeaponManager.CurrentWeapon.ex_Weight = 0f;
            }
            
        }
        private IEnumerator EntityUpdate;
        private IEnumerator EntityUpdateFunct(float time)
        {
            yield return new WaitForSeconds(time);
            enemies = FindObjectsOfType<ZH_AINav>();
            _camera = Camera.main;
            users = FindObjectsOfType<UserInput>();
            
            EntityUpdate = EntityUpdateFunct(1);
            StartCoroutine(EntityUpdate);
        }
        public void LateUpdate()
        {
        }
        public void FixedUpdate()
        {
        }
        public void OnGUI()
        {
            GUI.Label(new Rect(100,100,100,100), $"Users: {users.Length.ToString()}");
            GUI.color = Color.green;
            SetFontSize(12);
            foreach (var enemy in enemies)
            {
                if (enemy.ManualReference.healthScript.alive)
                {
                    Basic_ESP(enemy.transform, $"nigger\n{DistanceFromCamera(enemy.transform.position).ToString("F1")}");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.Head), "0");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.Neck), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.LeftUpperArm), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.LeftLowerArm), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.RightUpperArm), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.RightLowerArm), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.Chest), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.Hips), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.RightUpperLeg), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.RightLowerLeg), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.LeftFoot), ".");
                    Basic_ESP(enemy.ManualReference.anim.GetBoneTransform(HumanBodyBones.RightFoot), ".");
                }
                else
                {
                    Basic_ESP(enemy.transform, "dead nigger");
                }
            }
        }
        private void Box_ESP(Transform transform)
        {
            Vector3 screenPosition = W2S(transform);
            if (screenPosition.z > 0)
            {
                GUI.Box(new Rect(screenPosition.x, Screen.height - screenPosition.y, 50, 100), "X");
            }
        }
        
        private ZH_AINav[] enemies;
        private Camera _camera;
        private Vector3 W2S(Transform transform)
        {
            return _camera.WorldToScreenPoint(transform.position);
        }
        private float DistanceFromCamera(Vector3 worldPos)
        {
            return Vector3.Distance(_camera.transform.position, worldPos);
        }
        private void Basic_ESP(Transform transform, string text)
        {
            Vector3 screenPosition = W2S(transform);
            if (screenPosition.z > 0)
            {
                GUI.Label(new Rect(screenPosition.x,
                        Screen.height - screenPosition.y,
                        screenPosition.x + (text.Length * GUI.skin.label.fontSize),
                        Screen.height -  screenPosition.y + GUI.skin.label.fontSize*2),
                    text);
            }
        }
        void SetFontSize(int size)
        {
            GUISkin skin = GUI.skin;
            GUIStyle newStyle = skin.GetStyle("Label");
            newStyle.fontSize = size;
            

        }
    }
}
