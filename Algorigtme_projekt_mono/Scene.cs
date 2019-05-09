﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono
{
 
        public abstract class Scene
        {
            private List<GameObject> activeObjects = new List<GameObject>();
            private List<GameObject> objectsToAdd = new List<GameObject>();
            private List<GameObject> objectsToRemove = new List<GameObject>();

            /// <summary>
            /// Returns a readonly list of objects currently active in the scene.
            /// </summary>
            public ReadOnlyCollection<GameObject> ActiveObjects
            {
                get { return activeObjects.AsReadOnly(); }
            }

            public Scene()
            {
            }

            /// <summary>
            /// Updates all game objects in this scene and processes object lists.
            /// </summary>
            public virtual void Update()
            {
                ProcessObjectLists();

                foreach (GameObject go in activeObjects)
                    go.ProcessComponents();

                foreach (GameObject go in activeObjects)
                    go.SendMessage(new UpdateMsg());
            }

            /// <summary>
            /// Draws all game objects in this scene.
            /// </summary>
            /// <param name="batch"></param>
            public virtual void Draw(SpriteBatch batch)
            {
                ProcessObjectLists();

                IEnumerable<GameObject> orderedObjects = activeObjects.OrderBy(a => a.Transform.Position.Y);
                foreach (GameObject go in orderedObjects)
                    go.SendMessage(new DrawMsg(batch));
            }

            /// <summary>
            /// Marks an object for addition to ActiveObjects.
            /// </summary>
            /// <param name="go"></param>
            public void AddObject(GameObject go)
            {
                objectsToAdd.Add(go);
            }

            /// <summary>
            /// Marks an object for removal from ActiveObjects.
            /// </summary>
            /// <param name="go"></param>
            public void RemoveObject(GameObject go)
            {
                objectsToRemove.Add(go);
            }     
         
            /// <summary>
            /// Processes objects marked with AddObject or RemoveObject.
            /// The objects will be added/removed from ActiveObjects.
            /// </summary>
            protected void ProcessObjectLists()
            {
                //Additions
                foreach (GameObject gameObject in objectsToAdd)
                    activeObjects.Add(gameObject);

                objectsToAdd.Clear();

                //Removal
                foreach (GameObject gameObject in objectsToRemove)
                    activeObjects.Remove(gameObject);
             

                objectsToRemove.Clear();
            }
        }
    }

