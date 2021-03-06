﻿using System;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using static Dna.FrameworkDI;
using Dna;

namespace AngelSix.SolidDna
{
    /// <summary>
    /// Represents a SolidWorks model of any type (Drawing, Part or Assembly)
    /// </summary>
    public class Component : SolidDnaObject<Component2>
    {
        #region Public Properties

        /// <summary>
        /// Get the Model from the component
        /// </summary>
        public Model AsModel => new Model (mBaseObject.GetModelDoc2() as ModelDoc2);

        /// <summary>
        /// Check if the Component is Root
        /// </summary>
        public bool IsRoot => mBaseObject.IsRoot();

        /// <summary>
        /// get children from this Component
        /// </summary>
        public object[] Children => mBaseObject.GetChildren() as object[];

        /// <summary>
        /// Get the name of the component
        /// </summary>
        public string Name => mBaseObject.Name2;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Component(Component2 component) : base(component)
        {
        }

        #endregion

        #region Dispose

        public override void Dispose()
        {
            // Clean up embedded objects
            AsModel?.Dispose();

            // Dispose self
            base.Dispose();
        }

        #endregion
    }
}
