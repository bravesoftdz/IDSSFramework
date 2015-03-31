﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecodistrict.Messaging
{
    /// <summary> 
    /// Static class that can be used to serialize .Net object types to json-strings or json-byte-arrays .
    /// </summary> 
    public static class Serialize
    {
        static Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();

        /// <summary>
        /// Convert the <see cref="IMessage"/> to a json formated string.
        /// </summary>
        /// <param name="obj">The message object.</param>
        /// <param name="indented">If the string should be indented (visual only, does not affect the dashboard interpretation of the message).</param>
        /// <returns>Json string.</returns>
        public static string ToJsonString(IMessage obj, bool indented = false)
        {
            if (indented)
                settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            else
                settings.Formatting = Newtonsoft.Json.Formatting.None;

           return Newtonsoft.Json.JsonConvert.SerializeObject(obj, obj.GetType(), settings);
            
        }

        /// <summary>
        /// Convert the <see cref="IMessage"/> to a json formated byte array.
        /// </summary>
        /// <param name="obj">The message object.</param>
        /// <returns>Json byte array.</returns>
        public static byte[] ToJsonByteArr(IMessage obj)
        {
            string json = ToJsonString(obj);
            return Encoding.UTF8.GetBytes(json);
        }

        /// <summary>
        /// Convert the <see cref="IMessage"/> to a json formated byte array.
        /// </summary>
        /// <remarks>
        /// Used in testing purposes, the <see cref="InputSpecification"/> is newer sent to the dashboard on its own. 
        /// Its allways sent as a part of <see cref="SelectModuleResponse"/>.
        /// </remarks>
        /// <param name="obj">The message object.</param>
        /// <param name="indented">If the string should be indented (visual only, does not affect the dashboard interpretation of the message).</param>
        /// <returns>Json byte array.</returns>
        public static string ToJsonString(InputSpecification obj, bool indented = false)
        {
            if (indented)
                settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            else
                settings.Formatting = Newtonsoft.Json.Formatting.None;

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, obj.GetType(), settings);
            

        }
    }
}
