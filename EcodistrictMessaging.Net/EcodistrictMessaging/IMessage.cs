﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.Diagnostics.Contracts;
using System.Threading;

namespace Ecodistrict.Messaging
{
    /// <summary> 
    /// Base class to all messagingtypes that can be sent to/from the dashboard.
    /// </summary> 
    /// <remarks> 
    /// Messages that are sent from the dashboard can be deseralized from a json string
    /// to this type of object by the use of <see cref="Ecodistrict.Messaging.Deseralize.JsonMessage"/>.
    /// 
    /// Messages that will be sent to the dashboard must first be seralized to a json string
    /// this can be done by <see cref="Ecodistrict.Messaging.Seralize.Message"/>.
    /// </remarks> 
    [DataContract]
    public class IMessage 
    {
        [DataMember]
        public string method { get; protected set; }
        [DataMember]
        public string type { get; protected set; }

        /// <summary>
        /// Enum describing the underlying message method; based on the string property method. 
        /// If no valid method can be found this property is set to enum "NoMethod".
        /// </summary>
        private Types.MMethod eMethod
        {
            get
            {
                switch (method)
                {
                    case "getModels":
                        return Types.MMethod.GetModels;
                    case "selectModel":
                        return Types.MMethod.SelectModel;
                    case "startModel":
                        return Types.MMethod.StartModel;
                    case "modelResult":
                        return Types.MMethod.ModelResult;
                    default:
                        return Types.MMethod.NoMethod;
                }
            }
        }

        /// <summary>
        /// Enum describing the underlying message type; based on the string property type. 
        /// If no valid type can be found this property is set to enum "NoType".
        /// </summary>
        private Types.MType eType
        {
            get
            {
                switch (type)
                {
                    case "request":
                        return Types.MType.Request;
                    case "response":
                        return Types.MType.Response;
                    case "result":
                        return Types.MType.Result;
                    default:
                        return Types.MType.NoType;
                }
            }
        }

        /// <summary>
        /// Gets the underlying derived class based on method and type property.
        /// </summary>
        /// <returns>Derived type</returns>
        public Type GetDerivedType()
        {

            switch(eType)
            {
                case Types.MType.Request:
                    switch(eMethod)
                    {
                        case Types.MMethod.GetModels:
                            return typeof(GetModelsRequest);
                        case Types.MMethod.SelectModel:
                            return typeof(SelectModelRequest);
                        case Types.MMethod.StartModel:
                            return typeof(StartModelRequest);
                    }
                    break;
                case Types.MType.Response:
                    switch (eMethod)
                    {
                        case Types.MMethod.GetModels:
                            return typeof(GetModelsResponse);
                        case Types.MMethod.SelectModel:
                            return typeof(SelectModelResponse);
                        case Types.MMethod.StartModel:
                            return typeof(StartModelResponse);
                    }
                    break;
                case Types.MType.Result:
                    switch (eMethod)
                    {
                        case Types.MMethod.ModelResult:
                            return typeof(ModelResult);
                    }
                    break;
            }


            return null;
        }

    }
}