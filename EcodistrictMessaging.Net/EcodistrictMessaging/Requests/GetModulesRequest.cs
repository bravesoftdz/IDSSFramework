﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Ecodistrict.Messaging.Requests
{
    /// <summary>
    /// Derived from the class <see cref="Request"/> and is used as a .Net container for
    /// deseralizing dashboard json-messages specifying the method "getModules" and the 
    /// type "request".<br/>
    /// <br/>
    /// This message should be answered with a message of the type <see cref="GetModulesResponse"/>.
    /// </summary>
    /// <example>
    /// A simple reconstruction of a dashboard json message. Normally these are acquired through
    /// an IMB-hub in an byte array, in that case you may use Deserialize.JsonByteArr(bArr). 
    /// See <see cref="Deserialize{T}"/>.
    /// <code>
    /// //json-string from dashboard
    /// string message = "{\"method\": \"getModules\",\"type\": \"request\"}";
    /// ///Message reconstructed into a .Net object.
    /// IMessage recievedMessage = Deserialize.JsonString(message);
    /// //Write object type to console
    /// Console.WriteLine(recievedMessage.GetType().ToString());
    /// //Output: Ecodistrict.Messaging.GetModulesRequest
    /// </code>
    /// </example>
    /// <seealso cref="IMessage"/>
    /// <seealso cref="GetModulesResponse"/>
    /// <seealso cref="Deserialize{T}"/>
    [DataContract]
    public class GetModulesRequest : Request
    {
    }
       
}
