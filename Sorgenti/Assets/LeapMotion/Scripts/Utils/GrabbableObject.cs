/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;

public class GrabbableObject : MonoBehaviour {

  public bool useAxisAlignment = false;
  public Vector3 rightHandAxis;
  public Vector3 objectAxis;

  public bool rotateQuickly = true;
  public bool centerGrabbedObject = false;

  public Rigidbody breakableJoint;
  public float breakForce;
  public float breakTorque;

  public bool grabbed_ = false;
  protected bool hovered_ = false;

  public bool IsHovered() {
    return hovered_;
  }

  public bool IsGrabbed() {
    return grabbed_;
  }

  public virtual void OnStartHover() {
    hovered_ = true;
  }

  public virtual void OnStopHover() {
    hovered_ = false;
  }

  public virtual void OnGrab() {
    grabbed_ = true;
    hovered_ = false;

    if (breakableJoint != null) {
      Joint breakJoint = breakableJoint.GetComponent<Joint>();
      if (breakJoint != null) {
       
      }
    }
  }

  public virtual void OnRelease() {
    grabbed_ = false;
		rigidbody.Sleep();
		StartCoroutine(MyMethod());

  }

	IEnumerator MyMethod() {

		//Leap.Utils.IgnoreCollisions(gameObject, active_object_.gameObject, true);
	//	Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(0.005f);
//		Debug.Log("After Waiting 2 Seconds");
		rigidbody.WakeUp();

		//active_object_.rigidbody.AddForce(new Vector3(0,1,0) * 50);


	}

}
