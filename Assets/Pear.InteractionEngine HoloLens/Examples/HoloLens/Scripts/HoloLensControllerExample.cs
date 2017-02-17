﻿using Pear.InteractionEngine.Controllers;
using Pear.InteractionEngine.Controllers.Behaviors;
using Pear.InteractionEngine.Interactables;

namespace Pear.InteractionEngine.Examples
{
    public class HoloLensControllerExample : HoloLensController
    {

        public DragToRotate DragToRotate;
        public DragToZoom DragToZoom;

        void Awake()
        {
            InteractableObjectManager.Instance.OnAdded.AddListener(interactable =>
            {
                // When an object is selected make it the active object
                interactable.Selected.OnStart.AddListener(e =>
                {
                    ActiveObject = e.Obj;
                });

                // When it's deseleted make the active object null
                interactable.Selected.OnEnd.AddListener(e =>
                {
                    ActiveObject = null;
                });
            });
        }

        public void EnterRotateMode()
        {
            DragToRotate.enabled = true;
            DragToZoom.enabled = false;
        }

        public void EnterZoomMode()
        {
            DragToZoom.enabled = true;
            DragToRotate.enabled = false;
        }
    }
}