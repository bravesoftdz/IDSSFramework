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
    /// Derived from the class <see cref="Request"/> and is used as a .Net container for
    /// deseralizing dashboard json-messages of the type "selectModule" request.
    /// </summary>
    [DataContract]
    public class SelectModuleRequest : Request
    {
        [DataMember]
        public string moduleId { get; private set; }
        [DataMember]
        public string variantId { get; private set; }
        [DataMember]
        public string kpiId { get; private set; }
    }
}
