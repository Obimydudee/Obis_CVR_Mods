using System;
using System.Collections;
using UnityEngine;
using MelonLoader;
using UnityEngine.UI;

namespace _3rdPerson
{
    internal class THRDP
    {
        public static GameObject TPCameraBack;
        public static GameObject TPCameraFront;
        public static GameObject referenceCamera;
        public static GameObject _uiDot;
        public static GameObject _uiCam;
        public static GameObject _uiCoHt;
        public static float zoomOffset;
        public static float offsetX;
        public static float offsetY;
        public static int CameraSetup;

        public static void Initialize()
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(gameObject.GetComponent<MeshRenderer>());
            THRDP.referenceCamera = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera");
            _uiDot = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera/Canvas/Image")?.gameObject;
            _uiCam = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera/_UICamera")?.gameObject;
            _uiCoHt = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera/CohtmlHud")?.gameObject;
            if (THRDP.referenceCamera != null)
            {
                gameObject.transform.localScale = THRDP.referenceCamera.transform.localScale;
                Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
                if (gameObject.GetComponent<Collider>())
                {
                    gameObject.GetComponent<Collider>().enabled = false;
                }
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.AddComponent<Camera>();
                GameObject gameObject2 = THRDP.referenceCamera;
                gameObject.transform.parent = gameObject2.transform;
                gameObject.transform.rotation = gameObject2.transform.rotation;
                gameObject.transform.position = gameObject2.transform.position;
                gameObject.transform.position -= gameObject.transform.forward * 2f;
                gameObject2.GetComponent<Camera>().enabled = false;
                gameObject.GetComponent<Camera>().fieldOfView = 75f;
                gameObject.GetComponent<Camera>().nearClipPlane /= 4f;
                THRDP.TPCameraBack = gameObject;
                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(gameObject3.GetComponent<MeshRenderer>());
                gameObject3.transform.localScale = THRDP.referenceCamera.transform.localScale;
                Rigidbody rigidbody2 = gameObject3.AddComponent<Rigidbody>();
                rigidbody2.isKinematic = true;
                rigidbody2.useGravity = false;
                if (gameObject3.GetComponent<Collider>())
                {
                    gameObject3.GetComponent<Collider>().enabled = false;
                }
                gameObject3.GetComponent<Renderer>().enabled = false;
                gameObject3.AddComponent<Camera>();
                gameObject3.transform.parent = gameObject2.transform;
                gameObject3.transform.rotation = gameObject2.transform.rotation;
                gameObject3.transform.Rotate(0f, 180f, 0f);
                gameObject3.transform.position = gameObject2.transform.position;
                gameObject3.transform.position += -gameObject3.transform.forward * 2f;
                gameObject2.GetComponent<Camera>().enabled = false;
                gameObject3.GetComponent<Camera>().fieldOfView = 75f;
                gameObject3.GetComponent<Camera>().nearClipPlane /= 4f;
                THRDP.TPCameraFront = gameObject3;
                THRDP.TPCameraBack.GetComponent<Camera>().enabled = false;
                THRDP.TPCameraFront.GetComponent<Camera>().enabled = false;
                GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponent<Camera>().enabled = true;
                MelonCoroutines.Start(THRDP.Loop());
            }
        }

        public static IEnumerator Loop()
        {
            while (true)
            {
                if (THRDP.TPCameraBack != null && THRDP.TPCameraFront != null)
                {
                    if (THRDP.CameraSetup == 0)
                    {
                        _uiDot.GetComponent<Image>().enabled = true;
                        _uiDot.gameObject.SetActive(true);
                        _uiCam.gameObject.SetActive(true);
                        _uiCoHt.gameObject.SetActive(true);
                        THRDP.TPCameraBack.GetComponent<Camera>().enabled = false;
                        THRDP.TPCameraFront.GetComponent<Camera>().enabled = false;
                    }
                    else if (THRDP.CameraSetup == 1)
                    {
                        _uiDot.GetComponent<Image>().enabled = false;
                        _uiDot.gameObject.SetActive(false);
                        _uiCam.gameObject.SetActive(false);
                        _uiCoHt.gameObject.SetActive(false);
                        THRDP.TPCameraBack.GetComponent<Camera>().enabled = true;
                        THRDP.TPCameraFront.GetComponent<Camera>().enabled = false;
                    }
                    else if (THRDP.CameraSetup == 2)
                    {
                        _uiDot.GetComponent<Image>().enabled = false;
                        _uiDot.gameObject.SetActive(false);
                        _uiCam.gameObject.SetActive(false);
                        _uiCoHt.gameObject.SetActive(false);
                        THRDP.TPCameraBack.GetComponent<Camera>().enabled = false;
                        THRDP.TPCameraFront.GetComponent<Camera>().enabled = true;
                    }
                    if (THRDP.CameraSetup != 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            THRDP.CameraSetup = 0;
                        }
                        float axis = Input.GetAxis("Mouse ScrollWheel");
                        if (axis > 0f)
                        {
                            THRDP.TPCameraBack.transform.position += THRDP.TPCameraBack.transform.forward * 0.1f;
                            THRDP.TPCameraFront.transform.position -= THRDP.TPCameraBack.transform.forward * 0.1f;
                            THRDP.zoomOffset += 0.1f;
                        }
                        else if (axis < 0f)
                        {
                            THRDP.TPCameraBack.transform.position -= THRDP.TPCameraBack.transform.forward * 0.1f;
                            THRDP.TPCameraFront.transform.position += THRDP.TPCameraBack.transform.forward * 0.1f;
                            THRDP.zoomOffset -= 0.1f;
                        }
                    }
                }
                yield return new WaitForEndOfFrame();
            }
            yield break;
        }

        public static void Start()
        {
            MelonCoroutines.Start(THRDP.CameraNullCheck());
        }

        public static IEnumerator CameraNullCheck()
        {
            while (true)
            {
                if (GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera") == null)
                {
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    THRDP.Initialize();
                    yield break;
                }
            }
            yield break;
        }
    }
}
