﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Ecodistrict.Messaging
{
    /// <summary>
    /// An input class derived from the class <see cref="NonAtomic"/>. 
    /// </summary>
    /// <remarks>
    /// May be used to define the input specification <see cref="InputSpecification"/>.<br/>
    /// <br/>
    /// In that case it will may be displayed as a subgroup containing the supplied <see cref="Atomic"/> 
    /// and <see cref="NonAtomic"/> input.
    /// </remarks>
    [DataContract]
    public class InputGroup : NonAtomic    
    {
        internal InputGroup() { }

        /// <summary>
        /// InputGroup constructor.
        /// </summary>
        /// <param name="label">Mandatory label of the visualized component.</param>
        /// <param name="order">Order in which this component should be rendered in the dashboard (ascending order).
        /// Left out or null value will be interpeted as 0 in the dashboard.</param>
        public InputGroup(string label, object order = null)
        {
            this.type = "inputGroup";
            this.label = label;
            this.order = order;
        }
    }
}
