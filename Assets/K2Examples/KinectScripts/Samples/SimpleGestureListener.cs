using UnityEngine;
//using Windows.Kinect;
using System.Collections;
using System;


public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	[Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
	public int playerIndex = 0;

	[Tooltip("UI-Text to display gesture-listener messages and gesture information.")]
	public UnityEngine.UI.Text gestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;
	private float progressGestureTime;
	public void UserDetected(long userId, int userIndex)
	{
		if (userIndex != playerIndex)
			return;

		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.JumpSquat);
		manager.DetectGesture(userId, KinectGestures.Gestures.LeftSideSquat);
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

		manager.DetectGesture(userId, KinectGestures.Gestures.Quickfeat);
		manager.DetectGesture(userId, KinectGestures.Gestures.WideQuickfeat);

		if(gestureInfo != null)
		{
			gestureInfo.text = "Swipe, Jump, Squat or Lean.";
		}
	}
	
	public void UserLost(long userId, int userIndex)
	{
		if (userIndex != playerIndex)
			return;

		if(gestureInfo != null)
		{
			gestureInfo.text = string.Empty;
		}
	}

	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{
		if (userIndex != playerIndex)
			return;

		if((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				string sGestureText = string.Format ("{0} - {1:F0}%", gesture, screenPos.z * 100f);
				gestureInfo.text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
		else if((gesture == KinectGestures.Gestures.Wheel || gesture == KinectGestures.Gestures.LeanLeft || gesture == KinectGestures.Gestures.LeanRight ||
			gesture == KinectGestures.Gestures.LeanForward || gesture == KinectGestures.Gestures.LeanBack) && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				string sGestureText = string.Format ("{0} - {1:F0} degrees", gesture, screenPos.z);
				gestureInfo.text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
		else if(gesture == KinectGestures.Gestures.Run && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				string sGestureText = string.Format ("{0} - progress: {1:F0}%", gesture, progress * 100);
				gestureInfo.text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
	}

	public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint, Vector3 screenPos)
	{
		if (userIndex != playerIndex)
			return false;

		if(progressDisplayed)
			return true;

		string sGestureText = gesture + " detected";
		if(gestureInfo != null)
		{
			gestureInfo.text = sGestureText;
		}

		if(gesture == KinectGestures.Gestures.Squat && PlayerController.playerStatus == PlayerController.PLAYERSTATUS.FINAL_SQUAT)
        {
			PlayerController.curSquatNum++;
			for (int i = 0; i < GameManager.Instance.playerMorphs.Count; i++)
			{
				GameManager.Instance.playerMorphs[i].localScale += new Vector3(0.02f, 0.0f, 0.012f);
			}
		}

		if(gesture == KinectGestures.Gestures.JumpSquat && PlayerController.playerStatus == PlayerController.PLAYERSTATUS.JUMP_SQUAT)
        {
			PlayerController.curSquatNum++;
			AvatarController.offsetNode.transform.Translate(0.0f, 1.5f, 1.5f);
			for(int i = 0; i < GameManager.Instance.playerMorphs.Count; i++)
            {
				GameManager.Instance.playerMorphs[i].localScale += new Vector3(0.02f, 0.0f, 0.012f);
			}
			Debug.Log("JUMP SQUAT!");
        }

		if (gesture == KinectGestures.Gestures.LeftSideSquat && PlayerController.playerStatus == PlayerController.PLAYERSTATUS.SIDE_SQUAT)
		{
			PlayerController.curSquatNum++;
			AvatarController.offsetNode.transform.Translate(-2.2f, 0.0f, 0.0f);
			Debug.Log("SIDE SQUAT!");
			for (int i = 0; i < GameManager.Instance.playerMorphs.Count; i++)
			{
				GameManager.Instance.playerMorphs[i].localScale += new Vector3(0.02f, 0.0f, 0.012f);
			}
		}

		// Debug.Log("Completed : " + gesture.ToString());

		return true;
	}

	public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint)
	{
		if (userIndex != playerIndex)
			return false;

		if(progressDisplayed)
		{
			progressDisplayed = false;

			if(gestureInfo != null)
			{
				gestureInfo.text = String.Empty;
			}
		}

		//Debug.Log("Cancelled ! : " + gesture.ToString());

		return true;
	}

	public void Update()
	{
		if(progressDisplayed && ((Time.realtimeSinceStartup - progressGestureTime) > 2f))
		{
			progressDisplayed = false;
			
			if(gestureInfo != null)
			{
				gestureInfo.text = String.Empty;
			}

			Debug.Log("Forced progress to end.");
		}
	}
	
}
